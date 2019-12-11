use GD2C2019
select * from gd_esquema.Maestra


--FORMA DE BORRAR TODO DE UNA
/*
DROP TABLE CARGAS
DROP TABLE CUPONES
DROP TABLE COMPRAS
DROP TABLE FACTURAS
DROP TABLE FUNCIONES_POR_ROL
DROP TABLE FUNCIONES
DROP TABLE OFERTAS
DROP TABLE ROLES_POR_USUARIO
DROP TABLE ROLES
DROP TABLE RUBROS
DROP TABLE PROVEEDORES
DROP TABLE TARJETAS
DROP TABLE CLIENTES
DROP TABLE DIRECCION
DROP TABLE USUARIOS
*/
select distinct Proveedor_Id, rubro_descripcion from RUBROS
----CREACION DE TABLAS-------------

---Direccion---------------------------
CREATE TABLE DIRECCION
(
	Id_Direccion INT IDENTITY(0,1) PRIMARY KEY not null,
    Direccion varchar(255) not null,
    Codigo_Postal int ,
    Localidad varchar(255),
    Ciudad varchar(255) not null,
    Numero_Piso int,
    Depto varchar(255)
)

insert into direccion(Direccion,Ciudad)
SELECT DISTINCT Cli_Direccion,Cli_Ciudad FROM gd_esquema.Maestra

insert into direccion(Direccion,Ciudad)
SELECT DISTINCT Provee_Dom,Provee_Ciudad FROM gd_esquema.Maestra where Provee_Ciudad is not null

 ---USUARIOS--------------------
CREATE TABLE USUARIOS
( Username varchar(255) not null,
  Password	varchar(255) not null,
  Estado varchar(255) default 'Habilitado'
  PRIMARY KEY(Username)
)
--Usuario ADMIN GENERAL
insert into USUARIOS (username,Password) values ('ADMIN_ALL',HASHBYTES('SHA2_256','frba1234'))
insert into USUARIOS (username,Password) values ('.',HASHBYTES('SHA2_256','.'))

----CLIENTE----------------
CREATE TABLE CLIENTES
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
  FOREIGN KEY(Direccion) REFERENCES Direccion(Id_Direccion),
  FOREIGN KEY(username) REFERENCES Usuarios(username),
)

INSERT INTO CLIENTES (Nombre, Apellido,DNI,direccion,Telefono,Mail,Fecha_Nacimiento)
(SELECT DISTINCT Cli_Nombre, Cli_apellido,Cli_Dni,
(SELECT Id_direccion from DIRECCION where Direccion = Cli_Direccion),
Cli_Telefono,Cli_Mail,Cli_Fecha_Nac from gd_esquema.Maestra )

insert into USUARIOS (Username, Password) 
(select  Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3)), HASHBYTES('SHA2_256',(cast(dni as varchar))) from CLIENTES)

update CLIENTES 
set username = B.username from CLIENTES as A,USUARIOS as B where B.Username = Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3))



---PROVEEDORES--------------------------
CREATE TABLE PROVEEDORES
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
	FOREIGN KEY(Direccion) REFERENCES Direccion(id_direccion),
	FOREIGN KEY(Rubro_Id) REFERENCES RUBROS(Rubro_Id)
)

INSERT INTO PROVEEDORES
(Razon_Social,Direccion,Telefono,CUIT, Rubro_Id)
(select distinct Provee_RS,(SELECT Id_direccion from DIRECCION where Direccion = Provee_Dom),
Provee_Telefono,
Provee_CUIT,
(select Rubro_Id from RUBROS where rubro_descripcion = Provee_Rubro)
from gd_esquema.Maestra
where provee_Rs is not null)

insert into USUARIOS (Username, Password) 
(select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)),HASHBYTES('SHA2_256',(CUIT)) from PROVEEDORES)

update PROVEEDORES 
set username = B.username from PROVEEDORES as A,USUARIOS as B where B.Username =  (select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)) )

Update PROVEEDORES
set Mail = (username + '@gmail.com')



---------------TARJETA------------
CREATE TABLE TARJETAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Tarjeta_Id AS 'TarjetaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Numero_Tarjeta numeric(20),
  Codigo_Seguridad numeric(3),
  tipo_Tarjeta varchar(255)
  PRIMARY KEY(Tarjeta_Id)
)

INSERT INTO TARJETAS (tipo_Tarjeta)
(select DISTINCT Tipo_Pago_Desc from gd_esquema.Maestra gd
where Tipo_Pago_Desc is not null)

-----------RUBROS------------------
CREATE TABLE RUBROS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Rubro_Id AS 'RubroID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	rubro_descripcion varchar(255)
	PRIMARY KEY(Rubro_Id),
)

INSERT INTO RUBROS (rubro_descripcion)
(SELECT DISTINCT Provee_Rubro from gd_esquema.Maestra where Provee_Rubro is not null)


--ROLES--
CREATE TABLE ROLES
(Rol_Id varchar(255) not null,
Estado varchar(255) default 'Habilitado' not null
PRIMARY KEY(Rol_Id)				
)

insert into ROLES(Rol_Id)
values('Administrador')

insert into ROLES(Rol_Id)
values('Cliente')

insert into ROLES(Rol_Id)
values('Proveedor')


---ROLES POR USUARIO------------
CREATE TABLE ROLES_POR_USUARIO
(
 Rol_Id varchar(255),
 Username varchar(255)
 FOREIGN KEY(Rol_Id) references Roles(Rol_Id),
 FOREIGN KEY(Username) References Usuarios(Username)
)

insert into ROLES_POR_USUARIO (Rol_Id, Username) (select 'Cliente',username from CLIENTES)
insert into ROLES_POR_USUARIO (Rol_Id, Username) (select 'Proveedor',username from PROVEEDORES)
insert into ROLES_POR_USUARIO (Rol_Id, Username) values('Administrador','ADMIN_ALL')
insert into ROLES_POR_USUARIO (Rol_Id, Username) values('Administrador','.')

---OFERTA---------------
CREATE TABLE OFERTAS
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
	FOREIGN KEY(Proveedor_referenciado) REFERENCES PROVEEDORES (Proveedor_Id)
)


INSERT INTO OFERTAS
(Codigo_Oferta,Proveedor_referenciado,Precio_oferta,Precio_Lista,fecha_publicacion,fecha_vencimiento,descripcion,cantidad_disponible,cantidad_maxima_por_usuario)
(select distinct Oferta_Codigo, p.Proveedor_id, Oferta_Precio, Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Descripcion,Oferta_Cantidad,Oferta_Cantidad 
from gd_esquema.Maestra gd join proveedores p
on gd.Provee_rs = p.razon_social
where gd.Oferta_Codigo is not null )


---CUENTA----------------

CREATE TABLE CARGAS
(
	Indice INT IDENTITY(1,1) NOT NULL,
	Carga_Id AS 'CargaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Cliente_Id varchar(17),
	Tarjeta_Id varchar(17),
	Fecha datetime not null,
	Monto numeric(10,0) not null,
	PRIMARY KEY(Carga_Id),
	FOREIGN KEY(Cliente_Id) references CLIENTES(Cliente_Id),
	FOREIGN KEY(Tarjeta_Id) REFERENCES TARJETAS(Tarjeta_Id)
)

INSERT INTO CARGAS (Cliente_Id,Fecha,Monto,Tarjeta_Id)
(SELECT C.Cliente_Id,
gd.Carga_Fecha,
gd.Carga_Credito,
T.Tarjeta_Id
from gd_esquema.Maestra gd
JOIN CLIENTES C on gd.Cli_Dni = C.DNI 
JOIN TARJETAS T on T.tipo_Tarjeta = gd.Tipo_Pago_Desc
where gd.Carga_Fecha is not null and gd.Carga_Credito is not null and gd.Tipo_Pago_Desc is not null)

---FACTURAS---------------------
CREATE TABLE FACTURAS
( 
	Numero bigint not null,
	Proveedor_Id varchar(19) not null,
	Fecha datetime not null,
	ImporteTotal numeric(20,2),
	PRIMARY KEY(Numero),
	FOREIGN KEY(Proveedor_Id) REFERENCES PROVEEDORES(Proveedor_Id)
)

drop table FACTURAS


INSERT INTO FACTURAS
(Proveedor_Id,FECHA, Numero,ImporteTotal)
(select  p.proveedor_id,Factura_Fecha, Factura_Nro,sum(Oferta_Precio) from gd_esquema.Maestra gd join Proveedores p
on gd.Provee_RS = p.razon_social
where Factura_Nro is not null
group by Factura_Fecha,Factura_Nro,p.Proveedor_Id)
 
---FUNCIONES------------------
CREATE TABLE FUNCIONES
(Indice INT IDENTITY(1,1) NOT NULL,
  Funcion_Id AS 'FuncionID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Descripcion varchar(255)
  PRIMARY KEY(Funcion_Id)
)

drop table FUNCIONES


insert into FUNCIONES (Descripcion) values ('ABM Roles')
insert into FUNCIONES (Descripcion) values ('ABM Clientes')
insert into FUNCIONES (Descripcion) values ('ABM Proveedores')
insert into FUNCIONES (Descripcion) values ('Listado Estadistico')
insert into FUNCIONES (Descripcion) values ('Comprar Oferta')
insert into FUNCIONES (Descripcion) values ('Registrar Usuarios')
insert into FUNCIONES (Descripcion) values ('Cargar Credito')
insert into FUNCIONES (Descripcion) values ('Confeccion y Publicacion de Ofertas')
insert into FUNCIONES (Descripcion) values ('Entrega/Consumo de Oferta')
insert into FUNCIONES (Descripcion) values ('Facturar a Proveedor')


---Funcione Por Rol------------
CREATE TABLE FUNCIONES_POR_ROL
(Rol_Id varchar(255) not null,
 Funcion_Id varchar(17) not null
 FOREIGN KEY(Rol_Id) REFERENCES ROLES(Rol_Id),
 FOREIGN KEY(Funcion_Id) REFERENCES FUNCIONES(Funcion_Id)
)


--CAMBIAR A DINAMICAMENTE
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Cliente','FuncionID5')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Cliente','FuncionID7')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Proveedor','FuncionID8')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Proveedor','FuncionID9')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID6')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID8')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID4')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID10')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID1')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID2')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID3')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID7')


drop table FUNCIONES_POR_ROL

---COMPRAS----------------------
CREATE TABLE COMPRAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Compra_Id AS 'CompraID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Codigo_oferta varchar(255),
  Cliente_Id varchar(17),
  Fecha_compra datetime not null,
  Cantidad SMALLINT,
  PRIMARY KEY(Compra_Id),
  FOREIGN KEY(Cliente_Id) REFERENCES CLIENTES(Cliente_Id),
  FOREIGN KEY(Codigo_oferta) REFERENCES OFERTAS(Codigo_oferta)
)

insert into compras(Codigo_oferta,cliente_id,fecha_Compra, Cantidad)
(select distinct o.Codigo_oferta,cliente_id,oferta_Fecha_compra, 1 from gd_esquema.Maestra gd join ofertas o on gd.Oferta_Codigo = o.Codigo_oferta
join CLIENTES c on gd.Cli_Dni = c.DNI)


---CUPONES----------------------
CREATE TABLE CUPONES
( Indice INT IDENTITY(1,1) NOT NULL,
  Cupon_Id AS 'CuponID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Codigo_oferta varchar(255),
  Codigo_cupon varchar(255),
  Compra_Id varchar(16),
  Fecha_Consumo datetime,
  Cantidad_disponible int,
  PRIMARY KEY(Cupon_Id),
  FOREIGN KEY(Compra_Id) REFERENCES COMPRAS(Compra_Id),
  FOREIGN KEY(Codigo_oferta) REFERENCES OFERTAS(Codigo_oferta)
)

--select C.codigo_cupon, C.Codigo_oferta, CL.username ,O.Descripcion ,C.Fecha_Consumo
--from CUPONES C 
--JOIN COMPRAS COMP on COMP.Compra_Id = C.Compra_Id
--JOIN CLIENTES CL on CL.Cliente_Id = COMP.Cliente_Id
--JOIN OFERTAS O on O.Codigo_Oferta = comp.Codigo_oferta AND O.Codigo_Oferta = C.Codigo_oferta
--JOIN PROVEEDORES P on P.Proveedor_Id = O.Proveedor_referenciado

insert into CUPONES(codigo_oferta,Compra_Id, Cantidad_disponible)
(select Codigo_oferta,compra_id, Cantidad from COMPRAS)

update CUPONES 
set cupones.Fecha_Consumo = gd_esquema.Maestra.Oferta_Entregado_Fecha
from
CUPONES  c join COMPRAS cr on c.Compra_Id=cr.Compra_Id
join CLIENTES cli on cr.Cliente_Id=cli.Cliente_Id
join gd_esquema.Maestra  on cli.DNI = gd_esquema.Maestra.Cli_Dni and c.codigo_oferta = gd_esquema.Maestra.Oferta_Codigo
where Oferta_Entregado_Fecha is not null

update CUPONES
set codigo_cupon= (select newId())

