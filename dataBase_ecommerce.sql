--use master
--ALTER DATABASE TP_ECOMMERCE SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--drop database TP_ECOMMERCE



create database TP_ECOMMERCE
go
use TP_ECOMMERCE
go
CREATE TABLE TipoUsuario (
  Id INT NOT NULL IDENTITY(1,1),
  Nombre VARCHAR(50) NOT NULL,
  CONSTRAINT PK_TipoUsuario PRIMARY KEY (Id)
);
go
CREATE TABLE Domicilio (
  Id INT NOT NULL IDENTITY,
  Calle VARCHAR(100) NOT NULL,
  Ciudad VARCHAR(50) NOT NULL,
  Departamento VARCHAR(50),
  Numero INT NOT NULL,
  Piso INT NULL,
  Provincia VARCHAR(50) NOT NULL,
  CodigoPostal INT NOT NULL,
  Referencia TEXT NULL,
  CONSTRAINT PK_Domicilio PRIMARY KEY (Id)
);
go
CREATE TABLE Usuario (
  Id INT NOT NULL IDENTITY(1,1),
  Activo BIT NOT NULL,
  Apellidos VARCHAR(1000) NOT NULL,
  DNI VARCHAR(9) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  Nombres VARCHAR(100) NOT NULL,
  Password VARCHAR(50) NOT NULL,
  Telefono VARCHAR(50) NOT NULL,
  IdTipoUsuario INT NOT NULL,
  IdDomicilio INT NOT NULL,
  CONSTRAINT PK_Usuario PRIMARY KEY (Id),
  CONSTRAINT FK_TipoUsuario FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(Id),
  CONSTRAINT FK_Domicilio FOREIGN KEY (IdDomicilio) REFERENCES Domicilio(Id)
);

go
CREATE TABLE Marcas (
	Id INT IDENTITY(1,1) NOT NULL,
	Descripcion TEXT NULL,
 CONSTRAINT PK_Marcas PRIMARY KEY (Id)
 );

 go
 CREATE TABLE Categorias (
	Id INT IDENTITY(1,1) NOT NULL,
	Descripcion TEXT NULL,
 CONSTRAINT PK_Categorias PRIMARY KEY (Id) 
 );
 go
 CREATE TABLE Articulos (
	Id INT IDENTITY(1,1) NOT NULL,
	Codigo VARCHAR(50) NULL,
	Nombre VARCHAR(50) NULL,
	Descripcion TEXT NULL,
	IdMarca INT NULL,
	IdCategoria INT NULL,
	Precio MONEY NULL,
 CONSTRAINT PK_Articulos PRIMARY KEY (Id),
 CONSTRAINT FK_Marcas FOREIGN KEY (IdMarca) REFERENCES Marcas(Id),
 CONSTRAINT FK_Categorias FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id)
 )
 
 go
create table Imagenes(
	Id INT IDENTITY(1,1) NOT NULL,
	IdArticulo INT NOT NULL,
	ImagenUrl TEXT NOT NULL
	CONSTRAINT PK_Imagenes PRIMARY KEY (Id),
	CONSTRAINT FK_Articulos FOREIGN KEY (IdArticulo) REFERENCES Articulos(Id)
)

go
CREATE TABLE Compras (
  Id INT IDENTITY(1,1) NOT NULL,
  IdUsuario INT NOT NULL,
  FechaCompra DATETIME DEFAULT GETDATE(),
  CodigoSeguimiento VARCHAR(100) NULL,
  CONSTRAINT PK_Compras PRIMARY KEY (Id),
  CONSTRAINT FK_Usuario_Compra FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);
go
CREATE TABLE DetalleCompra (
  IdCompra INT NOT NULL,
  IdArticulo INT NOT NULL,
  Cantidad INT NOT NULL,
  PrecioUnitario MONEY NOT NULL,
  Total MONEY NOT NULL,
  CONSTRAINT FK_Compra FOREIGN KEY (IdCompra) REFERENCES Compras(Id),
  CONSTRAINT FK_Articulo FOREIGN KEY (IdArticulo) REFERENCES Articulos(Id)
);
go   
ALTER TABLE Compras
ADD Estado VARCHAR(50) NULL

ALTER TABLE Compras
ADD Total MONEY NOT NULL DEFAULT(0)

ALTER TABLE Compras
ADD Envio BIT NOT NULL DEFAULT(0)

ALTER TABLE Articulos
ALTER COLUMN Nombre VARCHAR(254) NULL 