-----------------LISTADO ESTADISTICO----------------------
CREATE PROCEDURE verificar_Semestre (@fecha1 datetime, @fecha2 datetime)
AS BEGIN
declare @fecha1MOD datetime = CONVERT(datetime,@fecha1, 121)
declare @fecha2MOD datetime = CONVERT(datetime,@fecha2, 121)
IF NOT((SUM(DATEDIFF(DAY,@fecha1MOD,@fecha2MOD) + 1)) between 181 and 184)
	throw 50001,'Las fechas ingresadas no corresponden a un semestre',1
END

drop procedure verificar_Semestre

-------------------Funcion para suma de porcentajes-----------------------------------------

create function suma_porcentajes_de_ofertas(@proveedor varchar(20),@fecha1 datetime,@fecha2 datetime)
returns numeric(10,2)
as begin
declare @porcentaje numeric(10,2)

set @porcentaje = (select sum( 100 - (precio_oferta * 100 / precio_lista)) from OFERTAS where Proveedor_referenciado = @proveedor and Fecha_publicacion
between CONVERT(datetime,@fecha1,121) and  CONVERT(datetime,@fecha2, 121))
return @porcentaje
end

drop function dbo.suma_porcentajes_de_ofertas

--------------------Funcion para suma de facturacion de proveedores------------------------------


create function suma_facturacion_proveedor(@proveedor varchar(20),@fecha1 datetime,@fecha2 datetime)
returns numeric(10,2)
as begin
declare @facturacionTotal numeric(10,2)

set @facturacionTotal = (select  sum(Precio_oferta * cantidad) from COMPRAS   c join OFERTAS o on  c.Codigo_oferta = o.Codigo_Oferta
where Fecha_compra  between CONVERT(datetime,@fecha1,121)  and  CONVERT(datetime,@fecha2, 121) and Factura_Id is not null 
and o.Proveedor_referenciado = @proveedor)

return @facturacionTotal

end

