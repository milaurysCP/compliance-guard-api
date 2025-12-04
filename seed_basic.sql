INSERT INTO Roles (Nombre, Descripcion) VALUES
('OFICIAL_CUMPLIMIENTO', 'Acceso total. Puede eliminar.'),
('ANALISTA', 'Puede leer, crear y actualizar.'),
('TECNICO', 'Puede leer, crear y actualizar.'),
('OFICIAL_SUPLENTE', 'Puede leer, crear y actualizar.');



-- clave 12345678
INSERT INTO Usuarios (UsuarioLogin, ClaveHash, EstaActivo, Nombre, RolId, Token) VALUES
('mlaurys.contreras', 'AQAAAAIAAYagAAAAEO7dBBCoQBj014C4F4ki3SF44/UqXvlsBuJpc/QwnikjKYmT6yF05vg04RwET+U/6A==', 1, 'Milaurys Contreras', 1, NULL);


PRINT 'Seed data inserted successfully!';
