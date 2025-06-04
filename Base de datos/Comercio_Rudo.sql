create database Comercio_Rudo
go
use Comercio_Rudo

---TABLAS
Create table Usuarios(
Id int primary key identity (1,1),
Usuario varchar(20) not null,
Contraseña varchar(20) not null,
TipoUsuario int not null,
Activo int not null default 1
)

Create table Vendedor(
IdVendedor int primary key identity (1,1),
Nombre varchar(50) not null, 
Apellido varchar(50) not null,
IdUsuario int foreign key references Usuarios(Id),
Activo int not null
)

Create table Administrador(
IdAdministrador int Primary key identity(1,1),
Nombre varchar(50) not null, 
Apellido varchar(50) not null,
IdUsuario int foreign key references Usuarios(Id),
Activo int not null
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

Create table Compra(
IdCompra int primary key identity (1,1),
IdProveedor int null references Proveedor(IdProveedor),
IdProducto int null references Producto(IdProducto),
Precio Money not null,
Cantidad int not null,
StockActual int not null
)

Create table Venta(
IdVenta int primary key identity (1,1),
Factura int identity (1,1),
Precio Money not null,
Fecha datetime not null
)

---INSERTS

---marcas
insert into Marca(Nombre)
values ('Mogul')

---categorias
insert into Categoria(Nombre)
values ('Golosina')

---proveedores
insert into Proveedor(Nombre, Marca, Categoria)
values ('Los dos hermanos', 1, 1)

---productos
insert into Producto(Nombre, Descripcion, Precio, Proveedor, Marca, Categoria, StockActual, StockMinimo) 
values ('Gomitas', '100g', 1000, 1, 1, 1, 30, 20)

select * from Marca

select IdProducto, Nombre, Descripcion, Precio, Proveedor, Marca, Categoria, StockActual, StockMinimo, Activo from Producto