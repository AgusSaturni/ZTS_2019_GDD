/*
drop procedure baja_usuario
drop procedure habilitacion_usuario
drop procedure inhabilitacion_usuario
drop procedure verificar_password
drop procedure verificar_usuario
drop procedure baja_usuario
drop procedure habilitacion_usuario
drop procedure inhabilitacion_usuario
drop procedure modificar_password
drop procedure registrar_usuario_cliente
drop procedure registrar_usuario_proveedor
drop procedure verificar_usuario
*/


------REGISTRO_USUARIO_Cliente------------
CREATE PROCEDURE registrar_usuario_cliente(@Username varchar(255), @Password varchar(255),@Rol varchar(255),
										@nombre varchar(255),@apellido varchar(255),@DNI numeric(18,0),@telefono numeric(18,0),
										@mail varchar(255),@fecha_nacimiento datetime,@Direccion varchar(255),@ciudad varchar(255),
										@CP numeric(4,0) = null ,@Loc varchar(255) = null ,@NPiso int = null ,@depto varchar(255) = null)
AS BEGIN
	begin try
		begin transaction

			insert into USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			IF NOT EXISTS(SELECT 1 FROM DIRECCION WHERE Direccion = @Direccion and Ciudad = @Ciudad AND
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)
			begin
					insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			end

			DECLARE @direcc_id int
			set @direcc_id = (select id_direccion from DIRECCION 
			where Direccion = @Direccion and Ciudad = @ciudad and
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)

			insert into CLIENTES(Username,Nombre,Apellido,DNI,Direccion,Telefono,Mail,Fecha_Nacimiento,DineroDisponible)
			values(@username, @nombre,@apellido,@DNI,@direcc_id,@telefono,@mail,@fecha_nacimiento,200)	  
	
			commit transaction
	end try
	begin catch
			rollback transaction
	end catch
END

drop procedure registrar_usuario_cliente

--------------------------------------------------------------

CREATE PROCEDURE registrar_usuario_proveedor(@Username varchar(255), @Password varchar(255),@Rol varchar(255),
											@Razon_social varchar(255),@Mail varchar(255),
											@Telefono numeric(18,0),@CUIT varchar(255),@Rubro varchar(255),
											@Nombre_contacto varchar(255) = NULL,@Direccion varchar(255),
											@Ciudad varchar(255),@CP numeric(4,0) = NULL ,@Loc varchar(255) = NULL,
											@NPiso int = NULL,@depto varchar(255) = NULL)									
AS BEGIN
	begin try
		begin transaction

			insert into USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			IF NOT EXISTS(SELECT 1 FROM DIRECCION WHERE Direccion = @Direccion and Ciudad = @Ciudad AND
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)
			begin
					insert into DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			end

			DECLARE @direcc_id int
			set @direcc_id = (select id_direccion from DIRECCION
			where Direccion = @Direccion and  Ciudad = @ciudad and
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)

			IF NOT EXISTS(SELECT 1 FROM RUBROS WHERE rubro_descripcion = @Rubro)
			BEGIN
				insert into RUBROS(Rubro_descripcion) values (@Rubro)
			END

			declare @rubro_id varchar(15)
			set @rubro_id = (select Rubro_Id from RUBROS where rubro_descripcion = @Rubro)

			insert into PROVEEDORES(Razon_Social,username,mail,Telefono,Direccion,CUIT,Nombre_contacto,Rubro_Id)
			values(@razon_social,@username,@mail,@telefono,@direcc_id,@cuit,@nombre_contacto,@rubro_id)

			commit transaction
	end try
	begin catch
			rollback transaction
	end catch
END

drop procedure registrar_usuario_proveedor

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

drop procedure baja_usuario
drop procedure habilitacion_usuario
drop procedure inhabilitacion_usuario

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
		OR EXISTS (select 1 from CLIENTES where DNI = @DNI)
		begin
			throw 50004,'Error, el cliente ya existe',1
		end
end

drop procedure verificar_existencia_cliente_gemelo

--------------------Verificacion existencia preveedor existente--------------------------------------NUEVO PROCEDUREEEEEEEEEEEEEEEEEEEEE

CREATE PROCEDURE verificar_existencia_proveedor_gemelo(@cuit varchar(255),@razon_social varchar(255))
as begin
	if exists(select 1 from PROVEEDORES where CUIT = @cuit)  OR exists(select 1 from PROVEEDORES where Razon_Social = @razon_social)
		begin
			throw 50004,'Error, el proveedor ya existe',1
		end
end


-------------VERIFICACION_LOGUEO--------------------

CREATE PROCEDURE verificar_usuario(@username varchar(255))
AS BEGIN
if not exists(select 1 from USUARIOS where Username = @username)
		THROW 50006, 'El Usuario que desea ingresar no esta registrado en el sistema. ', 1
END

CREATE PROCEDURE verificar_password(@username varchar(255),@password varchar(255))
AS BEGIN
DECLARE @contraseña_encriptada char(255);
set @contraseña_encriptada = HASHBYTES('SHA2_256',(rtrim(@password)))
if exists(select 1 from USUARIOS where Username = @username and Password = @contraseña_encriptada and Estado = 'Inhabilitado')
		THROW 50007, 'El Usuario con el que intenta ingresar al sistema esta Inhabilitado',1
if not exists(select 1 from USUARIOS where Username = @username and Password = @contraseña_encriptada)
		THROW 50006, 'La contraseña ingresada es incorrecta. Pruebe de nuevo. ', 1
END






















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

