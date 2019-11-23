--------BAJA_LOGICA_CLIENTE-------------------------
drop procedure baja_logica_cliente
drop procedure Eliminar_Cliente
drop procedure habilitar_cliente
drop procedure actualizar_cliente

CREATE PROCEDURE baja_logica_cliente(@DNI_CLIENTE numeric(18,0),@username varchar(255))
AS BEGIN
	if Exists(select 1 from ROLES_POR_USUARIO where Username = @username)
		begin			
			delete from ROLES_POR_USUARIO where Username = @username
			update CLIENTES
			set Estado = 'Inhabilitado' where DNI = @DNI_CLIENTE
		end
	else
		begin
			throw 50003, 'El cliente ya esta Inhabilitado',1
		end
END


---------HABILITAR_CLIENTE----------------------------
CREATE PROCEDURE habilitar_cliente(@DNI_CLIENTE numeric(18,0),@username varchar(255))
AS BEGIN

	if not exists(select 1 from ROLES_POR_USUARIO where Username = @username)
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

Create Procedure actualizar_cliente(@username varchar(255),@nombre varchar(255), @apellido varchar(255), @DNI numeric(18,0), @telefono numeric(18,0),
@mail varchar(255),@fecha varchar(255), @direccion varchar(255), @CP int, @Loc varchar(255), @Npiso int, @depto varchar(255))
AS BEGIN

	declare @direcID int = (select direccion from CLIENTES where username = @username)

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
	where username = @username

END