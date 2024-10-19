CREATE DATABASE Gestion de inventario;
GO

USE Gestion de inventario;
GO

-- Tabla de Categorías
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla de Proveedores
CREATE TABLE Proveedores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20)
);

-- Tabla de Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Codigo NVARCHAR(50) NOT NULL,
    Categoria NVARCHAR(50),
    Precio DECIMAL(18, 2) NOT NULL,
    Existencia INT NOT NULL,
    Proveedor NVARCHAR(100),
    FOREIGN KEY (Categoria) REFERENCES Categorias(Nombre),
    FOREIGN KEY (Proveedor) REFERENCES Proveedores(Nombre)
);

-- Insertar categorías
INSERT INTO Categorias (Nombre) VALUES ('Electrónica');
INSERT INTO Categorias (Nombre) VALUES ('Ropa');
INSERT INTO Categorias (Nombre) VALUES ('Alimentos');

-- Insertar proveedores
INSERT INTO Proveedores (Nombre, Direccion, Telefono) VALUES ('Proveedor A', 'Dirección A', '123456789');
INSERT INTO Proveedores (Nombre, Direccion, Telefono) VALUES ('Proveedor B', 'Dirección B', '987654321');

-- Insertar productos
INSERT INTO Productos (Nombre, Codigo, Categoria, Precio, Existencia, Proveedor) 
VALUES ('Producto 1', 'P001', 'Electrónica', 199.99, 50, 'Proveedor A');
INSERT INTO Productos (Nombre, Codigo, Categoria, Precio, Existencia, Proveedor) 
VALUES ('Producto 2', 'P002', 'Ropa', 49.99, 100, 'Proveedor B');
