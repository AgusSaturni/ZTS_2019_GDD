use GD2C2019

SELECT *  FROM gd_esquema.Maestra 

select * from USUARIOS

----CREACION DE TABLAS-------------


 ---USUARIOS--------------------
CREATE TABLE USUARIOS
( Username char(50) not null,
  Password	char(255) not null,
  Estado char(20) default 'Habilitado'
  PRIMARY KEY(Username)
)


---Direccion---------------------------
CREATE TABLE DIRECCION
(
	Id_Direccion INT IDENTITY(0,1) PRIMARY KEY not null,
    Direccion char(100) not null,
    Codigo_Postal int ,
    Localidad char(50),
    Ciudad char (50) not null,
    Numero_Piso int,
    Depto char(10)
)

insert into direccion(Direccion,Ciudad)
SELECT DISTINCT Cli_Direccion,Cli_Ciudad FROM gd_esquema.Maestra


insert into direccion(Direccion,Ciudad)
SELECT DISTINCT Provee_Dom,Provee_Ciudad FROM gd_esquema.Maestra where Provee_Ciudad is not null

----CLIENTE----------------
CREATE TABLE CLIENTES
( Indice INT IDENTITY(1,1) NOT NULL ,
  Cliente_Id AS 'ClienteID' +  CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  username char(50) default null,
  Nombre char(50) not null,
  Apellido char (50) not null,
  DNI numeric(18,0) not null,
  Direccion int,
  Telefono numeric(18,0),
  Mail	char(50),			
  Fecha_Nacimiento datetime,
  DineroDisponible int default 200,
  Estado char(20) default 'Habilitado'
  PRIMARY KEY(CLIENTE_Id),
  FOREIGN KEY(Direccion) REFERENCES Direccion(Id_Direccion),
  FOREIGN KEY(username) REFERENCES Usuarios(username)
)



INSERT INTO CLIENTES (Nombre, Apellido,DNI,direccion,Telefono,Mail,Fecha_Nacimiento)
(SELECT DISTINCT Cli_Nombre, Cli_apellido,Cli_Dni,
(SELECT Id_direccion from DIRECCION where Direccion = Cli_Direccion),
Cli_Telefono,Cli_Mail,Cli_Fecha_Nac from gd_esquema.Maestra )

insert into USUARIOS (Username, Password) 
(select ltrim(rtrim(nombre)) + SUBSTRING(convert(char(15),DNI),1,3), HASHBYTES('SHA2_256',cast(dni as char)) from CLIENTES)

update CLIENTES 
set username = B.username from CLIENTES as A,USUARIOS as B where B.Username = ltrim(rtrim(nombre)) + SUBSTRING(convert(char(15),DNI),1,3)



---PROVEEDORES--------------------------
CREATE TABLE PROVEEDORES
(	Indice INT IDENTITY(1,1) NOT NULL,
	Proveedor_Id AS 'ProveedorID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Razon_Social char(50) unique not null,
	username char(50) default null,
	Direccion int,
	Telefono numeric(18,0),
	CUIT char(20) unique not null,	
	Mail char(50),
	Nombre_contacto char(50),
	Estado char(20) default 'Habilitado'
	PRIMARY KEY(Proveedor_Id),
	FOREIGN KEY(Direccion) REFERENCES Direccion(id_direccion)
)

INSERT INTO PROVEEDORES
(Razon_Social,Direccion,Telefono,CUIT)
(select distinct Provee_RS,(SELECT Id_direccion from DIRECCION where Direccion = Provee_Dom),Provee_Telefono,Provee_CUIT from gd_esquema.Maestra
where provee_Rs is not null)


insert into USUARIOS (Username, Password) 
(select ltrim(rtrim(Razon_Social)) + SUBSTRING(convert(char(15),CUIT),1,3),HASHBYTES('SHA2_256',CUIT) from PROVEEDORES)



-----------RUBROS------------------
CREATE TABLE RUBROS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Rubro_Id AS 'RubroID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Proveedor_Id varchar(19),
	rubro_descripcion char(50)
	PRIMARY KEY(Rubro_Id),
	FOREIGN KEY(Proveedor_Id) REFERENCES PROVEEDORES(Proveedor_Id)
)

INSERT INTO RUBROS (Proveedor_Id,rubro_descripcion)
(SELECT DISTINCT Proveedor_Id,Provee_Rubro from gd_esquema.Maestra f join proveedores p on f.Provee_RS=p.Razon_Social)


---ADMINISTRATIVOS--------------
CREATE TABLE ADMINISTRATIVOS
	(Indice INT IDENTITY(1,1) NOT NULL,
	Administrativo_Id AS 'AdministrativoID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	PRIMARY KEY(Administrativo_Id)
	)


---OFERTA---------------
CREATE TABLE OFERTAS
(	Indice INT IDENTITY(1,1) NOT NULL,
	Oferta_Id AS 'OfertaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
	Precio_oferta numeric (18,2) not null,
	Precio_lista numeric(18,2) not null,
	Fecha_publicacion datetime not null,
	Fecha_Vencimiento datetime not null,
	Descripcion char(255),
	Cantidad_disponible numeric(18,0),
	Fecha_Compra datetime,
	Codigo char(50) not null,
	Proveedor_referenciado varchar(19)
	PRIMARY KEY(Oferta_Id),
	FOREIGN KEY(Proveedor_referenciado) REFERENCES PROVEEDORES (Proveedor_Id)
)

INSERT INTO OFERTAS
(Proveedor_referenciado,Precio_oferta,Precio_Lista,fecha_publicacion,fecha_vencimiento,descripcion,cantidad_disponible,fecha_compra,codigo)
(select p.Proveedor_id, Oferta_Precio, Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Descripcion,Oferta_Cantidad,Oferta_Fecha_Compra,Oferta_Codigo from gd_esquema.Maestra gd join proveedores p
on gd.Provee_rs = p.razon_social
where gd.Oferta_Codigo is not null )

---------------TARJETA------------

CREATE TABLE TARJETAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Tarjeta_Id AS 'TarjetaID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Cliente_Id varchar(17),
  Numero_Tarjeta numeric(20),
  Codigo_Seguridad numeric(3),
  tipo_Tarjeta char(20)
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
	Tipo_Pago char(50) not null
	PRIMARY KEY(Carga_Id)
	FOREIGN KEY(Tarjeta_Id) REFERENCES TARJETAS(Tarjeta_Id)
)



INSERT INTO CARGAS (Tarjeta_Id,Fecha,Monto,Tipo_Pago)
(select  t.tarjeta_id ,Carga_fecha, Carga_Credito, Tipo_Pago_Desc from gd_esquema.Maestra gd 
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
(Rol_Id char(20) not null
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
 Rol_Id char(20),
 Username char(50)
 FOREIGN KEY(Rol_Id) references Roles(Rol_Id),
 FOREIGN KEY(Username) References Usuarios(Username)
)

insert into ROLES_POR_USUARIO (Rol_Id, Username) (select 'Cliente',username from CLIENTES)
insert into ROLES_POR_USUARIO (Rol_Id, Username) (select 'Proveedor',username from PROVEEDORES)


---FUNCIONES------------------
CREATE TABLE FUNCIONES
(Indice INT IDENTITY(1,1) NOT NULL,
  Funcion_Id AS 'FuncionID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Descripcion char(255)
  PRIMARY KEY(Funcion_Id)
)

---Funcione Por Rol------------
CREATE TABLE FUNCIONES_POR_ROL
(Rol_Id char(20) not null,
 Funcion_Id varchar(17) not null
 FOREIGN KEY(Rol_Id) REFERENCES ROLES(Rol_Id),
 FOREIGN KEY(Funcion_Id) REFERENCES FUNCIONES(Funcion_Id)
)


---COMPRAS----------------------
CREATE TABLE COMPRAS
( Indice INT IDENTITY(1,1) NOT NULL,
  Compra_Id AS 'CompraID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Oferta_Id varchar(16),
  Cliente_Id varchar(17),
  Fecha datetime not null,
  Cantidad numeric(18,0) not null
  PRIMARY KEY(Compra_Id)
  FOREIGN KEY(Cliente_Id) REFERENCES CLIENTES(Cliente_Id),
  FOREIGN KEY(Oferta_Id) REFERENCES OFERTAS(Oferta_Id)
)

---CUPONES----------------------
CREATE TABLE CUPONES
( Indice INT IDENTITY(1,1) NOT NULL,
  Cupon_Id AS 'CuponID' + CAST(Indice AS VARCHAR(8)) PERSISTED not null,
  Compra_Id varchar(16),
  Fecha_Consumo datetime not null,
  Fecha_Vencimiento datetime not null
  PRIMARY KEY(Cupon_Id)
  FOREIGN KEY(Compra_Id) REFERENCES COMPRAS(Compra_Id)
)




