use GD2C2019;


IF NOT EXISTS (select * from sys.schemas where name = 'ZTS_DB')
BEGIN
EXEC('create schema ZTS_DB')
END;
GO

---------------------------TABLA DIRECCIONES-----------------------------------
IF NOT EXISTS (select * from sysobjects where name='DIRECCION' and xtype='U')
CREATE TABLE ZTS_DB.DIRECCION
(
	Id_Direccion INT IDENTITY(0,1) PRIMARY KEY not null,
    Direccion varchar(255) not null,
    Codigo_Postal int ,
    Localidad varchar(255),
    Ciudad varchar(255) not null,
    Numero_Piso int,
    Depto varchar(255)
)
GO

-----MIGRACION DE DIRECCIONES----------------------------
insert into ZTS_DB.direccion(Direccion,Ciudad)
SELECT DISTINCT Cli_Direccion,Cli_Ciudad FROM gd_esquema.Maestra

insert into ZTS_DB.direccion(Direccion,Ciudad)
SELECT DISTINCT Provee_Dom,Provee_Ciudad FROM gd_esquema.Maestra where Provee_Ciudad is not null

-------------------------------------------------------------------------------

---------------------------TABLA USUARIOS--------------------------------------
IF NOT EXISTS (select * from sysobjects where name='USUARIOS' and xtype='U')
CREATE TABLE ZTS_DB.USUARIOS
( Username varchar(255) not null,
  Password	varchar(255) not null,
  Estado varchar(255) default 'Habilitado'
  PRIMARY KEY(Username)
)
GO
select * from zts_db.proveedores
insert into ZTS_DB.USUARIOS (username,Password) values ('ADMIN',HASHBYTES('SHA2_256','w23e'))

-------------------------------------------------------------------------------

---------------------------TABLA CLIENTES--------------------------------------

IF NOT EXISTS (select * from sysobjects where name='CLIENTES' and xtype='U')
CREATE TABLE ZTS_DB.CLIENTES
( Indice INT IDENTITY(1,1) NOT NULL ,
  Cliente_Id AS 'ClienteID' +  CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  username varchar(255) default null,
  Nombre varchar(255) not null,
  Apellido varchar(255) not null,
  DNI numeric(18,0) not null,
  Direccion int,
  Telefono numeric(18,0),
  Mail	varchar(255),			
  Fecha_Nacimiento datetime,
  DineroDisponible int default 200,
  Estado varchar(255) default 'Habilitado'
  PRIMARY KEY(CLIENTE_Id),
  FOREIGN KEY(Direccion) REFERENCES ZTS_DB.Direccion(Id_Direccion),
  FOREIGN KEY(username) REFERENCES ZTS_DB.USUARIOS(username),
)
GO

-----MIGRACION DE CLIENTES----------------------------
INSERT INTO ZTS_DB.CLIENTES (Nombre, Apellido,DNI,direccion,Telefono,Mail,Fecha_Nacimiento)
(SELECT DISTINCT Cli_Nombre, Cli_apellido,Cli_Dni,
(SELECT Id_direccion from ZTS_DB.DIRECCION where Direccion = Cli_Direccion),
Cli_Telefono,Cli_Mail,Cli_Fecha_Nac from gd_esquema.Maestra )

insert into ZTS_DB.USUARIOS (Username, Password) 
(select  Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3)), HASHBYTES('SHA2_256',(cast(dni as varchar))) from ZTS_DB.CLIENTES)

update ZTS_DB.CLIENTES 
set username = B.username from ZTS_DB.CLIENTES as A,ZTS_DB.USUARIOS as B where B.Username = Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3))

-------------------------------------------------------------------------------

---------------------------TABLA RUBROS----------------------------------------
IF NOT EXISTS (select * from sysobjects where name='RUBROS' and xtype='U')
CREATE TABLE ZTS_DB.RUBROS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Rubro_Id AS 'RubroID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	rubro_descripcion varchar(255)
	PRIMARY KEY(Rubro_Id),
)
GO
-----MIGRACION DE RUBROS----------------------------
INSERT INTO ZTS_DB.RUBROS (rubro_descripcion)
(SELECT DISTINCT Provee_Rubro from gd_esquema.Maestra where Provee_Rubro is not null)

-------------------------------------------------------------------------------

---------------------------TABLA DE PROVEEDORES--------------------------------

IF NOT EXISTS (select * from sysobjects where name='PROVEEDORES' and xtype='U')
CREATE TABLE ZTS_DB.PROVEEDORES
(	Indice INT IDENTITY(1,1) NOT NULL,
	Proveedor_Id AS 'ProveedorID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Razon_Social varchar(255) unique not null,
	username varchar(255) default null,
	Rubro_Id varchar(15) not null,
	Direccion int,
	Telefono numeric(18,0),
	CUIT varchar(255) unique not null,	
	Mail varchar(255),
	Nombre_contacto varchar(255),
	Estado varchar(255) default 'Habilitado',
	PRIMARY KEY(Proveedor_Id),
	FOREIGN KEY(Direccion) REFERENCES ZTS_DB.Direccion(id_direccion),
	FOREIGN KEY(Rubro_Id) REFERENCES ZTS_DB.RUBROS(Rubro_Id)
)
GO

-----MIGRACION DE PROVEEDORES-------------------------

INSERT INTO ZTS_DB.PROVEEDORES
(Razon_Social,Direccion,Telefono,CUIT, Rubro_Id)
(select distinct Provee_RS,(SELECT Id_direccion from ZTS_DB.DIRECCION where Direccion = Provee_Dom),
Provee_Telefono,
Provee_CUIT,
(select Rubro_Id from ZTS_DB.RUBROS where rubro_descripcion = Provee_Rubro)
from gd_esquema.Maestra
where provee_Rs is not null)

insert into ZTS_DB.USUARIOS (Username, Password) 
(select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)),HASHBYTES('SHA2_256',(CUIT)) from ZTS_DB.PROVEEDORES)

update ZTS_DB.PROVEEDORES 
set username = B.username from ZTS_DB.PROVEEDORES as A,ZTS_DB.USUARIOS as B where B.Username =  (select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)) )

Update ZTS_DB.PROVEEDORES
set Mail = (username + '@gmail.com')

-------------------------------------------------------------------------------

---------------------------TABLA DE ROLES--------------------------------------

IF NOT EXISTS (select * from sysobjects where name='ROLES' and xtype='U')
CREATE TABLE ZTS_DB.ROLES
(Rol_Id varchar(255) not null,
Estado varchar(255) default 'Habilitado' not null
PRIMARY KEY(Rol_Id)				
)
GO

-----MIGRACION DE ROLES-------------------------

insert into ZTS_DB.ROLES(Rol_Id)
values('Administrador')

insert into ZTS_DB.ROLES(Rol_Id)
values('Cliente')

insert into ZTS_DB.ROLES(Rol_Id)
values('Proveedor')

-------------------------------------------------------------------------------

------------------------TABLA ROLES  POR USUARIO-------------------------------
IF NOT EXISTS (select * from sysobjects where name='ROLES_POR_USUARIO' and xtype='U')
CREATE TABLE ZTS_DB.ROLES_POR_USUARIO
(
 Rol_Id varchar(255),
 Username varchar(255)
 FOREIGN KEY(Rol_Id) references ZTS_DB.Roles(Rol_Id),
 FOREIGN KEY(Username) References ZTS_DB.Usuarios(Username)
)
GO

-----MIGRACION DE ROLES POR USUARIO-------------------

insert into ZTS_DB.ROLES_POR_USUARIO (Rol_Id, Username) (select 'Cliente',username from ZTS_DB.CLIENTES)
insert into ZTS_DB.ROLES_POR_USUARIO (Rol_Id, Username) (select 'Proveedor',username from ZTS_DB.PROVEEDORES)
insert into ZTS_DB.ROLES_POR_USUARIO (Rol_Id, Username) values('Administrador','ADMIN')

-------------------------------------------------------------------------------

------------------TABLA FUNCIONES----------------------------------------------

IF NOT EXISTS (select * from sysobjects where name='FUNCIONES' and xtype='U')
CREATE TABLE ZTS_DB.FUNCIONES
(Indice INT IDENTITY(1,1) NOT NULL,
  Funcion_Id AS 'FuncionID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Descripcion varchar(255)
  PRIMARY KEY(Funcion_Id)
)
GO

-----MIGRACION DE FUNCIONES-------------------
insert into ZTS_DB.FUNCIONES (Descripcion) values ('ABM Roles')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('ABM Clientes')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('ABM Proveedores')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Listado Estadistico')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Comprar Oferta')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Registrar Usuarios')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Cargar Credito')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Confeccion y Publicacion de Ofertas')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Entrega/Consumo de Oferta')
insert into ZTS_DB.FUNCIONES (Descripcion) values ('Facturar a Proveedor')

-------------------------------------------------------------------------------

------------------TABLA FUNCIONES POR ROL--------------------------------------

IF NOT EXISTS (select * from sysobjects where name='FUNCIONES_POR_ROL' and xtype='U')
CREATE TABLE ZTS_DB.FUNCIONES_POR_ROL
(Rol_Id varchar(255) not null,
 Funcion_Id varchar(17) not null
 FOREIGN KEY(Rol_Id) REFERENCES ZTS_DB.ROLES(Rol_Id),
 FOREIGN KEY(Funcion_Id) REFERENCES ZTS_DB.FUNCIONES(Funcion_Id)
)
GO

-----MIGRACION DE FUNCIONES POR ROL ----------

insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Cliente', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Comprar Oferta')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Cliente', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Cargar Credito')

insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Proveedor', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Confeccion y Publicacion de Ofertas')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Proveedor', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Entrega/Consumo de Oferta')

insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'ABM Roles')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'ABM Clientes')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'ABM Proveedores')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Listado Estadistico')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Comprar Oferta')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Registrar Usuarios')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Cargar Credito')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Confeccion y Publicacion de Ofertas')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Entrega/Consumo de Oferta')
insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) (select 'Administrador', Funcion_Id from ZTS_DB.FUNCIONES
where Descripcion = 'Facturar a Proveedor')

-------------------------------------------------------------------------------

--------------------TABLA DE TARJETAS------------------------------------------

IF NOT EXISTS (select * from sysobjects where name='TARJETAS' and xtype='U')
CREATE TABLE ZTS_DB.TARJETAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Tarjeta_Id AS 'TarjetaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Numero_Tarjeta numeric(20),
  Codigo_Seguridad numeric(3),
  tipo_Tarjeta varchar(255)
  PRIMARY KEY(Tarjeta_Id)
)
GO

-----MIGRACION DE TARJETAS----------

INSERT INTO ZTS_DB.TARJETAS (tipo_Tarjeta)
(select DISTINCT Tipo_Pago_Desc from gd_esquema.Maestra gd
where Tipo_Pago_Desc is not null)

-------------------------------------------------------------------------------

-----------------------TABLA DE CARGAS-----------------------------------------

IF NOT EXISTS (select * from sysobjects where name='CARGAS' and xtype='U')
CREATE TABLE ZTS_DB.CARGAS
(
	Indice INT IDENTITY(1,1) NOT NULL,
	Carga_Id AS 'CargaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Cliente_Id varchar(17),
	Tarjeta_Id varchar(17),
	Fecha datetime not null,
	Monto numeric(10,0) not null,
	PRIMARY KEY(Carga_Id),
	FOREIGN KEY(Cliente_Id) references ZTS_DB.CLIENTES(Cliente_Id),
	FOREIGN KEY(Tarjeta_Id) REFERENCES ZTS_DB.TARJETAS(Tarjeta_Id)
)
GO

-----MIGRACION DE CARGAS----------
INSERT INTO ZTS_DB.CARGAS (Cliente_Id,Fecha,Monto,Tarjeta_Id)
(SELECT C.Cliente_Id,
gd.Carga_Fecha,
gd.Carga_Credito,
T.Tarjeta_Id
from gd_esquema.Maestra gd
JOIN ZTS_DB.CLIENTES C on gd.Cli_Dni = C.DNI 
JOIN ZTS_DB.TARJETAS T on T.tipo_Tarjeta = gd.Tipo_Pago_Desc
where gd.Carga_Fecha is not null and gd.Carga_Credito is not null and gd.Tipo_Pago_Desc is not null)


-------------------------------------------------------------------------------

-----------------------TABLA DE OFERTAS----------------------------------------

IF NOT EXISTS (select * from sysobjects where name='OFERTAS' and xtype='U')
CREATE TABLE ZTS_DB.OFERTAS
(	
	Codigo_Oferta varchar(255) not null,
	Precio_oferta numeric (18,2) not null,
	Precio_lista numeric(18,2) not null,
	Fecha_publicacion datetime not null,
	Fecha_Vencimiento datetime not null,
	Descripcion varchar(255) not null,
	Cantidad_disponible numeric(18,0) not null,
	cantidad_maxima_por_usuario int not null,
	Proveedor_referenciado varchar(19) not null
	PRIMARY KEY(Codigo_Oferta),
	FOREIGN KEY(Proveedor_referenciado) REFERENCES ZTS_DB.PROVEEDORES (Proveedor_Id)
)
GO

-----MIGRACION DE OFERTAS--------

INSERT INTO ZTS_DB.OFERTAS
(Codigo_Oferta,Proveedor_referenciado,Precio_oferta,Precio_Lista,fecha_publicacion,fecha_vencimiento,descripcion,cantidad_disponible,cantidad_maxima_por_usuario)
(select distinct (select distinct top 1 gd2.Oferta_Codigo from gd_esquema.Maestra gd2
where gd2.Oferta_Cantidad = gd.Oferta_Cantidad and gd2.Oferta_Descripcion = gd.Oferta_Descripcion
and gd2.Oferta_Fecha = gd.Oferta_Fecha and gd2.Oferta_Fecha_Venc = gd.Oferta_Fecha_Venc and
gd2.Oferta_Precio_Ficticio = gd.Oferta_Precio_Ficticio and gd2.Oferta_Precio = gd.Oferta_Precio
and gd2.Provee_CUIT = p.CUIT),
p.Proveedor_id,
Oferta_Precio,
Oferta_Precio_Ficticio,
Oferta_Fecha,Oferta_Fecha_Venc,
Oferta_Descripcion,
Oferta_Cantidad,
Oferta_Cantidad 
from gd_esquema.Maestra gd join ZTS_DB.proveedores p
on gd.Provee_rs = p.razon_social
where gd.Oferta_Codigo is not null )


-------------------------------------------------------------------------------

-----------------------TABLA DE FACTURAS---------------------------------------

IF NOT EXISTS (select * from sysobjects where name='FACTURAS' and xtype='U')
CREATE TABLE ZTS_DB.FACTURAS
( 
	Numero bigint not null,
	Proveedor_Id varchar(19) not null,
	Fecha datetime not null,
	ImporteTotal numeric(20,2),
	PRIMARY KEY(Numero),
	FOREIGN KEY(Proveedor_Id) REFERENCES ZTS_DB.PROVEEDORES(Proveedor_Id)
)
GO

----MIGRACION DE FACTURAS---------

INSERT INTO ZTS_DB.FACTURAS
(Proveedor_Id,FECHA, Numero,ImporteTotal)
(select  p.proveedor_id,Factura_Fecha, Factura_Nro,sum(Oferta_Precio) from gd_esquema.Maestra gd join ZTS_DB.Proveedores p
on gd.Provee_RS = p.razon_social
where Factura_Nro is not null
group by Factura_Fecha,Factura_Nro,p.Proveedor_Id)

-------------------------------------------------------------------------------

-----------------------TABLA DE COMPRAS----------------------------------------

IF NOT EXISTS (select * from sysobjects where name='COMPRAS' and xtype='U')
CREATE TABLE ZTS_DB.COMPRAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Compra_Id AS 'CompraID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Codigo_oferta varchar(255),
  Cliente_Id varchar(17),
  Fecha_compra datetime not null,
  Cantidad SMALLINT,
  Factura_id bigint,
  PRIMARY KEY(Compra_Id),
  FOREIGN KEY(Factura_id) REFERENCES ZTS_DB.FACTURAS(numero),
  FOREIGN KEY(Cliente_Id) REFERENCES ZTS_DB.CLIENTES(Cliente_Id),
  FOREIGN KEY(Codigo_oferta) REFERENCES ZTS_DB.OFERTAS(Codigo_oferta)
)
GO

------MIGRACION DE COMPRAS--------
insert into ZTS_DB.compras(Codigo_oferta,cliente_id,fecha_Compra, Cantidad)
(select distinct o.Codigo_oferta,cliente_id,oferta_Fecha_compra, 1 from gd_esquema.Maestra gd join ZTS_DB.ofertas o on gd.Oferta_Codigo = o.Codigo_oferta
join ZTS_DB.CLIENTES c on gd.Cli_Dni = c.DNI)

update ZTS_DB.compras
set Factura_Id = (select top 1  gd.Factura_Nro from gd_esquema.Maestra gd where Fecha_compra = gd.Oferta_Fecha_Compra and Codigo_oferta = gd.Oferta_Codigo order by 1 desc)

-------------------------------------------------------------------------------

-----------------------TABLA DE CUPONES----------------------------------------

IF NOT EXISTS (select * from sysobjects where name='CUPONES' and xtype='U')
CREATE TABLE ZTS_DB.CUPONES
( Indice INT IDENTITY(1,1) NOT NULL,
  Cupon_Id AS 'CuponID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Codigo_oferta varchar(255),
  Codigo_cupon varchar(255),
  Compra_Id varchar(16),
  Fecha_Consumo datetime,
  Cantidad_disponible int,
  PRIMARY KEY(Cupon_Id),
  FOREIGN KEY(Compra_Id) REFERENCES ZTS_DB.COMPRAS(Compra_Id),
  FOREIGN KEY(Codigo_oferta) REFERENCES ZTS_DB.OFERTAS(Codigo_oferta)
)
GO

----MIGRACION DE CUPONES---------

insert into ZTS_DB.CUPONES(codigo_oferta,Compra_Id, Cantidad_disponible)
(select Codigo_oferta,compra_id, Cantidad from ZTS_DB.COMPRAS)

update ZTS_DB.CUPONES 
set cupones.Fecha_Consumo = gd_esquema.Maestra.Oferta_Entregado_Fecha
from
ZTS_DB.CUPONES  c join ZTS_DB.COMPRAS cr on c.Compra_Id=cr.Compra_Id
join ZTS_DB.CLIENTES cli on cr.Cliente_Id=cli.Cliente_Id
join gd_esquema.Maestra  on cli.DNI = gd_esquema.Maestra.Cli_Dni and c.codigo_oferta = gd_esquema.Maestra.Oferta_Codigo
where Oferta_Entregado_Fecha is not null

update ZTS_DB.CUPONES
set codigo_cupon= (select newId())

-------------------------------------------------------------------------------

-------------------FIN DE CREACION Y MIGRACION DE TABLAS-----------------------

-------------------------------------------------------------------------------





-------------------------------------------------------------------------------

-------------------CREACION DE PROCEDURES Y TRIGGERS---------------------------

-------------------------------------------------------------------------------


-------------------------------------------------------------------------------
----CLIENTES-------------------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('baja_logica_cliente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.baja_logica_cliente
GO
CREATE PROCEDURE ZTS_DB.baja_logica_cliente(@DNI_CLIENTE numeric(18,0),@username varchar(255))
AS BEGIN
	if Exists(select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username)
		begin			
			delete from ZTS_DB.ROLES_POR_USUARIO where Username = @username
			update ZTS_DB.CLIENTES
			set Estado = 'Inhabilitado' where DNI = @DNI_CLIENTE
		end
	else
		begin
			throw 50003, 'El cliente ya esta Inhabilitado',1
		end
END
GO

IF OBJECT_ID('habilitar_cliente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.habilitar_cliente
GO
CREATE PROCEDURE ZTS_DB.habilitar_cliente(@DNI_CLIENTE numeric(18,0),@username varchar(255))
AS BEGIN

	if not exists(select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username)
		begin
			update ZTS_DB.CLIENTES
			set Estado = 'Habilitado' where DNI = @DNI_CLIENTE
			
			insert into ZTS_DB.ROLES_POR_USUARIO (Rol_Id, Username) values ('Cliente', @username)
		end
	else
		begin
			throw 50003, 'El cliente ya esta Habilitado',1
		end
END
GO

IF OBJECT_ID('actualizar_cliente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.actualizar_cliente
GO
Create Procedure ZTS_DB.actualizar_cliente(@username varchar(255),@nombre varchar(255), @apellido varchar(255), @DNI numeric(18,0), @telefono numeric(18,0),
@mail varchar(255),@fecha varchar(255), @direccion varchar(255), @ciudad varchar(255) ,
@CP int = NULL, @Loc varchar(255) = NULL, @Npiso int = NULL, @depto varchar(255) = NULL)
AS BEGIN	
	IF NOT EXISTS(SELECT 1 FROM ZTS_DB.CLIENTES WHERE @DNI = DNI AND username != @username)
	BEGIN
		update ZTS_DB.CLIENTES
		set
			Nombre = @nombre,
			Apellido = @apellido,
			DNI = @DNI,
			Telefono = @telefono,
			Mail = @mail,
			Fecha_Nacimiento = CONVERT(datetime,@fecha, 121)
		where username = @username
	END
	ELSE
	BEGIN
		THROW 50300, 'El DNI que desea ingresar, ya fue utilizado por otro cliente. Recuerde que es un campo Unico', 1
	END

	declare @direcID int = (select direccion from ZTS_DB.CLIENTES where username = @username)

	--SI EXISTE LA DIRECCION EN EL SISTEMA, SIMPLEMENTE TOMO EL ID Y ME LO ASIGNO
	IF EXISTS(SELECT 1 FROM ZTS_DB.DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
				((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
				((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
				((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
				((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
				)

		BEGIN
			DECLARE @direcID_existente int = (select Id_Direccion from ZTS_DB.DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto))

			update ZTS_DB.CLIENTES
			set Direccion = @direcID_existente
			where username = @username				
		END
	ELSE
		BEGIN
		--SI NO EXISTE LA DIRECCION NUEVA EN EL SISTEMA, PERO HAY MAS DE 1 CLIENTE QUE TIENE MI DIRECCION ACTUAL, INSERTO LA NUEVA, TOMO EL ID NUEVO Y ME LO ASIGNO
			IF ( ((SELECT COUNT(1) FROM ZTS_DB.CLIENTES WHERE Direccion = @direcID) > 1) OR ((SELECT COUNT(1) FROM ZTS_DB.PROVEEDORES WHERE Direccion = @direcID) >= 1))
			BEGIN
					insert into ZTS_DB.DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			
					DECLARE @direcc_id_nuevo int
					set @direcc_id_nuevo = (select id_direccion from ZTS_DB.DIRECCION
					where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
					)

					update ZTS_DB.CLIENTES
						set Direccion = @direcc_id_nuevo
					where username = @username
			END
		ELSE
			BEGIN
			--SI NO EXISTE OTRO PROVEEDOR CON MI MISMA DIRECCION VIEJA, SIMPLEMENTE ACTUALIZO
					update ZTS_DB.DIRECCION 
					set 
						Direccion = @direccion,
						Ciudad = @ciudad,
						Codigo_Postal = @CP,
						Localidad = @Loc,
						Numero_Piso = @Npiso,
						Depto = @depto
					where Id_DIRECCION = @direcID
			END
	END
END
GO


IF OBJECT_ID('verificar_si_no_es_cliente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_si_no_es_cliente
GO
CREATE PROCEDURE ZTS_DB.verificar_si_no_es_cliente(@username varchar(255))
AS begin
if exists (select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username and Rol_Id = 'Administrador')
	throw 50005,'No es Cliente',1
end
GO


-------------------------------------------------------------------------------
----CARGAS---------------------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('persistir_carga') IS NOT NULL
	DROP PROCEDURE ZTS_DB.persistir_carga
GO
CREATE PROCEDURE ZTS_DB.persistir_carga(@username varchar(255),@tarjeta_nro numeric(20),@cod_segu numeric(3),@tipo_tarj varchar(20),@monto numeric(10,0),
							  @fecha varchar(10))
AS BEGIN
	--Solo puede existir una tarjeta con igual numero y codigo de seguridad
	IF EXISTS(SELECT 1 FROM ZTS_DB.TARJETAS WHERE (Numero_Tarjeta = @tarjeta_nro and Codigo_Seguridad != @cod_segu) OR (Numero_Tarjeta = @tarjeta_nro and tipo_Tarjeta != @tipo_tarj) )
	BEGIN
		throw 50006, 'Los datos ingresados no coinciden con la Tarjeta registrada',1
	END

	IF NOT EXISTS(SELECT 1 FROM ZTS_DB.TARJETAS WHERE Numero_Tarjeta = @tarjeta_nro)
	BEGIN
		INSERT INTO ZTS_DB.TARJETAS (Numero_Tarjeta, Codigo_Seguridad, tipo_Tarjeta) values (@tarjeta_nro, @cod_segu, @tipo_tarj)
	END


	declare @Tarjeta_ID varchar(17) = (select Tarjeta_Id from ZTS_DB.TARJETAS where numero_tarjeta = @tarjeta_nro and codigo_seguridad = @cod_segu)
	declare @Cliente_ID varchar(17) = (select Cliente_Id from ZTS_DB.CLIENTES where username = @username)
	declare @fecha_convertida datetime = (convert(datetime,@fecha,121))


	INSERT INTO ZTS_DB.CARGAS (Cliente_Id, Tarjeta_Id, Fecha, Monto) values (@Cliente_ID, @Tarjeta_ID, @fecha_convertida, @monto)

END


IF OBJECT_ID('ACTUALIZACION_MONTO_CLIENTE') IS NOT NULL
	DROP TRIGGER ZTS_DB.ACTUALIZACION_MONTO_CLIENTE
GO
CREATE TRIGGER ZTS_DB.ACTUALIZACION_MONTO_CLIENTE ON ZTS_DB.CARGAS AFTER INSERT
AS
BEGIN	

	DECLARE @Cliente_ID varchar(17) = (SELECT Cliente_Id from inserted);
	DECLARE @Monto numeric(10,0) = (SELECT Monto from inserted);

	UPDATE ZTS_DB.CLIENTES
		SET DineroDisponible += @Monto
		where Cliente_Id = @Cliente_ID

END
GO

-------------------------------------------------------------------------------
----PROVEEDORES----------------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('baja_logica_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.baja_logica_proveedor
GO
CREATE PROCEDURE ZTS_DB.baja_logica_proveedor(@CUIT varchar(255),@username varchar(255))
AS BEGIN

	if exists (select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username)
		begin
			delete from ZTS_DB.ROLES_POR_USUARIO where Username = @username
			update ZTS_DB.PROVEEDORES
			set Estado = 'Inhabilitado' where CUIT = @CUIT
		end
	else
		begin
			throw 50003, 'El Proveedor ya esta Inhabilitado',1
		end

END
GO

IF OBJECT_ID('habilitar_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.habilitar_proveedor
GO
CREATE PROCEDURE ZTS_DB.habilitar_proveedor(@CUIT varchar(255), @Username varchar(255))
AS BEGIN
	if  ((select estado from ZTS_DB.ROLES where Estado = 'Proveedor') = 'Inahabilitado')
			throw 50005,'Rol Inhabilitado',1
else
	begin
	if not exists(select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username)
		begin
			insert into ZTS_DB.ROLES_POR_USUARIO(Rol_Id,Username)
			values('Proveedor',@Username)
			update ZTS_DB.PROVEEDORES
			set Estado = 'Habilitado' where CUIT = @CUIT
		end
	else
			throw 50009,'El proveedor ya esta habilitado',1
	end
END
GO

IF OBJECT_ID('actualizar_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.actualizar_proveedor
GO
Create Procedure ZTS_DB.actualizar_proveedor(@username varchar(255),@razonSocial varchar(255), @rubro varchar(255), @CUIT varchar(255), @telefono numeric(18,0),
@mail varchar(255), @direccion varchar(255), @ciudad varchar(255),
@CP int = NULL, @Loc varchar(255) = NULL, @Npiso int = NULL, @depto varchar(255) = NULL, @contacto varchar(255) = NULL)
AS BEGIN

	IF NOT EXISTS(SELECT 1 FROM ZTS_DB.PROVEEDORES WHERE username != @username and (Razon_Social = @razonSocial OR CUIT = @CUIT) )
	BEGIN
		DECLARE @RUBRO_ID varchar(15) = (select Rubro_Id from ZTS_DB.RUBROS where rubro_descripcion = @rubro)

		update ZTS_DB.PROVEEDORES
		set
			Razon_Social = @razonSocial,
			CUIT = @CUIT,
			Telefono = @telefono,
			Mail = @mail,
			Nombre_contacto = @contacto,
			Rubro_Id = @RUBRO_ID
		where username = @username
	END
	ELSE
	BEGIN
		THROW 60000, 'La razon social y/o el cuit que desea ingresar, ya estan utilizados por otro proveedor. Porfavor ingrese otro.', 1
	END

	
	declare @direcID int = (select direccion from ZTS_DB.PROVEEDORES where username = @username)

	--SI EXISTE LA DIRECCION EN EL SISTEMA, SIMPLEMENTE TOMO EL ID Y ME LO ASIGNO
	IF EXISTS(SELECT 1 FROM ZTS_DB.DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
				((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
				((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
				((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
				((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
				)

		BEGIN
			DECLARE @direcID_existente int = (select Id_Direccion from ZTS_DB.DIRECCION where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto))

			update ZTS_DB.PROVEEDORES
			set Direccion = @direcID_existente
			where username = @username				
		END
	ELSE
		BEGIN
		--SI NO EXISTE LA DIRECCION NUEVA EN EL SISTEMA, PERO HAY MASDE 1 PROVEEDOR o CLIENTE QUE TIENE MI DIRECCION ACTUAL, INSERTO LA NUEVA, TOMO EL ID NUEVO Y ME LO ASIGNO
			IF ( ((SELECT COUNT(1) FROM ZTS_DB.PROVEEDORES WHERE Direccion = @direcID) > 1) OR ((SELECT COUNT(1) FROM ZTS_DB.CLIENTES WHERE Direccion = @direcID) >= 1) )
			BEGIN
					insert into ZTS_DB.DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			
					DECLARE @direcc_id_nuevo int
					set @direcc_id_nuevo = (select id_direccion from ZTS_DB.DIRECCION
					where Direccion = @Direccion and  Ciudad = @ciudad and
					((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
					((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
					((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
					((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
					)

					update ZTS_DB.PROVEEDORES
						set Direccion = @direcc_id_nuevo
					where username = @username
			END
		ELSE
			BEGIN
			--SI NO EXISTE OTRO PROVEEDOR o CLIENTE CON MI MISMA DIRECCION VIEJA, SIMPLEMENTE ACTUALIZO
					update ZTS_DB.DIRECCION 
					set 
						Direccion = @direccion,
						Ciudad = @ciudad,
						Codigo_Postal = @CP,
						Localidad = @Loc,
						Numero_Piso = @Npiso,
						Depto = @depto
					where Id_DIRECCION = @direcID
			END
	END
END
GO

IF OBJECT_ID('proveedor_existente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.proveedor_existente
GO
CREATE PROCEDURE ZTS_DB.proveedor_existente(@proveedor VARCHAR(255))
AS BEGIN
	If NOT EXISTS (SELECT 1 FROM ZTS_DB.PROVEEDORES WHERE username = @proveedor)
	BEGIN
		THROW 90003,'El proveedor no esta registrado.',1
	END
END
GO

IF OBJECT_ID('pedir_proveedorID') IS NOT NULL
	DROP FUNCTION ZTS_DB.pedir_proveedorID
GO
CREATE FUNCTION ZTS_DB.pedir_proveedorID(@proveedor_username VARCHAR(255))
	RETURNS VARCHAR(255)
AS BEGIN
	RETURN (SELECT Proveedor_Id FROM ZTS_DB.PROVEEDORES WHERE username = @proveedor_username)
END
GO

IF OBJECT_ID('insertar_factura') IS NOT NULL
	DROP PROCEDURE ZTS_DB.insertar_factura
GO
CREATE PROCEDURE ZTS_DB.insertar_factura(@proveedor_id varchar(255), @fecha datetime, @numero_id bigint, @importe numeric(20,2))
AS BEGIN
	INSERT INTO ZTS_DB.FACTURAS (Proveedor_Id,FECHA, Numero,ImporteTotal) VALUES(@proveedor_id, CONVERT(DATETIME, @fecha, 121), @numero_id, @importe)
END
GO

IF OBJECT_ID('verificar_si_no_es_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_si_no_es_proveedor
GO
CREATE PROCEDURE ZTS_DB.verificar_si_no_es_proveedor(@username varchar(255))
AS begin
if exists (select 1 from ZTS_DB.ROLES_POR_USUARIO where Username = @username and Rol_Id = 'Administrador')
	throw 50005,'No es proveedor',1
end


-------------------------------------------------------------------------------
----USUARIOS-------------------------------------------------------------------
-------------------------------------------------------------------------------


IF OBJECT_ID('registrar_usuario_cliente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.registrar_usuario_cliente
GO
CREATE PROCEDURE ZTS_DB.registrar_usuario_cliente(@Username varchar(255), @Password varchar(255),@Rol varchar(255),
										@nombre varchar(255),@apellido varchar(255),@DNI numeric(18,0),@telefono numeric(18,0),
										@mail varchar(255),@fecha_nacimiento datetime,@Direccion varchar(255),@ciudad varchar(255),
										@CP numeric(4,0) = null ,@Loc varchar(255) = null ,@NPiso int = null ,@depto varchar(255) = null)
AS BEGIN
	begin try
		begin transaction

			insert into ZTS_DB.USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ZTS_DB.ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			IF NOT EXISTS(SELECT 1 FROM ZTS_DB.DIRECCION WHERE Direccion = @Direccion and Ciudad = @Ciudad AND
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)
			begin
					insert into ZTS_DB.DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			end

			DECLARE @direcc_id int
			set @direcc_id = (select id_direccion from ZTS_DB.DIRECCION 
			where Direccion = @Direccion and Ciudad = @ciudad and
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)

			insert into ZTS_DB.CLIENTES(Username,Nombre,Apellido,DNI,Direccion,Telefono,Mail,Fecha_Nacimiento,DineroDisponible)
			values(@username, @nombre,@apellido,@DNI,@direcc_id,@telefono,@mail,@fecha_nacimiento,200)	  
	
			commit transaction
	end try
	begin catch
			rollback transaction
	end catch
END
GO

IF OBJECT_ID('registrar_usuario_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.registrar_usuario_proveedor
GO
CREATE PROCEDURE ZTS_DB.registrar_usuario_proveedor(@Username varchar(255), @Password varchar(255),@Rol varchar(255),
											@Razon_social varchar(255),@Mail varchar(255),
											@Telefono numeric(18,0),@CUIT varchar(255),@Rubro varchar(255),
											@Nombre_contacto varchar(255) = NULL,@Direccion varchar(255),
											@Ciudad varchar(255),@CP numeric(4,0) = NULL ,@Loc varchar(255) = NULL,
											@NPiso int = NULL,@depto varchar(255) = NULL)									
AS BEGIN
	begin try
		begin transaction

			insert into ZTS_DB.USUARIOS(Username,Password)
			values(@username,  HASHBYTES('SHA2_256',(rtrim(@password))))

			insert into ZTS_DB.ROLES_POR_USUARIO(Rol_Id,Username)
			values(@Rol,@username)

			IF NOT EXISTS(SELECT 1 FROM ZTS_DB.DIRECCION WHERE Direccion = @Direccion and Ciudad = @Ciudad AND
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)
			begin
					insert into ZTS_DB.DIRECCION(Direccion,Codigo_Postal,Localidad,Ciudad,Numero_Piso,Depto)
					values(@Direccion,@CP,@Loc,@ciudad,@NPiso,@depto)
			end

			DECLARE @direcc_id int
			set @direcc_id = (select id_direccion from ZTS_DB.DIRECCION
			where Direccion = @Direccion and  Ciudad = @ciudad and
			((@CP IS NULL AND Codigo_Postal IS NULL ) OR Codigo_Postal = @CP) and 
			((@Loc IS NULL AND Localidad IS NULL ) OR Localidad = @Loc) and
			((@NPISO IS NULL AND Numero_Piso IS NULL )OR Numero_Piso = @NPiso) and 
			((@depto IS NULL AND Depto IS NULL )OR Depto = @Depto)
			)

			IF NOT EXISTS(SELECT 1 FROM ZTS_DB.RUBROS WHERE rubro_descripcion = @Rubro)
			BEGIN
				insert into ZTS_DB.RUBROS(Rubro_descripcion) values (@Rubro)
			END

			declare @rubro_id varchar(15)
			set @rubro_id = (select Rubro_Id from ZTS_DB.RUBROS where rubro_descripcion = @Rubro)

			insert into ZTS_DB.PROVEEDORES(Razon_Social,username,mail,Telefono,Direccion,CUIT,Nombre_contacto,Rubro_Id)
			values(@razon_social,@username,@mail,@telefono,@direcc_id,@cuit,@nombre_contacto,@rubro_id)

			commit transaction
	end try
	begin catch
			rollback transaction
	end catch
END
GO

IF OBJECT_ID('modificar_password') IS NOT NULL
	DROP PROCEDURE ZTS_DB.modificar_password
GO
CREATE PROCEDURE ZTS_DB.modificar_password(@username varchar(255), @vieja_password varchar(255), @nueva_password varchar(255))
AS BEGIN
	IF not exists (select 1 from USUARIOS where Username = @username)
		throw 50002,'Usuario Inexistente',1
	IF(@vieja_password = @nueva_password)
		throw 50003,'La contraseña nueva no puede ser igual a la actual, elija otra.',1
	IF((select password from USUARIOS where username = @username) = HASHBYTES('SHA2_256',@vieja_password) )
		begin
			update USUARIOS
			set password =HASHBYTES('SHA2_256',@nueva_password)  where username = @username
		end
	ELSE
		begin
			THROW 50001, 'La contraseña actual ingresada es INCORRECTA', 1
		end
END
GO

IF OBJECT_ID('baja_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.baja_usuario
GO
CREATE PROCEDURE ZTS_DB.baja_usuario(@username varchar(255))
AS BEGIN
update ZTS_DB.USUARIOS
set Estado = 'Deshabilitado' where username = @username
END
GO

IF OBJECT_ID('habilitacion_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.habilitacion_usuario
GO
CREATE PROCEDURE ZTS_DB.habilitacion_usuario(@username varchar(255))
AS BEGIN
update ZTS_DB.USUARIOS
set Estado = 'Habilitado' where username = @username
END
GO

IF OBJECT_ID('inhabilitacion_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.inhabilitacion_usuario
GO
CREATE PROCEDURE ZTS_DB.inhabilitacion_usuario(@username varchar(255))
AS BEGIN
update ZTS_DB.USUARIOS
set Estado = 'Inhabilitado' where username = @username
END
GO

IF OBJECT_ID('verificar_existencia_de_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_existencia_de_usuario
GO
CREATE PROCEDURE ZTS_DB.verificar_existencia_de_usuario(@username varchar(255))
as begin
if exists(select 1 from ZTS_DB.USUARIOS where Username = RTRIM(@username))
	begin
		throw 50001,'Error, nombre de usuario ya existente. Elija otro.',1
	end
end
GO

IF OBJECT_ID('verificar_existencia_cliente_gemelo') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_existencia_cliente_gemelo
GO
CREATE PROCEDURE ZTS_DB.verificar_existencia_cliente_gemelo(@nombre varchar(255),@apellido varchar(255),@DNI numeric(18,0),@telefono numeric(18,0),@mail varchar(255),@fecha_nacimiento datetime)
as begin
	if exists(select 1 from ZTS_DB.CLIENTES where nombre=@nombre and Apellido = @apellido and DNI=@DNI and Telefono = @telefono and Mail=@mail and Fecha_Nacimiento =@fecha_nacimiento)
		OR EXISTS (select 1 from ZTS_DB.CLIENTES where DNI = @DNI)
		begin
			throw 50004,'Error, el cliente ya existe',1
		end
end
GO

IF OBJECT_ID('verificar_existencia_proveedor_gemelo') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_existencia_proveedor_gemelo
GO
CREATE PROCEDURE ZTS_DB.verificar_existencia_proveedor_gemelo(@cuit varchar(255),@razon_social varchar(255))
as begin
	if exists(select 1 from ZTS_DB.PROVEEDORES where CUIT = @cuit)  OR exists(select 1 from ZTS_DB.PROVEEDORES where Razon_Social = @razon_social)
		begin
			throw 50004,'Error, el proveedor ya existe',1
		end
end
GO

IF OBJECT_ID('verificar_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_usuario
GO
CREATE PROCEDURE ZTS_DB.verificar_usuario(@username varchar(255))
AS BEGIN
if not exists(select 1 from ZTS_DB.USUARIOS where Username = @username)
		THROW 50006, 'El Usuario que desea ingresar no esta registrado en el sistema. ', 1
END
GO

IF OBJECT_ID('verificar_password') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_usuario
GO
CREATE PROCEDURE ZTS_DB.verificar_password(@username varchar(255),@password varchar(255))
AS BEGIN
DECLARE @contraseña_encriptada char(255);
set @contraseña_encriptada = HASHBYTES('SHA2_256',(rtrim(@password)))
if exists(select 1 from ZTS_DB.USUARIOS where Username = @username and Password = @contraseña_encriptada and Estado = 'Inhabilitado')
		THROW 50007, 'El Usuario con el que intenta ingresar al sistema esta Inhabilitado',1
if not exists(select 1 from ZTS_DB.USUARIOS where Username = @username and Password = @contraseña_encriptada)
		THROW 50006, 'La contraseña ingresada es incorrecta. Pruebe de nuevo. ', 1
END
GO


-------------------------------------------------------------------------------
----ROLES----------------------------------------------------------------------
-------------------------------------------------------------------------------


IF OBJECT_ID('deshabilitar_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.deshabilitar_rol
GO
CREATE PROCEDURE ZTS_DB.deshabilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ZTS_DB.ROLES where Rol_Id = @Rol_Id and Estado = 'Habilitado')
		begin
			update ZTS_DB.ROLES 
				set Estado = 'Inhabilitado' where Rol_Id = @Rol_Id

			if (@Rol_Id = 'Cliente')
				begin
					delete from ZTS_DB.ROLES_POR_USUARIO where Rol_Id = 'Cliente'
					update ZTS_DB.CLIENTES set Estado = 'Inhabilitado'
				end
			else if (@Rol_Id = 'Proveedor')
				begin
					delete from ZTS_DB.ROLES_POR_USUARIO where Rol_Id = 'Proveedor'
					update ZTS_DB.PROVEEDORES set Estado = 'Inhabilitado'
				end			
		end
	else
		begin
			throw 80000, 'El Rol ya esta Inhabilitado',1
		end
END
GO

IF OBJECT_ID('habilitar_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.habilitar_rol
GO
CREATE PROCEDURE ZTS_DB.habilitar_rol(@Rol_Id varchar(255))
AS BEGIN
	if exists(select 1 from ROLES where Rol_Id = @Rol_Id and Estado = 'Inhabilitado')
		begin
			update ZTS_DB.ROLES 
				set Estado = 'Habilitado' where Rol_Id = @Rol_Id
		end
	else
		begin
			throw 80001, 'El Rol ya esta Habilitado',1
		end
END
GO

IF OBJECT_ID('insertar_rol_por_usuario') IS NOT NULL
	DROP PROCEDURE ZTS_DB.insertar_rol_por_usuario
GO
CREATE PROCEDURE ZTS_DB.insertar_rol_por_usuario(@Rol_Id varchar(255), @username varchar(255))
AS BEGIN
	if exists(select 1 from ZTS_DB.ROLES where Rol_Id = @Rol_Id and Estado = 'Habilitado')
		insert into ZTS_DB.ROLES_POR_USUARIO (Rol_Id, Username) values (@Rol_Id, @username)
	else
		throw 90000, 'Rol Inhabilitado', 1
END
GO


IF OBJECT_ID('insertar_funciones_por_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.insertar_funciones_por_rol
GO
CREATE PROCEDURE ZTS_DB.insertar_funciones_por_rol(@Rol_Id varchar(255), @funcionID varchar(17))
AS BEGIN
	if not exists(select 1 from ZTS_DB.FUNCIONES_POR_ROL where Rol_Id = @Rol_Id and Funcion_Id = @funcionID)
		begin
			insert into ZTS_DB.FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values (@Rol_Id, @funcionID)
		end
	else
		begin
			throw 80002, 'La funcion ya se encuentra asignada al rol',1
		end

END
GO

IF OBJECT_ID('insertar_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.insertar_rol
GO
CREATE PROCEDURE ZTS_DB.insertar_rol(@Rol_Id varchar(255))
AS BEGIN
	if not exists(select 1 from ZTS_DB.ROLES where Rol_Id = @Rol_Id)
		begin
			insert into ZTS_DB.ROLES (Rol_Id) values (@Rol_Id)
		end
	else
		begin
			throw 80003, 'El rol ya existe',1
		end

END
GO


IF OBJECT_ID('eliminar_funciones_por_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.eliminar_funciones_por_rol
GO
CREATE PROCEDURE ZTS_DB.eliminar_funciones_por_rol(@Rol_Id varchar(255))
AS BEGIN
	DELETE FROM ZTS_DB.FUNCIONES_POR_ROL WHERE Rol_Id = @Rol_Id
END
GO

IF OBJECT_ID('verificar_estado_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_estado_rol
GO
CREATE PROCEDURE ZTS_DB.verificar_estado_rol(@Rol_Id varchar(255))
AS BEGIN
	IF NOT EXISTS (SELECT 1 FROM ZTS_DB.ROLES WHERE Rol_Id = @Rol_Id and Estado = 'Habilitado')
		throw 80004, 'El Rol se Encuentra Inhabilitado. No se pueden ejecutar Altas.',1
END
GO

IF OBJECT_ID('Actulizar_nombre_rol') IS NOT NULL
	DROP PROCEDURE ZTS_DB.Actulizar_nombre_rol
GO
CREATE PROCEDURE ZTS_DB.Actulizar_nombre_rol (@nombre_rol_nuevo varchar(255),@nombre_rol_viejo varchar(255))
AS BEGIN

	ALTER TABLE ZTS_DB.ROLES NOCHECK CONSTRAINT ALL
	ALTER TABLE ZTS_DB.ROLES_POR_USUARIO NOCHECK CONSTRAINT ALL
	ALTER TABLE ZTS_DB.FUNCIONES_POR_ROL NOCHECK CONSTRAINT ALL
	
	update ZTS_DB.ROLES set Rol_Id = @nombre_rol_nuevo
	where Rol_Id = @nombre_rol_viejo

	update ZTS_DB.ROLES_POR_USUARIO set Rol_Id = @nombre_rol_nuevo
	where Rol_Id = @nombre_rol_viejo

	update ZTS_DB.FUNCIONES_POR_ROL set Rol_Id = @nombre_rol_nuevo
	where Rol_Id = @nombre_rol_viejo

	ALTER TABLE ZTS_DB.ROLES CHECK CONSTRAINT ALL
	ALTER TABLE ZTS_DB.ROLES_POR_USUARIO CHECK CONSTRAINT ALL
	ALTER TABLE ZTS_DB.FUNCIONES_POR_ROL CHECK CONSTRAINT ALL
END
GO

-------------------------------------------------------------------------------
----OFERTAS--------------------------------------------------------------------
-------------------------------------------------------------------------------


IF OBJECT_ID('confeccion_oferta') IS NOT NULL
	DROP PROCEDURE ZTS_DB.confeccion_oferta
GO
CREATE PROCEDURE ZTS_DB.confeccion_oferta(@descripcion varchar(255),@fecha_publicacion datetime,
								   @fecha_vencimiento datetime,@precio_oferta numeric(18,2),@precio_lista numeric(18,2),@cantidad_disponible numeric(18,0),@cantidad_maxima_por_usuario int,
								   @codigo varchar(50),@proveedor_referenciado varchar(255))
AS BEGIN


	DECLARE @ID VARCHAR(50) = (SELECT Proveedor_Id FROM ZTS_DB.PROVEEDORES WHERE username = @proveedor_referenciado)
		
	IF EXISTS(SELECT 1 FROM ZTS_DB.PROVEEDORES WHERE username = @proveedor_referenciado)
	BEGIN
		
		IF NOT EXISTS(SELECT 1 FROM ZTS_DB.OFERTAS WHERE Descripcion = @descripcion and Fecha_publicacion = convert(datetime,@fecha_publicacion,121)
		and Fecha_Vencimiento = convert(datetime,@fecha_vencimiento,121) and Precio_lista = @precio_lista and Precio_oferta =@precio_oferta
		and Proveedor_referenciado = @ID)
		BEGIN
			insert into ZTS_DB.OFERTAS(precio_oferta,precio_lista,fecha_publicacion,fecha_vencimiento,Descripcion,
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
			throw 100400,'La oferta ya se encuentra registrada en el sistema. Recuerde que solo puede haber ofertas iguales siempre y cuando sean de proveedores distintos. ', 1
		END

	END
	ELSE
	BEGIN
		throw 100000,'El proveedor ingresado no existe', 1
	END
END
GO

IF OBJECT_ID('comprar_oferta') IS NOT NULL
	DROP PROCEDURE ZTS_DB.comprar_oferta
GO
CREATE PROCEDURE ZTS_DB.comprar_oferta (@codigoOferta varchar(50),@precioLista numeric(12,2),@precio_oferta numeric(12,2),
								  @clienteUsuario varchar(50),@cantidadDisponible int,@cantidadCompra int, @cantidadMaxUsuario int)
AS BEGIN
DECLARE @cliente_id varchar(20)= (select cliente_id from ZTS_DB.CLIENTES where username = @clienteUsuario)
if(@cantidadCompra = 0)
			throw 50004,'Debe seleccionar la cantidad de Ofertas que desea comprar.',1
IF(@cantidadCompra > @cantidadDisponible)
	throw 50001,'La cantidad de ofertas que desea adquirir es mayor a la Disponible.',1

	insert into ZTS_DB.COMPRAS(Cliente_Id,Codigo_oferta,Fecha_compra,Cantidad)
	values(@cliente_id,@codigoOferta,SYSDATETIME(),@cantidadCompra)
END
GO

IF OBJECT_ID('trigger_compras') IS NOT NULL
	DROP TRIGGER ZTS_DB.trigger_compras
GO
CREATE TRIGGER ZTS_DB.trigger_compras
ON ZTS_DB.COMPRAS
INSTEAD OF insert
as begin
declare @cliente_id varchar(20) = (select cliente_id from INSERTED)
declare @codigoOferta varchar(50) = (select codigo_Oferta from INSERTED)
declare @cantidadCompra int = (select Cantidad from inserted)

IF(select SUM(Cantidad) from ZTS_DB.COMPRAS where Cliente_Id = @cliente_id and Codigo_oferta = @codigoOferta) <
	(select cantidad_maxima_por_usuario from ZTS_DB.OFERTAS where Codigo_Oferta = @codigoOferta) OR (select SUM(Cantidad) from ZTS_DB.COMPRAS where Cliente_Id = @cliente_id and Codigo_oferta = @codigoOferta) is null
begin
	begin transaction
		insert into ZTS_DB.COMPRAS(Cliente_Id,Codigo_oferta,Fecha_compra,Cantidad)
		values(@cliente_id,@codigoOferta,SYSDATETIME(),@cantidadCompra)

		declare @compra_id varchar(20) = (select top 1 compra_id from ZTS_DB.compras order by 1 desc)

		insert into ZTS_DB.CUPONES(Codigo_cupon,Codigo_oferta,Compra_Id)
		values(newid(),@codigoOferta,@compra_id)

		update ZTS_DB.OFERTAS
		set Cantidad_disponible = Cantidad_disponible - @cantidadCompra
		where Codigo_Oferta = @codigoOferta

		update ZTS_DB.CLIENTES
		set DineroDisponible = DineroDisponible - (select precio_oferta from ZTS_DB.OFERTAS where Codigo_Oferta = @codigoOferta) * @cantidadCompra
		where Cliente_Id = @cliente_id
	commit transaction
	end
	else
		throw 50002,'Usted alcanzó la cantidad máxima de compras posibles de esta Oferta.',1
end
GO


IF OBJECT_ID('obtener_codigo') IS NOT NULL
	DROP PROCEDURE ZTS_DB.obtener_codigo
GO
CREATE PROCEDURE ZTS_DB.obtener_codigo (@proveedor_id varchar(20),@descripcion varchar(255),@precio_oferta numeric(12,2),@precio_lista numeric(12,2))
as begin
declare @codigo varchar(50) = (select top 1 Codigo_Oferta from ZTS_DB.OFERTAS where Proveedor_referenciado = @proveedor_id and Descripcion =@descripcion and Cantidad_disponible > 0
and Precio_lista=@precio_lista and Precio_oferta =@precio_oferta)
if exists(select 1 from ZTS_DB.OFERTAS where Codigo_Oferta= @codigo)
throw 50001,@codigo,1
end
GO


IF OBJECT_ID('oferta_existente') IS NOT NULL
	DROP PROCEDURE ZTS_DB.oferta_existente
GO
CREATE PROCEDURE ZTS_DB.oferta_existente (@ofertaCodigo varchar(255))
AS BEGIN
IF not exists (SELECT 1 FROM ZTS_DB.OFERTAS WHERE Codigo_Oferta = @ofertaCodigo)
	BEGIN
		THROW 90001,'La oferta ingresada no es correcta.',1
	END
END
GO


IF OBJECT_ID('oferta_disponible') IS NOT NULL
	DROP PROCEDURE ZTS_DB.oferta_disponible
GO
CREATE PROCEDURE ZTS_DB.oferta_disponible (@cuponId varchar(255), @ofertaFecha datetime) 
AS BEGIN
	DECLARE @ofertaCodigo VARCHAR(255)
	SET @ofertaCodigo = (SELECT Codigo_oferta FROM ZTS_DB.CUPONES WHERE Cupon_Id = @cuponId)
	IF not exists (SELECT 1 FROM ZTS_DB.OFERTAS
	WHERE convert(datetime,@ofertaFecha,121) between Fecha_publicacion and Fecha_Vencimiento and Codigo_Oferta = @ofertaCodigo)
		BEGIN
			THROW 90002,'La oferta se ha Vencido. No se puede canjear el cupon.',1
		END
END
GO

IF OBJECT_ID('verificar_proveedor') IS NOT NULL
	DROP PROCEDURE ZTS_DB.verificar_proveedor
GO
CREATE PROCEDURE ZTS_DB.verificar_proveedor (@cuponId varchar(255), @proveedor varchar(255))
AS BEGIN
	DECLARE @proveedorId VARCHAR(255)
	SET @proveedorId = (SELECT Proveedor_Id FROM ZTS_DB.PROVEEDORES WHERE username = @proveedor)
	IF not exists (SELECT 1 FROM ZTS_DB.CUPONES c 
					JOIN ZTS_DB.OFERTAS o ON o.Codigo_Oferta = c.Codigo_oferta
					WHERE @cuponId = c.Cupon_Id
					AND @proveedorId = o.Proveedor_referenciado)
	BEGIN
		THROW 90003,'Este cupon no le pertenece.',1
	END
END
GO


IF OBJECT_ID('utilizar_cupon') IS NOT NULL
	DROP PROCEDURE ZTS_DB.utilizar_cupon
GO
CREATE PROCEDURE ZTS_DB.utilizar_cupon(@cuponId varchar(255), @fecha datetime)
AS BEGIN
	UPDATE ZTS_DB.CUPONES SET Fecha_Consumo = @fecha
	WHERE Cupon_Id = @cuponId
END
GO

IF OBJECT_ID('cupon_utilizado') IS NOT NULL
	DROP PROCEDURE ZTS_DB.cupon_utilizado
GO
CREATE PROCEDURE ZTS_DB.cupon_utilizado(@cuponId varchar(255))
AS BEGIN
IF (SELECT count(1) from CUPONES where Cupon_Id = @cuponId AND Fecha_Consumo IS NOT NULL)>0
	BEGIN
		THROW 90003,'El cupon ya fue utilizado.',1
	END
END
GO

-------------------------------------------------------------------------------
----LISTADO ESTADISTICO--------------------------------------------------------
-------------------------------------------------------------------------------

IF OBJECT_ID('suma_porcentajes_de_ofertas') IS NOT NULL
	DROP function ZTS_DB.suma_porcentajes_de_ofertas
GO
create function ZTS_DB.suma_porcentajes_de_ofertas(@proveedor varchar(20),@fecha1 datetime,@fecha2 datetime)
returns numeric(10,2)
as begin
declare @porcentaje numeric(10,2)

set @porcentaje = (select sum( 100 - (precio_oferta * 100 / precio_lista)) from ZTS_DB.OFERTAS where Proveedor_referenciado = @proveedor and Fecha_publicacion
between CONVERT(datetime,@fecha1,121) and  CONVERT(datetime,@fecha2, 121))
return @porcentaje
end
GO

IF OBJECT_ID('suma_facturacion_proveedor') IS NOT NULL
	DROP function ZTS_DB.suma_facturacion_proveedor
GO
create function ZTS_DB.suma_facturacion_proveedor(@proveedor varchar(20),@fecha1 datetime,@fecha2 datetime)
returns numeric(10,2)
as begin
declare @facturacionTotal numeric(10,2)

set @facturacionTotal = (select  sum(Precio_oferta * cantidad) from ZTS_DB.COMPRAS c join ZTS_DB.OFERTAS o on  c.Codigo_oferta = o.Codigo_Oferta
where Fecha_compra  between CONVERT(datetime,@fecha1,121)  and  CONVERT(datetime,@fecha2, 121) and Factura_Id is not null 
and o.Proveedor_referenciado = @proveedor)

return @facturacionTotal
end
GO


/*
DROP TABLE ZTS_DB.CARGAS
DROP TABLE ZTS_DB.CUPONES
DROP TABLE ZTS_DB.COMPRAS
DROP TABLE ZTS_DB.OFERTAS
DROP TABLE ZTS_DB.FACTURAS
DROP TABLE ZTS_DB.FUNCIONES_POR_ROL
DROP TABLE ZTS_DB.FUNCIONES
DROP TABLE ZTS_DB.ROLES_POR_USUARIO
DROP TABLE ZTS_DB.ROLES
DROP TABLE ZTS_DB.TARJETAS
DROP TABLE ZTS_DB.PROVEEDORES
DROP TABLE ZTS_DB.CLIENTES
DROP TABLE ZTS_DB.DIRECCION
DROP TABLE ZTS_DB.USUARIOS
DROP TABLE ZTS_DB.RUBROS

*/




