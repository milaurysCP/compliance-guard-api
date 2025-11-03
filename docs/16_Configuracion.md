# Módulo Init

## Descripción
Controlador de inicialización y configuración del sistema de compliance.

## Endpoints

### 1. GET /api/Init/status
**Obtener estado de la base de datos**

**Response (200 OK):**
```json
{
  "message": "Estado completo de la base de datos",
  "data": {
    "roles": 3,
    "usuarios": 1,
    "politicas": 0,
    "capacitaciones": 0,
    "clientes": 5,
    "actividadesEconomicas": 3,
    "direcciones": 5,
    "contactos": 7,
    "beneficiarios": 2,
    "perfilesFinancieros": 3,
    "riesgos": 4,
    "operaciones": 2,
    "transacciones": 3,
    "evaluaciones": 6
  },
  "hasData": true,
  "totalRecords": 45,
  "instructions": {
    "seedData": "Para cargar datos completos, ejecuta el archivo 'seed_data.sql' en SQL Server Management Studio",
    "cleanData": "Para limpiar la base de datos, ejecuta el archivo 'clean_database.sql'",
    "sqlFiles": ["seed_data.sql", "clean_database.sql"]
  }
}
```

### 2. POST /api/Init/create-admin
**Crear usuario administrador**

**Response (200 OK):**
```json
{
  "message": "Usuario administrador creado exitosamente",
  "username": "admin",
  "password": "12345678",
  "note": "Cambia la contraseña después del primer login"
}
```

**Response (400 Bad Request):**
```json
{
  "message": "El usuario admin ya existe"
}
```

### 3. GET /api/Init/connection-test
**Probar conexión a la base de datos**

**Response (200 OK):**
```json
{
  "message": "Conexión a base de datos exitosa",
  "database": {
    "connectionSuccess": true,
    "databaseName": "ComplianceGuardPro",
    "serverVersion": "15.00.2000",
    "connectionString": "Server=localhost;Database=ComplianceGuardPro;..."
  }
}
```

**Response (500 Internal Server Error):**
```json
{
  "message": "Error de conexión a la base de datos",
  "error": "Connection timeout"
}
```

## DTOs

Este módulo no utiliza DTOs específicos, ya que maneja operaciones de inicialización del sistema.