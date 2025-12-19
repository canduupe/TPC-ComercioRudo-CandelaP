create database Comercio_Rudo
go
use Comercio_Rudo

---TABLAS

Create table TipoUsuario(
    IdTipoUsuario int primary key identity(1,1),
    Descripcion varchar(30) not null
)

INSERT INTO TipoUsuario (Descripcion) VALUES
('Administrador'),
('Vendedor');


Create table Usuarios(
Id int primary key identity (1,1),
Usuario varchar(20) not null,
Contraseña varchar(20) not null,
IdTipoUsuario int not null,
Activo int not null default 1

foreign key (IdTipoUsuario) references TipoUsuario(IdTipoUsuario)
)

Create table Vendedor(
    IdVendedor int primary key identity (1,1),
    Nombre varchar(50) not null, 
    Apellido varchar(50) not null,
    IdUsuario int not null,
    Activo int not null default 1,

    foreign key (IdUsuario) references Usuarios(Id)
)

Create table Administrador(
    IdAdministrador int primary key identity(1,1),
    Nombre varchar(50) not null, 
    Apellido varchar(50) not null,
    IdUsuario int not null,
    Activo int not null default 1,

    foreign key (IdUsuario) references Usuarios(Id)
)


Create table Marca(
IdMarca int primary key identity (1,1),
Nombre varchar(50) not null,
)

Create table Categoria(
IdCategoria int primary key identity (1,1),
Nombre varchar(50) not null,
)

Create table Proveedor(
IdProveedor int primary key identity (1,1),
Nombre varchar(50) not null,
Marca int not null references Marca(IdMarca),
Categoria int not null references Categoria(IdCategoria)
)

ALTER TABLE Proveedor
ADD Activo int NOT NULL DEFAULT 1;

Create table Producto(
IdProducto int primary key identity(1,1),
Nombre varchar(50) not null,
Descripcion varchar(50) not null,
Precio Money not null,
Proveedor int null references Proveedor(IdProveedor),
Marca int not null references Marca(IdMarca),
Categoria int not null references Categoria(IdCategoria),
StockActual int not null,
StockMinimo int not null,
Activo int not null default 1,
)

Create table Cliente(
    IdCliente int primary key identity(1,1),
    Nombre varchar(50) not null,
    Apellido varchar(50) not null,
    DNI varchar(15) not null,
    Telefono varchar(20),
    Email varchar(50),
    Direccion varchar(100),
    Activo int not null default 1
)

Create table Compra(
IdCompra int primary key identity (1,1),
IdProveedor int null references Proveedor(IdProveedor),
IdProducto int null references Producto(IdProducto),
IdVendedor int null references Vendedor(IdVendedor),
Precio Money not null,
Cantidad int not null,
Ganancia decimal not null
)

Create table Venta(
    IdVenta int primary key identity (1,1),
    NroFactura varchar(13) not null unique,
    IdCliente int not null,
    IdVendedor int not null,
    Fecha datetime not null default getdate(),
    Total money not null,

    foreign key (IdCliente) references Cliente(IdCliente),
    foreign key (IdVendedor) references Vendedor(IdVendedor)
)


Create table DetalleVenta(
    IdDetalleVenta int primary key identity(1,1),
    IdVenta int not null,
    IdProducto int not null,
    Cantidad int not null,
    PrecioUnitario money not null,
    Subtotal money not null,

    foreign key (IdVenta) references Venta(IdVenta),
    foreign key (IdProducto) references Producto(IdProducto)
)

---INSERTS

INSERT INTO Usuarios (Usuario, Contraseña, IdTipoUsuario, Activo) VALUES
('admin', '1234', 1, 1),
('ven', '1234', 2, 1),
('ven2', '1234', 2, 1),
('ven3', '1234', 2, 1);

INSERT INTO Administrador (Nombre, Apellido, IdUsuario, Activo) VALUES
('Can', 'Pena', 1, 1);

INSERT INTO Vendedor (Nombre, Apellido, IdUsuario, Activo) VALUES
('Juan', 'Lopez', 2, 1),
('María', 'Fernandez', 3, 1),
('Pedro', 'Martinez', 4, 1);

INSERT INTO Marca (Nombre) VALUES
('Arcor'),
('Kinder'),
('Mogul'),
('Billiken'),
('Lays');

INSERT INTO Categoria (Nombre) VALUES
('Golosinas'),
('Snacks'),
('Galletitas'),
('Bebidas');

INSERT INTO Proveedor (Nombre, Marca, Categoria, Activo) VALUES
('Distribuidora Norte', 1, 1, 1),
('Importadora Ale', 2, 2, 1),
('Mayorista 2 hermanos', 3, 3, 1),
('Proveedor Lali', 4, 4, 1);

INSERT INTO Producto
(Nombre, Descripcion, Precio, Proveedor, Marca, Categoria, StockActual, StockMinimo, Activo)
VALUES
('Alfajor', 'Chocolate', 3500, 1, 1, 1, 10, 2, 1),
('Gomitas', 'Dinosaurios', 2000, 3, 1, 3, 8, 2, 1),
('Papas', 'Jamon serrano', 4200, 4, 2, 4, 15, 5, 1);

INSERT INTO Cliente
(Nombre, Apellido, DNI, Telefono, Email, Direccion, Activo)
VALUES
('Ana', 'Ruiz', '30123456', '1111111111', 'ana@mail.com', 'Av. Avellaneda 123', 1),
('Luis', 'Martín', '28987654', '2222222222', 'luis@mail.com', 'Calle Tucuman 456', 1),
('Sofía', 'Torres', '33444555', '3333333333', 'sofia@mail.com', 'Belgrano 789', 1),
('Diego', 'Molina', '31222333', '4444444444', 'diego@mail.com', 'San Martín 321', 1),
('Carla', 'Suarez', '29888777', '5555555555', 'carla@mail.com', 'Mitre 654', 1);

select * from Cliente


