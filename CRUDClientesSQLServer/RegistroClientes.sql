CREATE DATABASE CRUDClientesDB;
GO

USE CRUDClientesDB;
GO

CREATE TABLE Clientes
(
    IdCliente INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Clientes PRIMARY KEY,
    Nombre NVARCHAR(60) NOT NULL,
    Apellido NVARCHAR(60) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Correo NVARCHAR(120) NULL,
    FechaRegistro DATETIME2 NOT NULL CONSTRAINT DF_Clientes_FechaRegistro DEFAULT SYSDATETIME(),
    Activo BIT NOT NULL CONSTRAINT DF_Clientes_Activo DEFAULT 1,
    RowVersion ROWVERSION NOT NULL -- Campo para control de concurrencia optimista
);
GO

CREATE INDEX IX_Clientes_Nombre
ON Clientes (Apellido, Nombre);
GO

-- Datos iniciales de prueba
INSERT INTO Clientes (Nombre, Apellido, Telefono, Correo)
VALUES
(N'Juan', N'Pérez', N'8888-1111', N'juan.perez@correo.com'),
(N'María', N'López', N'7777-2222', N'maria.lopez@correo.com'),
(N'Carlos', N'Gómez', N'8666-3333', N'carlos.gomez@correo.com');
GO

SELECT * FROM Clientes;
GO