-------------CARGAR_SALDO---------------------
CREATE PROCEDURE cargar_saldo(@username varchar(50),@tarjeta_nro numeric(20),@cod_segu numeric(3),@tipo_pago varchar(20),@monto numeric(10,0),
							  @fecha varchar(10))
AS BEGIN

declare @fecha_convertida datetime
declare @cliente_ident varchar(17)

set @cliente_ident = (select cliente_id from CLIENTES where Username = @username)

set @fecha_convertida = cast(@fecha as datetime)

if ((select Cliente_Id from TARJETAS where Numero_Tarjeta = @tarjeta_nro) != @cliente_ident)
	begin
	throw 50006, 'Error tarjeta ya registrada',1
	end

if not exists(select Numero_Tarjeta from TARJETAS t where Numero_Tarjeta = @tarjeta_nro and Cliente_Id = @cliente_ident)
  begin
	if(@tipo_pago = 'Crédito')
		begin
			insert into TARJETAS(Cliente_Id,Numero_Tarjeta,Codigo_Seguridad,tipo_tarjeta)
			(select cliente_id,@tarjeta_nro,@cod_segu,'Credito' from CLIENTES where username = @username)
		end
	else
		begin
			insert into TARJETAS(Cliente_Id,Numero_Tarjeta,Codigo_Seguridad,tipo_tarjeta)
			(select cliente_id,@tarjeta_nro,@cod_segu,'Debito' from CLIENTES where username = @username)
		end
	end
	
	insert into CARGAS(Tarjeta_Id,Fecha,Monto,Tipo_Pago)
	(SELECT tarjeta_id,@fecha,@monto,@tipo_pago from TARJETAS where numero_tarjeta = @tarjeta_nro)

	update CLIENTES
	set DineroDisponible += @monto where username = @username

END

drop procedure cargar_saldo