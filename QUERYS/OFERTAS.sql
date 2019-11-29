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

------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE comprar_oferta (@codigoOferta varchar(50),@precioLista varchar(20),@precio_oferta varchar(20),
								  @clienteUsuario varchar(50),@cantidadDisponible varchar(20), @cantidadMaxUsuario varchar(20))
AS BEGIN

DECLARE @oferta_id varchar(20) = (select oferta_id from OFERTAS where codigo=@codigoOferta)
DECLARE @cliente_id varchar(20)= (select cliente_id from CLIENTES where username = @clienteUsuario)

IF((Select Cantidad_disponible from OFERTAS where Oferta_Id = @oferta_id) < 1)
	throw 50004,'No hay oferta disponible',1
IF((select DineroDisponible from CLIENTES where Cliente_Id = @cliente_id) < cast(@precio_oferta as numeric(12,2)))
		throw 50001,'Dinero Insuficiente para realizar esta compra.',1
IF((select count(*) from compras where Cliente_Id = @cliente_id and Oferta_Id = @oferta_id) = cast(@cantidadMaxUsuario as int))
	throw 50002,'Cantidad Maxima de compras de esta oferta alcanzada',1
else
	begin
		insert into COMPRAS(Cliente_Id,Fecha_compra,Oferta_Id)
		values(@cliente_id,SYSDATETIME(),@oferta_id)

		declare @compra_id varchar(20) = (select top 1 compra_id from COMPRAS where Cliente_Id = @cliente_id and Oferta_Id = @oferta_id order by 1 desc)

		insert into CUPONES(Compra_Id,Oferta_Id)
		values(@compra_id,@oferta_id)
		
		update CLIENTES
		set DineroDisponible = DineroDisponible - cast(@precio_oferta as numeric(12,2))
		where Cliente_Id = @cliente_id

		Update OFERTAS
		set Cantidad_disponible = (Cantidad_disponible - 1)
		where Codigo = @codigoOferta
	end

END

drop procedure comprar_oferta


--------------------------------------------------------------------------------------------------------
CREATE PROCEDURE obtener_codigo (@proveedor_id varchar(20),@descripcion varchar(255),@precio_oferta numeric(12,2),@precio_lista numeric(12,2))
as begin
declare @codigo varchar(50) = (select top 1 codigo from OFERTAS where Proveedor_referenciado = @proveedor_id and Descripcion =@descripcion and Cantidad_disponible > 0
and Precio_lista=@precio_lista and Precio_oferta =@precio_oferta)
if exists(select 1 from OFERTAS where Codigo = @codigo)
throw 50001,@codigo,1
end


drop procedure obtener_codigo

