use TP_ECOMMERCE
go
-- Insertar TipoUsuario
INSERT INTO TipoUsuario (Nombre) VALUES ('Administrador');
INSERT INTO TipoUsuario (Nombre) VALUES ('Cliente');
go
-- Insertar Domicilios
INSERT INTO Domicilio (Calle, Ciudad, Departamento, Numero, Piso, Provincia, Referencia, CodigoPostal)
VALUES ('Calle 1', 'Ciudad 1', 'Dep 1', 123, 2, 'Provincia 1', 'Referencia 1', 1718);

INSERT INTO Domicilio (Calle, Ciudad, Departamento, Numero, Piso, Provincia, Referencia, CodigoPostal)
VALUES ('Calle 2', 'Ciudad 2', 'Dep 2', 456, 3, 'Provincia 2', 'Referencia 2', 1718);
go
-- Insertar Usuarios
INSERT INTO Usuario (Activo, Apellidos, DNI, Email, FechaNacimiento, Nombres, Password, Telefono, IdTipoUsuario, IdDomicilio)
VALUES (1, 'Apellido1', '123456789', 'usuario1@email.com', '1990-01-01', 'Nombre1', 'password1', '123456789', 1, 1);

INSERT INTO Usuario (Activo, Apellidos, DNI, Email, FechaNacimiento, Nombres, Password, Telefono, IdTipoUsuario, IdDomicilio)
VALUES (1, 'Apellido2', '987654321', 'usuario2@email.com', '1995-02-15', 'Nombre2', 'password2', '987654321', 2, 2);

go
-- Insertar Marcas
INSERT INTO Marcas (Descripcion) VALUES ('Nvidia');
INSERT INTO Marcas (Descripcion) VALUES ('Rayzen');
go
-- Insertar Categorías
INSERT INTO Categorias (Descripcion) VALUES ('Procesador');
INSERT INTO Categorias (Descripcion) VALUES ('Tarjeta Grafica');
go
-- Insertar Artículos
INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('ABC123', 'SUPER GEFORCE RTX 2060', 'Este componente electrónico procesa la información que llega al dispositivo y los transforma en imágenes o videos para mostrarla visualmente. Es ideal para trabajar con aplicaciones gráficas ya que permite obtener imágenes más nítidas.
', 1, 2, 19.99);

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('XYZ456', 'AMD Ryzen 7 5700G', 'Procesador AMD Ryzen 7 5700G 100-100000263BOX de 8 núcleos y 4.6GHz de frecuencia con gráfica integrada', 2, 1, 29.99);

go
-- Insertar Imágenes
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (2, 'https://http2.mlstatic.com/D_NQ_NP_989909-MLA54404266985_032023-O.webp');

INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (1, 'https://http2.mlstatic.com/D_NQ_NP_714995-MLA54486481781_032023-O.webp');
