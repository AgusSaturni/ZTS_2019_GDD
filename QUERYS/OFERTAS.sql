------------------CONFECCION_OFERTA-------------------
CREATE PROCEDURE confeccion_oferta(@precio_oferta numeric(18,2),@precio_lista numeric(18,2),@fecha_publicacion datetime,
								   @fecha_vencimiento datetime, @descripcion char(255),@cantidad_disponible numeric(18,0),
								   @codigo char(50),@proveedor_referenciado varchar(19))
AS BEGIN

		IF(@fecha_publicacion >= sysdatetime())
			begin
				insert into OFERTAS(precio_oferta,precio_lista,fecha_publicacion,fecha_vencimiento,Descripcion,
									cantidad_disponible,codigo,proveedor_referenciado)
				values(@precio_oferta,@precio_lista,@fecha_publicacion,@fecha_vencimiento,@descripcion,@cantidad_disponible
						,@codigo,@proveedor_referenciado)
			end
		ELSE
			begin
				throw 50005,'Fecha de publicacion antigua', 1
			end
	
END
