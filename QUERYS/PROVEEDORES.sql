-----------------BAJA_LOGICA_PROVEEDOR-------------------------
CREATE PROCEDURE baja_logica_proveedor(@razon_social char(50))
AS BEGIN
	BEGIN try
	if((select Estado from PROVEEDORES where razon_social = @razon_social) = 'Habilitado')
		begin
			update PROVEEDORES
			set Estado = 'Inhabilitado' where razon_social = @razon_social
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Inhabilitado',1
		end
END TRY
BEGIN catch
	throw 50004, 'No existe el Proveedor',1;
END catch
END

-----------------HABILITAR_PROVEEDOR-----------------------------
CREATE PROCEDURE habilitar_proveedor(@razon_social char(50))
AS BEGIN
	BEGIN try
	if((select Estado from PROVEEDORES where razon_social = @razon_social) = 'Inhabilitado')
		begin
			update PROVEEDORES
			set Estado = 'Habilitado' where razon_social = @razon_social
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Habilitado',1
		end
END TRY
BEGIN catch
	throw 50004, 'No existe el Proveedor',1;
END catch
END
