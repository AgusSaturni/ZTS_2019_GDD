
/*
drop procedure baja_logica_proveedor
drop procedure habilitar_proveedor
drop procedure actualizar_proveedor
drop procedure proveedor_existente
*/

-----------------BAJA_LOGICA_PROVEEDOR-------------------------
CREATE PROCEDURE baja_logica_proveedor(@CUIT varchar(255),@username varchar(255))
AS BEGIN

	if exists (select 1 from ROLES_POR_USUARIO where Username = @username)
		begin
			delete from ROLES_POR_USUARIO where Username = @username
			update PROVEEDORES
			set Estado = 'Inhabilitado' where CUIT = @CUIT
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Inhabilitado',1
		end

END

-----------------HABILITAR_PROVEEDOR-----------------------------
CREATE PROCEDURE habilitar_proveedor(@CUIT varchar(255), @Username varchar(255))
AS BEGIN
	if  ((select estado from ROLES where Estado = 'Proveedor') = 'Inahabilitado')
			throw 50005,'Rol Inhabilitado',1
else
	begin
	if not exists(select 1 from ROLES_POR_USUARIO where Username = @username)
		begin
			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values('Proveedor',@Username)
			update PROVEEDORES
			set Estado = 'Habilitado' where CUIT = @CUIT
		end
	else
			throw 50009,'El proveedor ya esta habilitado',1
	end
END



--------------------actualizar_proveedor---------------------------
Create Procedure actualizar_proveedor(@username varchar(255),@razonSocial varchar(255), @rubro varchar(255), @CUIT varchar(255), @telefono numeric(18,0),
@mail varchar(255), @direccion varchar(255), @ciudad varchar(255),
@CP int = NULL, @Loc varchar(255) = NULL, @Npiso int = NULL, @depto varchar(255) = NULL, @contacto varchar(255) = NULL)
AS BEGIN

	IF NOT EXISTS(SELECT 1 FROM PROVEEDORES WHERE username != @username and (Razon_Social = @razonSocial OR CUIT = @CUIT) )
	BEGIN
		DECLARE @RUBRO_ID varchar(15) = (select Rubro_Id from RUBROS where rubro_descripcion = @rubro)

		update PROVEEDORES
		set
			Razon_Social = @razonSocial,
			CUIT = @CUIT,
			Telefono = @telefono,
			Mail = @mail,
			Nombre_contacto = @contacto,
			Rubro_Id = @RUBRO_ID
		where username = @username
	END
	ELSE
	BEGIN
		THROW 60000, 'La razon social y/o el cuit que desea ingresar, ya estan utilizados por otro proveedor. Porfavor ingrese otro.', 1
	END

	
	declare @direcID int = (select direccion from PROVEEDORES where username = @username)

	--SI EXISTE LA DIRECCION EN EL SISTEMA, SIMPLEMENTE TOMO EL ID Y ME LO ASIGNO
	IF EXISTS(SELECT 1 FROM DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
				((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
				((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
				((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
				((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
				)

		BEGIN
			DECLARE @direcID_existente int = (select Id_Direccion from DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto))

			update PROVEEDORES
			set Direccion = @direcID_existente
			where username = @username				
		END
	ELSE
		BEGIN
		--SI NO EXISTE LA DIRECCION NUEVA EN EL SISTEMA, PERO HAY MASDE 1 PROVEEDOR o CLIENTE QUE TIENE MI DIRECCION ACTUAL, INSERTO LA NUEVA, TOMO EL ID NUEVO Y ME LO ASIGNO
			IF ( ((SELECT COUNT(1) FROM PROVEEDORES WHERE Direccion = @direcID) > 1) OR ((SELECT COUNT(1) FROM CLIENTES WHERE Direccion = @direcID) >= 1) )
			BEGIN
					insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			
					DECLARE @direcc_id_nuevo int
					set @direcc_id_nuevo = (select id_direccion from DIRECCION
					where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
					)

					update PROVEEDORES
						set Direccion = @direcc_id_nuevo
					where username = @username
			END
		ELSE
			BEGIN
			--SI NO EXISTE OTRO PROVEEDOR o CLIENTE CON MI MISMA DIRECCION VIEJA, SIMPLEMENTE ACTUALIZO
					update DIRECCION 
					set 
						Direccion = @direccion,
						Ciudad = @ciudad,
						Codigo_Postal = @CP,
						Localidad = @Loc,
						Numero_Piso = @Npiso,
						Depto = @depto
					where Id_DIRECCION = @direcID
			END
	END

END

drop procedure actualizar_proveedor

----------------------FACTURAR PROVEEDOR-------------------------
CREATE PROCEDURE proveedor_existente(@proveedor VARCHAR(255))
AS BEGIN
	If NOT EXISTS (SELECT 1 FROM PROVEEDORES WHERE username = @proveedor)
	BEGIN
		THROW 90003,'El proveedor no esta registrado.',1
	END
END


CREATE FUNCTION pedir_proveedorID(@proveedor_username VARCHAR(255))
	RETURNS VARCHAR(255)
AS BEGIN
	RETURN (SELECT Proveedor_Id FROM PROVEEDORES WHERE username = @proveedor_username)
END

drop function pedir_proveedorID

----SELECT que se utilizo en el codigo de FacturarProveedor para llenar el DGV
--SELECT o.Codigo_Oferta, o.Descripcion, Cantidad*Precio_oferta AS Facturado, com.Fecha_compra FROM COMPRAS com
--	JOIN OFERTAS o ON o.Codigo_oferta = com.Codigo_oferta
--WHERE o.Proveedor_referenciado = 'ProveedorID38' 
--	AND com.Fecha_compra BETWEEN '2015-06-26' AND '2019-12-04'
--	AND com.Factura_Id IS NULL

----INSERT para crear facturas
CREATE PROCEDURE insertar_factura(@proveedor_id varchar(255), @fecha datetime, @numero_id bigint, @importe numeric(20,2))
AS BEGIN
	INSERT INTO FACTURAS (Proveedor_Id,FECHA, Numero,ImporteTotal) VALUES(@proveedor_id, CONVERT(DATETIME, @fecha, 121), @numero_id, @importe)
END

drop procedure insertar_factura

--------------------VERIFICAR Si NO ES PROVEEDOR---------------------
CREATE PROCEDURE verificar_si_no_es_proveedor(@username varchar(255))
AS begin
if exists (select 1 from ROLES_POR_USUARIO where Username = @username and Rol_Id = 'Administrador')
	throw 50005,'No es proveedor',1
end