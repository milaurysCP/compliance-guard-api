-- ================================================
-- SCRIPT DE LIMPIEZA DE DATOS - COMPLIANCE GUARD PRO
-- ================================================
-- Este script elimina todos los datos de prueba de la base de datos
-- CUIDADO: Este script eliminará TODOS los datos del sistema
-- Solo usar en ambiente de desarrollo

USE ComplianceGuard_DB;

-- Desactivar restricciones de clave foránea temporalmente
EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

-- Eliminar datos en orden inverso de dependencias
DELETE FROM Documentos;
DELETE FROM Mitigaciones;
DELETE FROM Evaluaciones;
DELETE FROM Riesgos;
DELETE FROM DebidaDiligencias;
DELETE FROM Pagos;
DELETE FROM Transacciones;
DELETE FROM Operaciones;
DELETE FROM PerfilesFinancieros;
DELETE FROM ActividadesEconomicas;
DELETE FROM Contactos;
DELETE FROM Direcciones;
DELETE FROM BeneficiariosFinales;
DELETE FROM Intermediarios;
DELETE FROM Referencias;
DELETE FROM PersonasExpuestasPoliticamente;
DELETE FROM Responsables;
DELETE FROM Clientes;
DELETE FROM Capacitaciones;
DELETE FROM Politicas;
DELETE FROM MensajesChat;
DELETE FROM Usuarios;
DELETE FROM Roles;

-- Reactivar restricciones de clave foránea
EXEC sp_MSforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"

-- Reiniciar contadores de identidad
DBCC CHECKIDENT ('Roles', RESEED, 0);
DBCC CHECKIDENT ('Usuarios', RESEED, 0);
DBCC CHECKIDENT ('Clientes', RESEED, 0);
DBCC CHECKIDENT ('BeneficiariosFinales', RESEED, 0);
DBCC CHECKIDENT ('Intermediarios', RESEED, 0);
DBCC CHECKIDENT ('Direcciones', RESEED, 0);
DBCC CHECKIDENT ('Contactos', RESEED, 0);
DBCC CHECKIDENT ('ActividadesEconomicas', RESEED, 0);
DBCC CHECKIDENT ('PerfilesFinancieros', RESEED, 0);
DBCC CHECKIDENT ('Operaciones', RESEED, 0);
DBCC CHECKIDENT ('Pagos', RESEED, 0);
DBCC CHECKIDENT ('Transacciones', RESEED, 0);
DBCC CHECKIDENT ('Referencias', RESEED, 0);
DBCC CHECKIDENT ('PersonasExpuestasPoliticamente', RESEED, 0);
DBCC CHECKIDENT ('Responsables', RESEED, 0);
DBCC CHECKIDENT ('DebidaDiligencias', RESEED, 0);
DBCC CHECKIDENT ('Riesgos', RESEED, 0);
DBCC CHECKIDENT ('Mitigaciones', RESEED, 0);
DBCC CHECKIDENT ('Evaluaciones', RESEED, 0);
DBCC CHECKIDENT ('MensajesChat', RESEED, 0);
DBCC CHECKIDENT ('Politicas', RESEED, 0);
DBCC CHECKIDENT ('Capacitaciones', RESEED, 0);
DBCC CHECKIDENT ('Documentos', RESEED, 0);

PRINT 'Base de datos limpiada exitosamente. Todos los datos han sido eliminados.';