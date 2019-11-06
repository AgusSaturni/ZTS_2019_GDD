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

