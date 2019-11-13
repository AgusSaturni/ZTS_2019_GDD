--------BAJA_LOGICA_CLIENTE-------------------------
CREATE PROCEDURE baja_logica_cliente(@DNI_CLIENTE numeric(18,0))
AS BEGIN
	
	DECLARE @username char(50) = (select username from CLIENTES where DNI = @DNI_CLIENTE)

	if exists (select Estado from CLIENTES where dni = @DNI_CLIENTE and Estado = 'Habilitado')
		begin
			update CLIENTES
			set Estado = 'Inhabilitado' where DNI = @DNI_CLIENTE

			DELETE FROM ROLES_POR_USUARIO WHERE Username = @username
		end
	else
		begin
			throw 50003, 'El cliente ya esta Inhabilitado',1
		end
END

---------HABILITAR_CLIENTE----------------------------
CREATE PROCEDURE habilitar_cliente(@DNI_CLIENTE numeric(18,0))
AS BEGIN

	DECLARE @username char(50) = (select username from CLIENTES where DNI = @DNI_CLIENTE)

	if((select Estado from CLIENTES where dni = @DNI_CLIENTE) = 'Inhabilitado')
		begin
			update CLIENTES
			set Estado = 'Habilitado' where DNI = @DNI_CLIENTE
			
			insert into ROLES_POR_USUARIO (Rol_Id, Username) values ('Cliente', @username)
		end
	else
		begin
			throw 50003, 'El cliente ya esta Habilitado',1
		end
END

-----------------------------ACTUALIZAR_CLIENTE------------------------------------------------------  

Create Procedure actualizar_cliente(@nombre char(50), @apellido char(50), @DNI numeric(18,0), @telefono numeric(18,0),
@mail char(50),@fecha char(50), @direccion char(100), @CP int, @Loc char(50), @Npiso int, @depto char(10))
AS BEGIN

	declare @direcID int = (select direccion from CLIENTES where DNI = @DNI)

	update DIRECCION 
		set 
			Direccion = @direccion,
			Codigo_Postal = @CP,
			Localidad = @Loc,
			Numero_Piso = @Npiso,
			Depto = @depto
		where Id_DIRECCION = @direcID

	update CLIENTES
		set
			Nombre = @nombre,
			Apellido = @apellido,
			DNI = @DNI,
			Telefono = @telefono,
			Mail = @mail
	where DNI = @DNI

END

