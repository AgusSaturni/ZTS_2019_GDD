--------BAJA_LOGICA_CLIENTE--------------------------
CREATE PROCEDURE baja_logica_cliente(@DNI_CLIENTE numeric(18,0))
AS BEGIN
BEGIN try
	if((select Estado from CLIENTES where dni = @DNI_CLIENTE) = 'Habilitado')
		begin
			update CLIENTES
			set Estado = 'Inhabilitado' where DNI =@DNI_CLIENTE
		end
	else
		begin
			throw 50003, 'El cliente ya esta Inhabilitado',1
		end
END TRY
BEGIN catch
	throw 50004, 'No existe el Cliente',1;
END catch
END

---------HABILITAR_CLIENTE----------------------------
CREATE PROCEDURE habilitar_cliente(@DNI_CLIENTE numeric(18,0))
AS BEGIN
BEGIN try
	if((select Estado from CLIENTES where dni = @DNI_CLIENTE) = 'Habilitado')
		begin
			update CLIENTES
			set Estado = 'Inhabilitado' where DNI =@DNI_CLIENTE
		end
	else
		begin
			throw 50003, 'El cliente ya esta Inhabilitado',1
		end
END TRY
BEGIN catch
	throw 50004, 'No existe el Cliente',1;
END catch
END
