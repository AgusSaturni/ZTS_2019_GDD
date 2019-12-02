DROP PROCEDURE persistir_carga
drop trigger ACTUALIZACION_MONTO_CLIENTE

-------------CARGAR_SALDO---------------------
CREATE PROCEDURE persistir_carga(@username varchar(255),@tarjeta_nro numeric(20),@cod_segu numeric(3),@tipo_tarj varchar(20),@monto numeric(10,0),
							  @fecha varchar(10))
AS BEGIN
	--Solo puede existir una tarjeta con igual numero y codigo de seguridad
	IF EXISTS(SELECT 1 FROM TARJETAS WHERE (Numero_Tarjeta = @tarjeta_nro and Codigo_Seguridad != @cod_segu) OR (Numero_Tarjeta = @tarjeta_nro and tipo_Tarjeta != @tipo_tarj) )
	BEGIN
		throw 50006, 'Los datos ingresados no coinciden con la Tarjeta registrada',1
	END

	IF NOT EXISTS(SELECT 1 FROM TARJETAS WHERE Numero_Tarjeta = @tarjeta_nro)
	BEGIN
		INSERT INTO TARJETAS (Numero_Tarjeta, Codigo_Seguridad, tipo_Tarjeta) values (@tarjeta_nro, @cod_segu, @tipo_tarj)
	END


	declare @Tarjeta_ID varchar(17) = (select Tarjeta_Id from TARJETAS where numero_tarjeta = @tarjeta_nro and codigo_seguridad = @cod_segu)
	declare @Cliente_ID varchar(17) = (select Cliente_Id from CLIENTES where username = @username)
	declare @fecha_convertida datetime = (cast(@fecha as datetime))


	INSERT INTO CARGAS (Cliente_Id, Tarjeta_Id, Fecha, Monto) values (@Cliente_ID, @Tarjeta_ID, @fecha_convertida, @monto)

END


CREATE TRIGGER ACTUALIZACION_MONTO_CLIENTE ON CARGAS AFTER INSERT
AS
BEGIN	

	DECLARE @Cliente_ID varchar(17) = (SELECT Cliente_Id from inserted);
	DECLARE @Monto numeric(10,0) = (SELECT Monto from inserted);

	UPDATE CLIENTES
		SET DineroDisponible += @Monto
		where Cliente_Id = @Cliente_ID

END
GO

