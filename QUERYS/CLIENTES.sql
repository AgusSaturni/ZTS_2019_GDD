--------BAJA_LOGICA_CLIENTE-------------------------
drop procedure baja_logica_cliente
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
@mail varchar(255),@fecha varchar(255), @direccion varchar(255), @ciudad varchar(255) ,
@CP int = NULL, @Loc varchar(255) = NULL, @Npiso int = NULL, @depto varchar(255) = NULL)
AS BEGIN

	
	IF NOT EXISTS(SELECT 1 FROM CLIENTES WHERE @DNI = DNI AND username != @username)
	BEGIN
		update CLIENTES
		set
			Nombre = @nombre,
			Apellido = @apellido,
			DNI = @DNI,
			Telefono = @telefono,
			Mail = @mail,
			Fecha_Nacimiento = CONVERT(datetime,@fecha, 121)
		where username = @username
	END
	ELSE
	BEGIN
		THROW 50300, 'El DNI que desea ingresar, ya fue utilizado por otro cliente. Recuerde que es un campo Unico', 1
	END

	declare @direcID int = (select direccion from CLIENTES where username = @username)

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

			update CLIENTES
			set Direccion = @direcID_existente
			where username = @username				
		END
	ELSE
		BEGIN
		--SI NO EXISTE LA DIRECCION NUEVA EN EL SISTEMA, PERO HAY MAS DE 1 CLIENTE QUE TIENE MI DIRECCION ACTUAL, INSERTO LA NUEVA, TOMO EL ID NUEVO Y ME LO ASIGNO
			IF ( ((SELECT COUNT(1) FROM CLIENTES WHERE Direccion = @direcID) > 1) OR ((SELECT COUNT(1) FROM PROVEEDORES WHERE Direccion = @direcID) >= 1))
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

					update CLIENTES
						set Direccion = @direcc_id_nuevo
					where username = @username
			END
		ELSE
			BEGIN
			--SI NO EXISTE OTRO PROVEEDOR CON MI MISMA DIRECCION VIEJA, SIMPLEMENTE ACTUALIZO
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

drop procedure actualizar_cliente

----------Verificar si no es cliente
CREATE PROCEDURE verificar_si_no_es_cliente(@username varchar(255))
AS begin
if exists (select Rol_Id from ROLES_POR_USUARIO where Username = @username and Rol_Id = 'Administrador')
	throw 50005,'No es Cliente',1
end

drop procedure verificar_si_no_es_cliente


--CREATE PROCEDURE EJEMPLO(@valor varchar(255) = null)
--AS begin
--	update DIRECCION 
--		set 
--			Direccion = 'asd',
--			Ciudad = 'bsas',
--			Localidad = @valor
--		where Id_DIRECCION = '274'
--end

--drop procedure EJEMPLO
--select * from DIRECCION wHERE Id_Direccion = '274'

