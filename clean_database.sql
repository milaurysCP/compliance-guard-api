-- ================================================
-- SCRIPT DE LIMPIEZA DE DATOS - COMPLIANCE GUARD PRO (Azure SQL)
-- ================================================
-- Este script elimina todos los datos de prueba de la base de datos.
-- ⚠️ CUIDADO: Este script eliminará TODOS los datos del sistema.
-- Solo usar en ambiente de desarrollo / pruebas.


-- 1. Deshabilitar todas las restricciones de clave foránea
PRINT 'Deshabilitando restricciones de clave foránea...';
DECLARE @sql NVARCHAR(MAX) = N'';
SELECT @sql += 'ALTER TABLE [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '] NOCHECK CONSTRAINT ALL;
'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
EXEC sp_executesql @sql;


-- 2. Eliminar datos (en cualquier orden)
PRINT 'Eliminando datos de todas las tablas...';
SET @sql = N'';
SELECT @sql += 'DELETE FROM [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '];
'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
EXEC sp_executesql @sql;


-- 3. Reiniciar contadores de identidad
PRINT 'Reiniciando identidades...';
SET @sql = N'';
SELECT @sql += '
IF EXISTS (SELECT * FROM sys.identity_columns WHERE object_id = OBJECT_ID(''' + TABLE_SCHEMA + '.' + TABLE_NAME + '''))
    DBCC CHECKIDENT (''' + TABLE_SCHEMA + '.' + TABLE_NAME + ''', RESEED, 0);
'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
EXEC sp_executesql @sql;


-- 4. Reactivar restricciones
PRINT 'Reactivando restricciones de clave foránea...';
SET @sql = N'';
SELECT @sql += 'ALTER TABLE [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '] WITH CHECK CHECK CONSTRAINT ALL;
'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
EXEC sp_executesql @sql;

PRINT '✅ Base de datos limpiada exitosamente. Todos los datos han sido eliminados.';
