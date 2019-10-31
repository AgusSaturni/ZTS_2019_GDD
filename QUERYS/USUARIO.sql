
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
CREATE PROCEDURE registrar_usuario_cliente(@nombre char(20),@apellido char(20),@DNI numeric(18,0),@telefono numeric(18,0),@mail char(50),@fecha_nacimiento datetime,
											@Direccion char(100))

AS BEGIN
	IF NOT EXISTS(select nombre,apellido,DNI,telefono,mail,fecha_nacimiento from CLIENTES where dni=@DNI)
		BEGIN
		
			insert into CLIENTES(Nombre,Apellido,DNI,Direccion,Telefono,Mail,Fecha_Nacimiento)
			values(@nombre,@apellido,@DNI,@Direccion,@telefono,@mail,@fecha_nacimiento)
		END
	ELSE
		BEGIN
			THROW 50005,'ALERTA REGISTRO CLIENTE GEMELO',1
		END
END


--------------------------------------------------------------

CREATE PROCEDURE registrar_usuario_proveedor(@razon_social char(50),@mail char(50),
											@telefono numeric(18,0),@cuit char(20),@rubro char(255),@nombre_contacto char(50),@Direccion char(100))									
AS BEGIN
	IF NOT EXISTS(select * from PROVEEDORES where razon_social = @razon_social) and NOT EXISTS (select * from PROVEEDORES where cuit = @cuit)
		begin
	
			insert into PROVEEDORES(Razon_Social,mail,Telefono,Direccion,CUIT,Nombre_contacto)
			values(@razon_social,@mail,@telefono,@Direccion,@cuit,@nombre_contacto)

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
execute registrar_Domicilio 'lobos',4535,'Nueos','Buenos',12,'asdd'

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
