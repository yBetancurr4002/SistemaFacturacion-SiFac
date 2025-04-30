USE SiFac;
GO

-- 1. Personas
INSERT INTO Personas (Nombre, Direccion, Telefono, Email, FechaCreacion)
VALUES 
('Juan Pérez', 'Calle Falsa 123', '555-1234', 'juan@example.com', GETDATE()),
('Ana López', 'Av. Central 456', '555-5678', 'ana@example.com', GETDATE()),
('Carlos Gómez', 'Diagonal 789', '555-9012', 'carlos@example.com', GETDATE());

-- 2. Clientes (asociados a personas con Id 1 y 2)
INSERT INTO Clientes (PersonaId, CodigoCliente, Nit)
VALUES 
(1, 'CL001', '1234567-8'),
(2, 'CL002', '7654321-9');


-- 3. Usuarios (asociados a persona con Id 3)
INSERT INTO Usuarios (PersonaId, NombreUsuario, Contrasena, Rol, Estado, FechaCreacion)
VALUES 
(3, 'cgomez', 'password123', 'Administrador', 1, GETDATE());

-- 4. Productos
INSERT INTO Productos (Nombre, Precio, Stock, Descripcion, FechaCreacion)
VALUES 
('Laptop', 1200.00, 10, 'Laptop Dell Core i7', GETDATE()),
('Mouse', 25.50, 50, 'Mouse óptico USB', GETDATE()),
('Teclado', 45.00, 30, 'Teclado mecánico', GETDATE());

-- 5. Facturas (para cliente con Id 1)
INSERT INTO Facturas (Fecha, ClienteId, Total, Estado, FechaCreacion)
VALUES 
(GETDATE(), 1, 1295.50, 'Pendiente', GETDATE());

-- 6. DetalleFactura (para factura Id 1)
INSERT INTO DetallesFactura (FacturaId, ProductoId, Cantidad, PrecioUnitario)
VALUES 
(2, 1, 1, 1200.00),
(2, 2, 1, 25.50),
(2, 3, 1, 70.00);

-- 7. Roles
INSERT INTO Roles (Nombre, Descripcion)
VALUES 
('Administrador', 'Acceso completo al sistema'),
('Vendedor', 'Gestión de ventas y clientes');

-- 8. Permisos
INSERT INTO Permisos (Nombre, Descripcion)
VALUES 
('GestionUsuarios', 'Permite crear y editar usuarios'),
('GestionProductos', 'Permite crear y editar productos'),
('VerReportes', 'Permite ver reportes del sistema');

-- 9. RolesPermisos
INSERT INTO RolesPermisos (RolId, PermisoId)
VALUES 
(1, 1), -- Admin -> GestionUsuarios
(1, 2), -- Admin -> GestionProductos
(1, 3), -- Admin -> VerReportes
(2, 2); -- Vendedor -> GestionProductos
