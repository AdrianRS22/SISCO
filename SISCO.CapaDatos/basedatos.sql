CREATE TABLE [Proveedor] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [Nombre] varchar(100),
  [Direccion] text,
  [Correo] varchar(100),
  [Telefono] varchar(10),
  [Activo] bit DEFAULT 1,
  [FechaCreacion] datetime DEFAULT GETDATE()
)
GO

CREATE TABLE [Producto] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [ProveedorId] UNIQUEIDENTIFIER,
  [Nombre] varchar(100),
  [Precio] decimal(11,2),
  [Activo] bit DEFAULT 1,
  [FechaCreacion] datetime DEFAULT GETDATE()
)
GO

CREATE TABLE [Orden] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [NumeroOrden] varchar(20),
  [Provincia] varchar(50),
  [Canton] varchar(50),
  [Direccion] text,
  [Costo] decimal(11,2),
  [Estado] varchar(50),
  [FechaCreacion] datetime DEFAULT GETDATE()
)
GO

CREATE TABLE [OrdenXProducto] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [OrdenId] UNIQUEIDENTIFIER,
  [ProductoId] UNIQUEIDENTIFIER,
  [Cantidad] int
)
GO

ALTER TABLE [Producto] ADD FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedor] ([Id])
GO

ALTER TABLE [OrdenXProducto] ADD FOREIGN KEY ([OrdenId]) REFERENCES [Orden] ([Id])
GO

ALTER TABLE [OrdenXProducto] ADD FOREIGN KEY ([ProductoId]) REFERENCES [Producto] ([Id])
GO
