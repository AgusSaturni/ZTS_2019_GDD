CREATE PROCEDURE deshabilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Habilitado')
		begin
			update ROLES 
				set Estado = 'Deshabilitado' where Rol_Id = @Rol_Id

			if (@Rol_Id = 'Cliente')
				begin
					update CLIENTES set Estado = 'Deshabilitado'
				end
			else if (@Rol_Id = 'Proveedor')
				begin
					update PROVEEDORES set Estado = 'Deshabilitado'
				end			
		end
	else
		begin
			throw 80000, 'El Rol ya esta Inhabilitado',1
		end
END

CREATE PROCEDURE habilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Deshabilitado')
		begin
			update ROLES 
				set Estado = 'Habilitado' where Rol_Id = @Rol_Id
		end
	else
		begin
			throw 80001, 'El Rol ya esta Habilitado',1
		end
END




--CREATE TRIGGER  deshabilitar_a_todos ON ROLES INSTEAD OF Update
--AS
--BEGIN
--	declare @Rol_Id varchar(255) = (select Rol_Id from inserted)
--	declare @Estado varchar(255) = (select Estado from inserted)

--	--Si el estado no es deshabiltiado, no hago el update, ya que si estoy haciendo una habilitacion
--	--me deshabilitaria todo

--	if (@Estado = 'Deshabilitado')
--	begin
--		if (@Rol_Id = 'Cliente')
--			begin
--				update CLIENTES set Estado = 'Deshabilitado'
--			end
--		else if (@Rol_Id = 'Proveedor')
--			begin
--				update PROVEEDORES set Estado = 'Deshabilitado'
--			end
--	END
--END

drop procedure deshabilitar_rol
--drop procedure habilitar_rol
--DROP TRIGGER deshabilitar_a_todos

--UPDATE CLIENTES SET Estado = 'Habilitado'
--UPDATE CLIENTES 

--SELECT * FROM PROVEEDORES

--SELECT * FROM CLIENTES
--select * from roles

--SELECT DISTINCT RPU.Rol_Id, F.Descripcion, R.Estado FROM ROLES_POR_USUARIO RPU 
--join FUNCIONES_POR_ROL FPR  
--on RPU.Rol_Id = FPR.Rol_Id 
--JOIN Funciones F on FPR.Funcion_Id = F.Funcion_Id
--JOIN ROLES R on R.Rol_Id = RPU.Rol_Id