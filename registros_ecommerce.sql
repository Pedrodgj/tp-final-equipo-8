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
VALUES (1, 'Admin', '123456789', 'admin@admin.com', '1990-01-01', 'Admin', 'admin', '123456789', 1, 1);

INSERT INTO Usuario (Activo, Apellidos, DNI, Email, FechaNacimiento, Nombres, Password, Telefono, IdTipoUsuario, IdDomicilio)
VALUES (1, 'Comun', '987654321', 'user@user.com', '1995-02-15', 'User', 'user', '987654321', 2, 2);

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
', 1, 2, 19990);

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('XYZ456', 'AMD Ryzen 7 5700G', 'Procesador AMD Ryzen 7 5700G 100-100000263BOX de 8 núcleos y 4.6GHz de frecuencia con gráfica integrada', 2, 1, 29990);
go
-- Insertar Imágenes
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (2, 'https://http2.mlstatic.com/D_NQ_NP_989909-MLA54404266985_032023-O.webp');

INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (1, 'https://http2.mlstatic.com/D_NQ_NP_714995-MLA54486481781_032023-O.webp');

-- Insertar Pedidos
INSERT INTO Compras (IdUsuario, FechaCompra, CodigoSeguimiento, Estado, Envio, Total) VALUES (2, '2023-11-01', 'J-8675309', 'ENVIADO', 1, 89970);
INSERT INTO Compras (IdUsuario, FechaCompra, CodigoSeguimiento, Estado, Envio, Total) VALUES (2, '2023-11-20', 'M-2373304', 'LISTO_PARA_RETIRAR',0, 49890);

-- Insertar Detalle de compras
INSERT INTO DetalleCompra (IdCompra, IdArticulo, Cantidad, PrecioUnitario, Total) VALUES (2, 1, 1, 19.99, 19990);
INSERT INTO DetalleCompra (IdCompra, IdArticulo, Cantidad, PrecioUnitario, Total) VALUES (2, 2, 1, 29.99, 29990);
INSERT INTO DetalleCompra (IdCompra, IdArticulo, Cantidad, PrecioUnitario, Total) VALUES (1, 2, 3, 29.99, 89970);


INSERT INTO Marcas (Descripcion) VALUES ('Lg');

INSERT INTO Categorias (Descripcion) VALUES ('Monitor');
go

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('ATYS54', 'Monitor gamer LG 27UL500 led 27" blanco 100V/240V', 'Este monitor de 27" te va a resultar cómodo para estudiar, trabajar o ver una película en tus tiempos de ocio. Asimismo, su resolución de 3840 x 2160 te permite disfrutar de momentos únicos gracias a una imagen de alta fidelidad.', 3, 3, 419999);

go
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (3, 'https://http2.mlstatic.com/D_NQ_NP_2X_676111-MLA41418872467_042020-F.webp')

go

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('ATWEDS4', 'Combo Actualizacion Ddr4 Ryzen 5 5600g + Motherboard A320m', 'COMBO ACTUALIZACION RYZEN 5 5600G + MOTHERBOARD A320M (ASUS/GIGABYTE/BIOSTAR/MSI - SUJETO A STOCK)', 1, 2, 452432);

go
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (4, 'https://http2.mlstatic.com/D_NQ_NP_2X_645898-MLA71822234076_092023-F.webp');

go

INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)
VALUES ('ATASDDS4', 'AMD PowerColor Fighter Radeon 6600 Series RX 6600 XT AXRX 6600XT 8GBD6-3DH - 8 GB', 'La interfaz PCI-Express 4.0 asegura una conexión rápida y estable con la placa madre, y su bus de memoria de 128 bits proporciona un rendimiento óptimo en la transferencia de datos.', 2, 1, 746349);

go
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (5, 'https://http2.mlstatic.com/D_NQ_NP_2X_665650-MLA52006219829_102022-F.webp');
INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES (5, 'https://http2.mlstatic.com/D_NQ_NP_2X_778653-MLA52006189964_102022-F.webp');