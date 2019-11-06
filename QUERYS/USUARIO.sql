
drop procedure registrar_usuario
drop procedure registrar_usuario_cliente
drop procedure registrar_usuario_proveedor


------REGISTRO_USUARIO------------
CREATE PROCEDURE registrar_usuario(@Username char(50), @Password char(50),@Rol char(20))
AS BEGIN
	IF NOT EXISTS(select * from USUARIOS where Username = @Username)
		  begin  
			insert into USUARIOS(Username,Password)
			values(@username,@password)

			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)
		  end
	ELSE
		  begin
			THROW 50000,'Ya existe ese Nombre de Usuario',1
		  end 
END



-------------------------------------------------------
CREATE PROCEDURE registrar_usuario_cliente(@username char(50),@nombre char(20),@apellido char(20),@DNI numeric(18,0),@telefono numeric(18,0),@mail char(50),@fecha_nacimiento datetime,
											@Direccion char(100))

AS BEGIN

DECLARE @direcc_id int
set @direcc_id = (select distinct id_direccion from DIRECCION where Direccion = @Direccion)

	IF NOT EXISTS(select nombre,apellido,DNI,telefono,mail,fecha_nacimiento from CLIENTES where dni=@DNI)
		BEGIN
		
			insert into CLIENTES(Username,Nombre,Apellido,DNI,Direccion,Telefono,Mail,Fecha_Nacimiento)
			values(@username, @nombre,@apellido,@DNI,@direcc_id,@telefono,@mail,@fecha_nacimiento)
		END
	ELSE
		BEGIN
			THROW 50005,'ALERTA REGISTRO CLIENTE GEMELO',1
		END
END

drop procedure registrar_usuario_cliente
--------------------------------------------------------------

CREATE PROCEDURE registrar_usuario_proveedor(@username char(50),@razon_social char(50),@mail char(50),
											@telefono numeric(18,0),@cuit char(20),@rubro char(255),@nombre_contacto char(50),@Direccion char(100))									
AS BEGIN


DECLARE @direcc_id int
set @direcc_id = (select distinct id_direccion from DIRECCION where Direccion = @Direccion)

	IF NOT EXISTS(select * from PROVEEDORES where razon_social = @razon_social) and NOT EXISTS (select * from PROVEEDORES where cuit = @cuit)
		begin
	
			insert into PROVEEDORES(Razon_Social,username,mail,Telefono,Direccion,CUIT,Nombre_contacto)
			values(@razon_social,@username,@mail,@telefono,@direcc_id,@cuit,@nombre_contacto)

			insert into RUBROS(Proveedor_Id,Rubro_descripcion)
			(select proveedor_id,@rubro from PROVEEDORES where Razon_Social = @razon_social)
		end
	ELSE
		begin
			THROW 50004,'PROVEEDOR YA REGISTRADO',1
		end
END

--------------Registrar Domicilio-------------------------
CREATE PROCEDURE registrar_Domicilio(@Direccion char(100),@codigo_Postal numeric(4,0),@Localidad char(50)
									  ,@ciudad char(50),@nro_piso int,@Depto char(10))
AS BEGIN
	insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
			values(@Direccion,@codigo_Postal,@localidad,@ciudad,@nro_piso,@depto)
END


-------------MODIFICACION_PASSWORD------------------------

CREATE PROCEDURE modificar_password(@username char(50), @vieja_password char(50), @nueva_password char(50))
AS BEGIN
IF((select password from USUARIOS where username = @username) = @vieja_password )
		begin
			update USUARIOS
			set password = @nueva_password where username = @username
		end
ELSE
	begin
	THROW 50001, 'La contraseña actual ingresada es INCORRECTA', 1
	end
END


-------------BAJA_LOGICA_USUARIO--------------------------

CREATE PROCEDURE baja_usuario(@username char(50))
AS BEGIN
update USUARIOS
set Estado = 'Deshabilitado' where username = @username
END

------------HABILITACION_USUARIO---------------------------
CREATE PROCEDURE habilitacion_usuario(@username char(50))
AS BEGIN
update USUARIOS
set Estado = 'Habilitado' where username = @username
END

-------------VERIFICACION_LOGUEO--------------------
CREATE PROCEDURE verificar(@username char(50),@password char(50))
AS BEGIN
if not exists(select username,password from USUARIOS where Username = @username and Password = @password)
	begin
		THROW 50006, 'error de logueo. Usuario o Contraseña invalidos ', 1
	end
END


-------------VERIFICACION_ROL_Administrador--------
CREATE PROCEDURE verificar_rol_administrador(@username char(50))
as begin
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Administrador' and Username = @username)
	BEGIN
	THROW 50007, 'No es administrador ', 1
	END
end
-------------VERIFICACION_ROL_Cliente--------
CREATE PROCEDURE verificar_rol_cliente(@username char(50))
as begin
	BEGIN
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Cliente'and Username = @username)
	THROW 50008, 'No es Cliente ', 1
	END
end
-------------VERIFICACION_ROL_Proveedor--------
CREATE PROCEDURE verificar_rol_proveedor(@username char(50))
as begin
	BEGIN
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Proveedor'and Username = @username)
	THROW 50009, 'No es Proveedor ', 1
	END
end
