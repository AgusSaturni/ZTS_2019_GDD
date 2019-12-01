
-----------------BAJA_LOGICA_PROVEEDOR-------------------------
CREATE PROCEDURE baja_logica_proveedor(@CUIT varchar(255),@username varchar(255))
AS BEGIN

	if exists (select * from ROLES_POR_USUARIO where Username = @username)
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

drop procedure baja_logica_proveedor

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


drop procedure habilitar_proveedor
--------------------actualizar_proveedor---------------------------
Create Procedure actualizar_proveedor(@username varchar(255),@razonSocial varchar(255), @rubro varchar(255), @CUIT varchar(255), @telefono numeric(18,0),
@mail varchar(255),@contacto varchar(255), @direccion varchar(255), @CP int, @Loc varchar(255), @Npiso int, @depto varchar(255))
AS BEGIN

	declare @direcID int = (select direccion from PROVEEDORES where username = @username)

	update DIRECCION 
		set 
			Direccion = @direccion,
			Codigo_Postal = @CP,
			Localidad = @Loc,
			Numero_Piso = @Npiso,
			Depto = @depto
		where Id_DIRECCION = @direcID

	update PROVEEDORES
		set
			Razon_Social = @razonSocial,
			CUIT = @CUIT,
			Telefono = @telefono,
			Mail = @mail,
			Nombre_contacto = @contacto
	where username = @username

	declare @id_proveedor varchar(19) = (select Proveedor_Id from PROVEEDORES where username = @username)

	update RUBROS
	set
	rubro_descripcion = @rubro
	where Proveedor_Id = @id_proveedor
END

----------------------FACTURAR PROVEEDOR-------------------------
CREATE PROCEDURE proveedor_existente(@proveedor VARCHAR(255))
AS BEGIN
	If NOT EXISTS (SELECT * FROM PROVEEDORES WHERE username = @proveedor)
	BEGIN
		THROW 90003,'El proveedor no esta registrado.',1
	END
END

CREATE FUNCTION pedir_proveedorID(@proveedor_username VARCHAR(255))
	RETURNS VARCHAR(255)
AS BEGIN
	RETURN (SELECT Proveedor_Id FROM PROVEEDORES WHERE username = @proveedor_username)
END

select dbo.pedir_proveedorID('a')

SELECT * FROM FACTURAS WHERE Proveedor_Id = 'ProveedorID3' AND Fecha BETWEEN '2015-01-31' AND '2022-01-31'
select * from ofertas

SELECT c.Oferta_Id,  FROM COMPRAS c JOIN OFERTAS o ON c.Oferta_Id = o.Oferta_Id --mostrar la cantidad que se compro de cada oferta por factura
WHERE o.Proveedor_referenciado = 'ProveedorID3'


SELECT * FROM CUPONES 


select username from PROVEEDORES where Proveedor_Id = 'ProveedorID3'

select * from COMPRAS
select * from OFERTAS
select * from PROVEEDORES