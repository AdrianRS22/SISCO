CREATE TABLE [Proveedor] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [Nombre] varchar(100) NOT NUll,
  [Direccion] text NOT NULL,
  [Correo] varchar(100) NOT NULL,
  [Telefono] varchar(10) NOT NULL,
  [Activo] bit DEFAULT 1 NOT NULL,
  [FechaCreacion] datetime DEFAULT GETDATE() NOT NULL
)
GO

CREATE TABLE [Producto] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [ProveedorId] UNIQUEIDENTIFIER NOT NULL,
  [Nombre] varchar(100) NOT NULL,
  [Descripcion] text NULL,
  [Precio] decimal(11,2) NOT NULL,
  [Activo] bit DEFAULT 1 NOT NULL,
  [FechaCreacion] datetime DEFAULT GETDATE() NOT NULL
)
GO

CREATE TABLE [Orden] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [NumeroOrden] varchar(20) NOT NULL,
  [Provincia] varchar(50) NOT NULL,
  [Canton] varchar(50) NOT NULL,
  [Direccion] text NOT NULL,
  [Costo] decimal(11,2) NOT NULL,
  [Estado] varchar(50) NOT NULL,
  [FechaCreacion] datetime DEFAULT GETDATE() NOT NULL
)
GO

CREATE TABLE [OrdenXProducto] (
  [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  [OrdenId] UNIQUEIDENTIFIER NOT NULL,
  [ProductoId] UNIQUEIDENTIFIER NOT NULL,
  [Cantidad] int NOT NULL
)
GO

ALTER TABLE [Producto] ADD FOREIGN KEY ([ProveedorId]) REFERENCES [Proveedor] ([Id])
GO

ALTER TABLE [OrdenXProducto] ADD FOREIGN KEY ([OrdenId]) REFERENCES [Orden] ([Id])
GO

ALTER TABLE [OrdenXProducto] ADD FOREIGN KEY ([ProductoId]) REFERENCES [Producto] ([Id])
GO


/* Después de haber agregado Identity */
ALTER TABLE Orden 
ADD UsuarioId nvarchar(128)
FOREIGN KEY ([UsuarioId]) REFERENCES [AspNetUsers] ([Id])
GO