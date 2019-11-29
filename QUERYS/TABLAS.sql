use GD2C2019
select * from gd_esquema.Maestra


--FORMA DE BORRAR TODO DE UNA
/*
drop table FUNCIONES_POR_ROL
drop table FUNCIONES
drop table ROLES_POR_USUARIO
drop table ROLES
drop table CLIENTES
drop table RUBROS
drop table PROVEEDORES
drop table DIRECCION
drop table USUARIOS
*/

----CREACION DE TABLAS-------------
 ---USUARIOS--------------------
CREATE TABLE USUARIOS
( Username varchar(255) not null,
  Password	varchar(255) not null,
  Estado varchar(255) default 'Habilitado'
  PRIMARY KEY(Username)
)
--Usuario ADMIN GENERAL
insert into USUARIOS (username,Password) values ('ADMIN_ALL',HASHBYTES('SHA2_256','frba1234'))

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
  FOREIGN KEY(username) REFERENCES Usuarios(username)
)

INSERT INTO CLIENTES (Nombre, Apellido,DNI,direccion,Telefono,Mail,Fecha_Nacimiento)
(SELECT DISTINCT Cli_Nombre, Cli_apellido,Cli_Dni,
(SELECT Id_direccion from DIRECCION where Direccion = Cli_Direccion),
Cli_Telefono,Cli_Mail,Cli_Fecha_Nac from gd_esquema.Maestra )

insert into USUARIOS (Username, Password) 
(select  Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3)), HASHBYTES('SHA2_256',(cast(dni as varchar))) from CLIENTES)

--No borrar x las dudas!!
--insert into USUARIOS (Username, Password) 
--(select  ltrim(rtrim(Nombre)) + ltrim(rtrim(SUBSTRING(convert(varchar(15),DNI),1,3))), HASHBYTES('SHA2_256',ltrim(rtrim(cast(dni as char)))) from CLIENTES)

update CLIENTES 
set username = B.username from CLIENTES as A,USUARIOS as B where B.Username = Nombre + (SUBSTRING(convert(varchar(15),DNI),1,3))



---PROVEEDORES--------------------------
CREATE TABLE PROVEEDORES
(	Indice INT IDENTITY(1,1) NOT NULL,
	Proveedor_Id AS 'ProveedorID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Razon_Social varchar(255) unique not null,
	username varchar(255) default null,
	Direccion int,
	Telefono numeric(18,0),
	CUIT varchar(255) unique not null,	
	Mail varchar(255),
	Nombre_contacto varchar(255),
	Estado varchar(255) default 'Habilitado'
	PRIMARY KEY(Proveedor_Id),
	FOREIGN KEY(Direccion) REFERENCES Direccion(id_direccion)
)

INSERT INTO PROVEEDORES
(Razon_Social,Direccion,Telefono,CUIT)
(select distinct Provee_RS,(SELECT Id_direccion from DIRECCION where Direccion = Provee_Dom),Provee_Telefono,Provee_CUIT from gd_esquema.Maestra
where provee_Rs is not null)


insert into USUARIOS (Username, Password) 
(select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)),HASHBYTES('SHA2_256',(CUIT)) from PROVEEDORES)

update PROVEEDORES 
set username = B.username from PROVEEDORES as A,USUARIOS as B where B.Username =  (select 'pr' + ltrim(rtrim(cast(Indice as char))) + (SUBSTRING(cast(CUIT as varchar),1,4)) )


-----------RUBROS------------------
CREATE TABLE RUBROS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Rubro_Id AS 'RubroID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Proveedor_Id varchar(19),
	rubro_descripcion varchar(255)
	PRIMARY KEY(Rubro_Id),
	FOREIGN KEY(Proveedor_Id) REFERENCES PROVEEDORES(Proveedor_Id)
)

INSERT INTO RUBROS (Proveedor_Id,rubro_descripcion)
(SELECT DISTINCT Proveedor_Id,Provee_Rubro from gd_esquema.Maestra f join proveedores p on f.Provee_RS=p.Razon_Social)



---OFERTA---------------
CREATE TABLE OFERTAS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Oferta_Id AS 'OfertaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Precio_oferta numeric (18,2) not null,
	Precio_lista numeric(18,2) not null,
	Fecha_publicacion datetime not null,
	Fecha_Vencimiento datetime not null,
	Descripcion varchar(255),
	Cantidad_disponible numeric(18,0),
	cantidad_maxima_por_usuario int,
	Codigo varchar(255) not null,
	Proveedor_referenciado varchar(19)
	PRIMARY KEY(Oferta_Id),
	FOREIGN KEY(Proveedor_referenciado) REFERENCES PROVEEDORES (Proveedor_Id)
)


INSERT INTO OFERTAS
(Proveedor_referenciado,Precio_oferta,Precio_Lista,fecha_publicacion,fecha_vencimiento,descripcion,cantidad_disponible,cantidad_maxima_por_usuario,codigo)
(select distinct p.Proveedor_id, Oferta_Precio, Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Descripcion,Oferta_Cantidad,Oferta_Cantidad,Oferta_Codigo from gd_esquema.Maestra gd join proveedores p
on gd.Provee_rs = p.razon_social
where gd.Oferta_Codigo is not null )


---------------TARJETA------------

CREATE TABLE TARJETAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Tarjeta_Id AS 'TarjetaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Cliente_Id varchar(17),
  Numero_Tarjeta numeric(20),
  Codigo_Seguridad numeric(3),
  tipo_Tarjeta varchar(255)
  PRIMARY KEY(Tarjeta_Id)
  FOREIGN KEY(Cliente_Id) references CLIENTES(Cliente_Id)
)



INSERT INTO TARJETAS (Cliente_Id,tipo_Tarjeta)
(select DISTINCT Cliente_Id,Tipo_Pago_Desc from gd_esquema.Maestra gd join CLIENTES c on gd.Cli_Nombre = c.Nombre
where Tipo_Pago_Desc is not null)

---CUENTA----------------
CREATE TABLE CARGAS
(
	Indice INT IDENTITY(1,1) NOT NULL,
	Carga_Id AS 'CargaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Tarjeta_Id varchar(17),
	Fecha datetime not null,
	Monto numeric(10,0) not null,
	Tipo_Pago varchar(255) not null
	PRIMARY KEY(Carga_Id)
	FOREIGN KEY(Tarjeta_Id) REFERENCES TARJETAS(Tarjeta_Id)
)


INSERT INTO CARGAS (Tarjeta_Id,Fecha,Monto,Tipo_Pago)
(select  distinct t.tarjeta_id ,Carga_fecha, Carga_Credito, Tipo_Pago_Desc from gd_esquema.Maestra gd 
join clientes c on gd.Cli_Nombre = c.nombre
join TARJETAS t on c.Cliente_Id = t.cliente_id
where Carga_Fecha is not null)



---FACTURAS---------------------
CREATE TABLE FACTURAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Factura_Id AS 'FacturaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Proveedor_Id varchar(19) not null,
  Fecha datetime not null,
  Numero bigint not null
  PRIMARY KEY(Factura_Id)
  FOREIGN KEY(Proveedor_Id) REFERENCES PROVEEDORES(Proveedor_Id)
)


INSERT INTO FACTURAS
(Proveedor_Id,FECHA,Numero)
(select p.proveedor_id,Factura_Fecha,Factura_Nro  from gd_esquema.Maestra gd join Proveedores p
on gd.Provee_RS = p.razon_social
 where Factura_Nro is not null)


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

---FUNCIONES------------------
CREATE TABLE FUNCIONES
(Indice INT IDENTITY(1,1) NOT NULL,
  Funcion_Id AS 'FuncionID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Descripcion varchar(255),
  Bit_de_Restriccion smallint not null
  PRIMARY KEY(Funcion_Id)
)
--BIT 0 Puede ser usada por cualquier usuario
--BIT 1 Puede ser usada por clientes solamente
--BIT 2 Puede ser usada por Proveedores solamente	
--BIT 3 Puede ser usada por Administradores solamente

insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('ABM Roles',3)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('ABM Clientes',0)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('ABM Proveedores',0)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Listado Estadistico',0)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Comprar Oferta',1)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Registrar Usuarios',0)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Cargar Credito',1)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Confeccion y Publicacion de Ofertas',2)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Entrega/Consumo de Oferta',1)
insert into FUNCIONES (Descripcion,Bit_de_Restriccion) values ('Facturar a Proveedor',3)


---Funcione Por Rol------------
CREATE TABLE FUNCIONES_POR_ROL
(Rol_Id varchar(255) not null,
 Funcion_Id varchar(17) not null
 FOREIGN KEY(Rol_Id) REFERENCES ROLES(Rol_Id),
 FOREIGN KEY(Funcion_Id) REFERENCES FUNCIONES(Funcion_Id)
)

insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Cliente','FuncionID5')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Cliente','FuncionID7')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Proveedor','FuncionID8')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID6')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID8')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID4')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID10')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID1')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID2')
insert into FUNCIONES_POR_ROL (Rol_Id, Funcion_Id) values('Administrador','FuncionID3')




---COMPRAS----------------------
CREATE TABLE COMPRAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Compra_Id AS 'CompraID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Oferta_Id varchar(16),
  Cliente_Id varchar(17),
  Fecha_compra datetime not null,
  PRIMARY KEY(Compra_Id),
  FOREIGN KEY(Cliente_Id) REFERENCES CLIENTES(Cliente_Id),
  FOREIGN KEY(Oferta_Id) REFERENCES OFERTAS(Oferta_Id)
)



insert into compras(oferta_id,cliente_id,fecha_Compra)
(select distinct o.oferta_id,cliente_id,oferta_Fecha_compra from gd_esquema.Maestra gd join ofertas o on gd.Oferta_Codigo = o.codigo
join CLIENTES c on gd.Cli_Dni = c.DNI)


---CUPONES----------------------
CREATE TABLE CUPONES
( Indice INT IDENTITY(1,1) NOT NULL,
  Cupon_Id AS 'CuponID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Oferta_Id varchar(16),
  Compra_Id varchar(16),
  Fecha_Consumo datetime,
  PRIMARY KEY(Cupon_Id),
  FOREIGN KEY(Compra_Id) REFERENCES COMPRAS(Compra_Id),
  FOREIGN KEY(Oferta_Id) REFERENCES OFERTAS(Oferta_Id)
)


insert into CUPONES (Oferta_Id,Compra_Id,Fecha_Consumo)
(select distinct c.oferta_id,compra_id, Oferta_Entregado_Fecha from gd_esquema.Maestra gd
join COMPRAS  c on Fecha_compra = gd.Oferta_Fecha_Compra
where gd.Oferta_Fecha_Compra is not null)


drop table CUPONES


