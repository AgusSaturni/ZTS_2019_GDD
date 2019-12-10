CREATE PROCEDURE confeccion_oferta(@descripcion varchar(255),@fecha_publicacion datetime,
								   @fecha_vencimiento datetime,@precio_oferta numeric(18,2),@precio_lista numeric(18,2),@cantidad_disponible numeric(18,0),@cantidad_maxima_por_usuario int,
								   @codigo varchar(50),@proveedor_referenciado varchar(255))
AS BEGIN

	IF EXISTS(SELECT 1 FROM PROVEEDORES WHERE username = @proveedor_referenciado)
	BEGIN
		
		DECLARE @ID VARCHAR(50) = (SELECT Proveedor_Id FROM PROVEEDORES WHERE username = @proveedor_referenciado)
		
		insert into OFERTAS(precio_oferta,precio_lista,fecha_publicacion,fecha_vencimiento,Descripcion,
						cantidad_disponible,cantidad_maxima_por_usuario,Codigo_Oferta,proveedor_referenciado)
		values(
		@precio_oferta,
		@precio_lista,
		convert(datetime,@fecha_publicacion,121),
		convert(datetime,@fecha_vencimiento,121),
		@descripcion,
		@cantidad_disponible,
		@cantidad_maxima_por_usuario,
		@codigo,
		@ID)
	END
	ELSE
	BEGIN
		throw 100000,'El proveedor ingresado no existe', 1
	END


END

drop procedure confeccion_oferta

------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE comprar_oferta (@codigoOferta varchar(50),@precioLista numeric(12,2),@precio_oferta numeric(12,2),
								  @clienteUsuario varchar(50),@cantidadDisponible int,@cantidadCompra int, @cantidadMaxUsuario int)
AS BEGIN
DECLARE @cliente_id varchar(20)= (select cliente_id from CLIENTES where username = @clienteUsuario)
if(@cantidadCompra = 0)
			throw 50004,'Debe seleccionar la cantidad de Ofertas que desea comprar.',1
IF(@cantidadCompra > @cantidadDisponible)
	throw 50001,'La cantidad de ofertas que desea adquirir es mayor a la Disponible.',1

	insert into COMPRAS(Cliente_Id,Codigo_oferta,Fecha_compra,Cantidad)
	values(@cliente_id,@codigoOferta,SYSDATETIME(),@cantidadCompra)


END

drop procedure comprar_oferta


-----------------------------TRIGGER PARA COMPRAS------------------------
CREATE TRIGGER trigger_compras
ON COMPRAS
INSTEAD OF insert
as begin
declare @cliente_id varchar(20) = (select cliente_id from INSERTED)
declare @codigoOferta varchar(50) = (select codigo_Oferta from INSERTED)
declare @cantidadCompra int = (select Cantidad from inserted)

IF(select count(*) from COMPRAS where Cliente_Id = @cliente_id and Codigo_oferta = @codigoOferta) <
	(select cantidad_maxima_por_usuario from OFERTAS where Codigo_Oferta = @codigoOferta)
begin
	begin transaction
		insert into COMPRAS(Cliente_Id,Codigo_oferta,Fecha_compra,Cantidad)
		values(@cliente_id,@codigoOferta,SYSDATETIME(),@cantidadCompra)

		declare @compra_id varchar(20) = (select top 1 compra_id from compras order by 1 desc)

		insert into CUPONES(Codigo_cupon,Codigo_oferta,Compra_Id)
		values(newid(),@codigoOferta,@compra_id)

		update OFERTAS
		set Cantidad_disponible = Cantidad_disponible - @cantidadCompra
		where Codigo_Oferta = @codigoOferta

		update CLIENTES
		set DineroDisponible = DineroDisponible - (select precio_oferta from OFERTAS where Codigo_Oferta = @codigoOferta)
		where Cliente_Id = @cliente_id
	commit transaction
	end
	else
		throw 50002,'Usted alcanzó la cantidad máxima de compras posibles de esta Oferta.',1
		
end



drop trigger trigger_compras



--------------------------------------------------------------------------------------------------------
CREATE PROCEDURE obtener_codigo (@proveedor_id varchar(20),@descripcion varchar(255),@precio_oferta numeric(12,2),@precio_lista numeric(12,2))
as begin
declare @codigo varchar(50) = (select top 1 Codigo_Oferta from OFERTAS where Proveedor_referenciado = @proveedor_id and Descripcion =@descripcion and Cantidad_disponible > 0
and Precio_lista=@precio_lista and Precio_oferta =@precio_oferta)
if exists(select 1 from OFERTAS where Codigo_Oferta= @codigo)
throw 50001,@codigo,1
end

drop procedure obtener_codigo


------------------CONSUMO_OFERTA auxiliares------------------
CREATE PROCEDURE oferta_existente (@ofertaCodigo varchar(255))
AS BEGIN
IF not exists (SELECT 1 FROM OFERTAS WHERE Codigo_Oferta = @ofertaCodigo)
	BEGIN
		THROW 90001,'La oferta ingresada no es correcta.',1
	END
END

drop procedure oferta_existente

CREATE PROCEDURE oferta_disponible (@cuponId varchar(255), @ofertaFecha datetime) --La fecha de vencimiento todavia esta disponible
AS BEGIN
	DECLARE @ofertaCodigo VARCHAR(255)
	SET @ofertaCodigo = (SELECT Codigo_oferta FROM CUPONES WHERE Cupon_Id = @cuponId)
	IF not exists (SELECT 1 FROM OFERTAS
	WHERE convert(datetime,@ofertaFecha,121) between Fecha_publicacion and Fecha_Vencimiento and Codigo_Oferta = @ofertaCodigo)
		BEGIN
			THROW 90002,'La oferta se ha Vencido. No se puede canjear el cupon.',1
		END
END

drop procedure oferta_disponible

CREATE PROCEDURE verificar_proveedor (@cuponId varchar(255), @proveedor varchar(255))
AS BEGIN
	DECLARE @proveedorId VARCHAR(255)
	SET @proveedorId = (SELECT Proveedor_Id FROM PROVEEDORES WHERE username = @proveedor)
	IF not exists (SELECT 1 FROM CUPONES c 
					JOIN OFERTAS o ON o.Codigo_Oferta = c.Codigo_oferta
					WHERE @cuponId = c.Cupon_Id
					AND @proveedorId = o.Proveedor_referenciado)
	BEGIN
		THROW 90003,'Este cupon no le pertenece.',1
	END
END

drop procedure verificar_proveedor

CREATE PROCEDURE utilizar_cupon(@cuponId varchar(255), @fecha datetime)
AS BEGIN
	UPDATE CUPONES SET Fecha_Consumo = @fecha
	WHERE Cupon_Id = @cuponId
END


drop procedure utilizar_cupon

CREATE PROCEDURE cupon_utilizado(@cuponId varchar(255))
AS BEGIN
IF (SELECT count(1) from CUPONES where Cupon_Id = @cuponId AND Fecha_Consumo IS NOT NULL)>0
	BEGIN
		THROW 90003,'El cupon ya fue utilizado.',1
	END
END


drop procedure cupon_utilizado
-------------------------------------------------
-------------------------------------------------

--NO LAS USO MAS
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


drop procedure cupon_cliente

CREATE PROCEDURE cupon_existente (@cuponId varchar(255))
AS BEGIN
IF not exists (SELECT 1 FROM CUPONES WHERE Cupon_Id = @cuponId)
	BEGIN
		THROW 90001,'El cupon ingresado no es correcto.',1
	END
END


drop procedure cupon_existente