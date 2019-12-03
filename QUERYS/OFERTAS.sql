CREATE PROCEDURE confeccion_oferta(@descripcion varchar(255),@fecha_publicacion datetime,
								   @fecha_vencimiento datetime,@precio_oferta numeric(18,2),@precio_lista numeric(18,2),@cantidad_disponible numeric(18,0),@cantidad_maxima_por_usuario int,
								   @codigo varchar(50),@proveedor_referenciado varchar(50))
AS BEGIN

declare @proveedor_id varchar(50) = (select Proveedor_Id from PROVEEDORES where username = @proveedor_referenciado)

		if not exists(select 1 from PROVEEDORES where username = @proveedor_referenciado)
			throw 50002,'No existe ese proveedor',1
		IF(@fecha_publicacion >= sysdatetime() and @fecha_vencimiento >= SYSDATETIME())
			begin
				insert into OFERTAS(precio_oferta,precio_lista,fecha_publicacion,fecha_vencimiento,Descripcion,
									cantidad_disponible,cantidad_maxima_por_usuario,Codigo_Oferta,proveedor_referenciado)
				values(@precio_oferta,@precio_lista,@fecha_publicacion,@fecha_vencimiento,@descripcion,@cantidad_disponible,@cantidad_maxima_por_usuario
						,@codigo,@proveedor_id)
			end
		ELSE
			begin
				throw 50005,'Fecha invalida', 1
			end
	
END

drop procedure confeccion_oferta


------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE comprar_oferta (@codigoOferta varchar(50),@precioLista varchar(20),@precio_oferta varchar(20),
								  @clienteUsuario varchar(50),@cantidadDisponible varchar(20), @cantidadMaxUsuario varchar(20))
AS BEGIN


DECLARE @cliente_id varchar(20)= (select cliente_id from CLIENTES where username = @clienteUsuario)

IF((Select Cantidad_disponible from OFERTAS where Codigo_Oferta = @codigoOferta) < 1)
	throw 50004,'No hay oferta disponible',1
IF((select DineroDisponible from CLIENTES where Cliente_Id = @cliente_id) < cast(@precio_oferta as numeric(12,2)))
		throw 50001,'Dinero Insuficiente para realizar esta compra.',1
IF((select count(*) from compras where Cliente_Id = @cliente_id and Codigo_oferta = @codigoOferta) = cast(@cantidadMaxUsuario as int))
	throw 50002,'Cantidad Maxima de compras de esta oferta alcanzada',1
else
	begin
		insert into COMPRAS(Cliente_Id,Fecha_compra,Codigo_oferta)
		values(@cliente_id,SYSDATETIME(),@codigoOferta)

		declare @compra_id varchar(20) = (select top 1 Compra_Id from COMPRAS where Cliente_Id = @cliente_id and Codigo_oferta = @codigoOferta order by 1 desc)

		insert into CUPONES(Compra_Id,Codigo_oferta)
		values(@compra_id,@codigoOferta)
		
		update CLIENTES
		set DineroDisponible = DineroDisponible - cast(@precio_oferta as numeric(12,2))
		where Cliente_Id = @cliente_id

		Update OFERTAS
		set Cantidad_disponible = (Cantidad_disponible - 1)
		where Codigo_Oferta = @codigoOferta

		
	end

END




--------------------------------------------------------------------------------------------------------
CREATE PROCEDURE obtener_codigo (@proveedor_id varchar(20),@descripcion varchar(255),@precio_oferta numeric(12,2),@precio_lista numeric(12,2))
as begin
declare @codigo varchar(50) = (select top 1 Codigo_Oferta from OFERTAS where Proveedor_referenciado = @proveedor_id and Descripcion =@descripcion and Cantidad_disponible > 0
and Precio_lista=@precio_lista and Precio_oferta =@precio_oferta)
if exists(select 1 from OFERTAS where Codigo_Oferta= @codigo)
throw 50001,@codigo,1
end



------------------CONSUMO_OFERTA auxiliares------------------
CREATE PROCEDURE oferta_existente (@ofertaCodigo varchar(255))
AS BEGIN
IF not exists (SELECT * FROM OFERTAS WHERE Codigo_Oferta = @ofertaCodigo)
	BEGIN
		THROW 90001,'La oferta ingresada no es correcta.',1
	END
END



CREATE PROCEDURE cupon_existente (@cuponId varchar(255))
AS BEGIN
IF not exists (SELECT * FROM CUPONES WHERE Cupon_Id = @cuponId)
	BEGIN
		THROW 90001,'El cupon ingresado no es correcto.',1
	END
END


CREATE PROCEDURE oferta_disponible (@cuponId varchar(255), @ofertaFecha datetime) --La fecha de vencimiento todavia esta disponible
AS BEGIN
	DECLARE @ofertaCodigo VARCHAR(255)
	SET @ofertaCodigo = (SELECT Codigo_oferta FROM CUPONES WHERE Cupon_Id = @cuponId)
	IF not exists (SELECT * FROM OFERTAS
	WHERE @ofertaFecha between Fecha_publicacion and Fecha_Vencimiento)
		BEGIN
			THROW 90002,'La oferta no esta disponible en esta fecha.',1
		END
END


CREATE PROCEDURE verificar_proveedor (@cuponId varchar(255), @proveedor varchar(255))
AS BEGIN
	DECLARE @proveedorId VARCHAR(255)
	SET @proveedorId = (SELECT Proveedor_Id FROM PROVEEDORES WHERE username = @proveedor)
	IF not exists (SELECT * FROM CUPONES c 
					JOIN OFERTAS o ON o.Codigo_Oferta = c.Codigo_oferta
					WHERE @cuponId = c.Cupon_Id
					AND @proveedorId = o.Proveedor_referenciado)
	BEGIN
		THROW 90003,'El proveedor no es el indicado.',1
	END
END



CREATE PROCEDURE cupon_cliente (@cuponId varchar(255), @cliente varchar(255))
AS BEGIN
	IF not exists (select 1 from CUPONES cup
					JOIN COMPRAS com ON com.Compra_Id = cup.Compra_Id
					WHERE @cuponId = cup.Cupon_Id
					AND @cliente = com.Cliente_Id)

	--IF (select COUNT(*) from CUPONES cup
	--				JOIN COMPRAS com ON com.Compra_Id = cup.Compra_Id
	--				WHERE @cuponId = cup.Cupon_Id
	--				AND @cliente = com.Cliente_Id)>0

	BEGIN
		THROW 90003,'El cupon no le pertenece al cliente.',1
	END
END


CREATE PROCEDURE cupon_utilizado(@cuponId varchar(255))
AS BEGIN
--IF exists (SELECT * from CUPONES where Cupon_Id = @cuponId AND Fecha_Consumo IS NOT NULL)
IF (SELECT count(*) from CUPONES where Cupon_Id = @cuponId AND Fecha_Consumo IS NOT NULL)>0
	BEGIN
		THROW 90003,'El cupon ya fue utilizado.',1
	END
END



CREATE PROCEDURE utilizar_cupon(@cuponId varchar(255), @fecha datetime)
AS BEGIN
	UPDATE CUPONES SET Fecha_Consumo = @fecha
	WHERE Cupon_Id = @cuponId
END
