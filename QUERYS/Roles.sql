CREATE PROCEDURE deshabilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Habilitado')
		begin
			update ROLES 
				set Estado = 'Inhabilitado' where Rol_Id = @Rol_Id

			if (@Rol_Id = 'Cliente')
				begin
					delete from ROLES_POR_USUARIO where Rol_Id = 'Cliente'
					update CLIENTES set Estado = 'Inhabilitado'
				end
			else if (@Rol_Id = 'Proveedor')
				begin
					delete from ROLES_POR_USUARIO where Rol_Id = 'Proveedor'
					update PROVEEDORES set Estado = 'Inhabilitado'
				end			
		end
	else
		begin
			throw 80000, 'El Rol ya esta Inhabilitado',1
		end
END

CREATE PROCEDURE habilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Inhabilitado')
		begin
			update ROLES 
				set Estado = 'Habilitado' where Rol_Id = @Rol_Id
		end
	else
		begin
			throw 80001, 'El Rol ya esta Habilitado',1
		end
END

CREATE PROCEDURE insertar_rol_por_usuario(@Rol_Id varchar(255), @username varchar(255))
AS BEGIN
	--No verifico existencia ya que este procedure se utiliza para cunado creas un usuario.
	--Por lo tanto, ya previamente se verifica si el usuario no existe.
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Habilitado')
		insert into ROLES_POR_USUARIO values (@Rol_Id, @username)
END

drop procedure habilitar_rol

select * from roles
