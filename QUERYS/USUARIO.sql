--HACER ESTO PRIMERO--
drop procedure registrar_Domicilio
drop procedure registrar_usuario
drop procedure registrar_usuario_cliente
drop procedure registrar_usuario_proveedor
drop procedure verificar_usuario


------REGISTRO_USUARIO_Cliente------------
CREATE PROCEDURE registrar_usuario_cliente(@Username varchar(255), @Password varchar(255),@Rol varchar(255),@nombre varchar(255),@apellido varchar(255),@DNI numeric(18,0),@telefono numeric(18,0),@mail varchar(255),@fecha_nacimiento datetime,@Direccion varchar(255),@codigo_Postal numeric(4,0),@Localidad varchar(255)
									  ,@ciudad varchar(255),@nro_piso int,@Depto varchar(255))
AS BEGIN
	begin try
		begin transaction

			insert into USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
			values(@Direccion,@codigo_Postal,@localidad,@ciudad,@nro_piso,@depto)

			
			DECLARE @direcc_id int
			set @direcc_id = (select distinct id_direccion from DIRECCION where Direccion = @Direccion)


			insert into CLIENTES(Username,Nombre,Apellido,DNI,Direccion,Telefono,Mail,Fecha_Nacimiento)
			values(@username, @nombre,@apellido,@DNI,@direcc_id,@telefono,@mail,@fecha_nacimiento)	  
	
		commit transaction
	end try
	begin catch
			rollback transaction
	end catch
END

--------------------------------------------------------------

CREATE PROCEDURE registrar_usuario_proveedor(@Username varchar(255), @Password varchar(255),@Rol varchar(255),@Razon_social varchar(255),@Mail varchar(255),
											@Telefono numeric(18,0),@CUIT varchar(255),@Rubro varchar(255),@Nombre_contacto varchar(255),@Direccion varchar(255),@codigo_Postal numeric(4,0),@Localidad varchar(255)
									  ,@Ciudad varchar(255),@Nro_piso int,@Depto varchar(255))									
AS BEGIN
	begin try
		begin transaction

			insert into USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
			values(@Direccion,@codigo_Postal,@localidad,@ciudad,@nro_piso,@depto)
		

			DECLARE @direcc_id int
			set @direcc_id = (select distinct id_direccion from DIRECCION where Direccion = @Direccion)

		
			insert into PROVEEDORES(Razon_Social,username,mail,Telefono,Direccion,CUIT,Nombre_contacto)
			values(@razon_social,@username,@mail,@telefono,@direcc_id,@cuit,@nombre_contacto)

			insert into RUBROS(Proveedor_Id,Rubro_descripcion)
			(select proveedor_id,@rubro from PROVEEDORES where Razon_Social = @razon_social)
		
		commit transaction
	end try
	begin catch
			rollback transaction
	end catch

END


-------------MODIFICACION_PASSWORD--------HAY QUE RETOCAR----------------

CREATE PROCEDURE modificar_password(@username varchar(255), @vieja_password varchar(255), @nueva_password varchar(255))
AS BEGIN
IF not exists (select 1 from USUARIOS where Username = @username)
	throw 50002,'Usuario Inexistente',1
IF((select password from USUARIOS where username = @username) = HASHBYTES('SHA2_256',@vieja_password) )
		begin
			update USUARIOS
			set password =HASHBYTES('SHA2_256',@nueva_password)  where username = @username
		end
ELSE
	begin
	THROW 50001, 'La contraseña actual ingresada es INCORRECTA', 1
	end
END





-------------BAJA_LOGICA_USUARIO--------------------------
CREATE PROCEDURE baja_usuario(@username varchar(255))
AS BEGIN
update USUARIOS
set Estado = 'Deshabilitado' where username = @username
END



------------HABILITACION_USUARIO---------------------------
CREATE PROCEDURE habilitacion_usuario(@username varchar(255))
AS BEGIN
update USUARIOS
set Estado = 'Habilitado' where username = @username
END

------------INHABILITACION_USUARIO---------------------------
CREATE PROCEDURE inhabilitacion_usuario(@username varchar(255))
AS BEGIN
update USUARIOS
set Estado = 'Inhabilitado' where username = @username
END


-------------------Verificacion existencia usuario------------------
CREATE PROCEDURE verificar_existencia_de_usuario(@username varchar(255))
as begin
if exists(select 1 from USUARIOS where Username = RTRIM(@username))
	begin
		throw 50001,'Error, nombre de usuario ya existente. Elija otro.',1
	end
end


-----------------Verificacion existencia cliente gemelo--------------
CREATE PROCEDURE verificar_existencia_cliente_gemelo(@nombre varchar(255),@apellido varchar(255),@DNI numeric(18,0),@telefono numeric(18,0),@mail varchar(255),@fecha_nacimiento datetime)
as begin
	if exists(select 1 from CLIENTES where nombre=@nombre and Apellido = @apellido and DNI=@DNI and Telefono = @telefono and Mail=@mail and Fecha_Nacimiento =@fecha_nacimiento)
		OR EXISTS (select * from CLIENTES where DNI = @DNI)
		begin
			throw 50004,'Error, el cliente ya existe',1
		end
end

--------------------Verificacion existencia preveedor existente--------------------------------------NUEVO PROCEDUREEEEEEEEEEEEEEEEEEEEE

CREATE PROCEDURE verificar_existencia_proveedor_existente(@cuit varchar(255),@razon_social varchar(255))
as begin
	if exists(select 1 from PROVEEDORES where CUIT = @cuit)  OR exists(select 1 from PROVEEDORES where Razon_Social = @razon_social)
		begin
			throw 50004,'Error, el proveedor ya existe',1
		end
end

select * from PROVEEDORES
-------------VERIFICACION_LOGUEO--------------------

CREATE PROCEDURE verificar_usuario(@username varchar(255),@password varchar(255))
AS BEGIN
DECLARE @contraseña_encriptada char(255);
set @contraseña_encriptada = HASHBYTES('SHA2_256',(rtrim(@password)))
if exists(select 1 from USUARIOS where Username = @username and Estado = 'Inhabilitado')
		THROW 50007, 'Usuario Inhabilitado',1
if not exists(select 1 from USUARIOS where Username = @username and Password = @contraseña_encriptada)
		THROW 50006, 'Usuario y/o Contraseña Invalidos ', 1

END

drop procedure verificar_usuario

select * from ROLES


























--NO SE USAN
-------------VERIFICACION_ROL_Administrador--------
CREATE PROCEDURE verificar_rol_administrador(@username varchar(255))
as begin
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Administrador' and Username = @username)
	BEGIN
	THROW 50007, 'No es administrador ', 1
	END
end

-------------VERIFICACION_ROL_Cliente--------
CREATE PROCEDURE verificar_rol_cliente(@username varchar(255))
as begin
	BEGIN
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Cliente'and Username = @username)
	THROW 50008, 'No es Cliente ', 1
	END
end


-------------VERIFICACION_ROL_Proveedor--------
CREATE PROCEDURE verificar_rol_proveedor(@username varchar(255))
as begin
	BEGIN
	if not exists(select username from ROLES_POR_USUARIO where Rol_Id = 'Proveedor'and Username = @username)
	THROW 50009, 'No es Proveedor ', 1
	END
end

