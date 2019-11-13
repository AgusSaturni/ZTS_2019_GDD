-----------------BAJA_LOGICA_PROVEEDOR-------------------------
CREATE PROCEDURE baja_logica_proveedor(@CUIT char(20))
AS BEGIN
	if((select Estado from PROVEEDORES where CUIT = @CUIT) = 'Habilitado')
		begin
			update PROVEEDORES
			set Estado = 'Inhabilitado' where CUIT = @CUIT
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Inhabilitado',1
		end

END


-----------------HABILITAR_PROVEEDOR-----------------------------
CREATE PROCEDURE habilitar_proveedor(@CUIT char(20))
AS BEGIN
	if((select Estado from PROVEEDORES where cuit = @CUIT) = 'Inhabilitado')
		begin
			update PROVEEDORES
			set Estado = 'Habilitado' where CUIT = @CUIT
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Habilitado',1
		END
END
--------------------actualizar_proveedor---------------------------
Create Procedure actualizar_proveedor(@username char(50),@razonSocial char(50), @rubro char(50), @CUIT char(20), @telefono numeric(18,0),
@mail char(50),@contacto char(50), @direccion char(100), @CP int, @Loc char(50), @Npiso int, @depto char(10))
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
	where Proveedor_Id =@id_proveedor
END
