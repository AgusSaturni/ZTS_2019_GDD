CREATE PROCEDURE confeccion_oferta(@descripcion varchar(255),@fecha_publicacion datetime,
								   @fecha_vencimiento datetime,@precio_oferta numeric(18,2),@precio_lista numeric(18,2),@cantidad_disponible numeric(18,0),@cantidad_maxima_por_usuario int,
								   @codigo varchar(50),@proveedor_referenciado varchar(50))
AS BEGIN

declare @proveedor_id varchar(19) = (select proveedor_id from PROVEEDORES where username = @proveedor_referenciado)

		if not exists(select 1 from PROVEEDORES where username = @proveedor_referenciado)
			throw 50002,'No existe ese proveedor',1
		IF(@fecha_publicacion >= sysdatetime() and @fecha_vencimiento >= SYSDATETIME())
			begin
				insert into OFERTAS(precio_oferta,precio_lista,fecha_publicacion,fecha_vencimiento,Descripcion,
									cantidad_disponible,cantidad_maxima_por_usuario,codigo,proveedor_referenciado)
				values(@precio_oferta,@precio_lista,@fecha_publicacion,@fecha_vencimiento,@descripcion,@cantidad_disponible,@cantidad_maxima_por_usuario
						,@codigo,@proveedor_id)
			end
		ELSE
			begin
				throw 50005,'Fecha invalida', 1
			end
	
END

