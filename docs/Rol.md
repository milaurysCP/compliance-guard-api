# Módulo Rol

## Descripción
Gestión de roles y permisos del sistema de compliance.

## Endpoints

### 1. GET /api/Rol
**Obtener lista de roles**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Administrador",
    "descripcion": "Acceso completo al sistema",
    "permisos": ["CREATE", "READ", "UPDATE", "DELETE", "ADMIN"],
    "fechaCreacion": "2024-01-01T00:00:00Z",
    "activo": true
  },
  {
    "id": 2,
    "nombre": "Analista Compliance",
    "descripcion": "Acceso a análisis y reportes de compliance",
    "permisos": ["READ", "UPDATE", "REPORT"],
    "fechaCreacion": "2024-01-01T00:00:00Z",
    "activo": true
  },
  {
    "id": 3,
    "nombre": "Auditor",
    "descripcion": "Acceso de solo lectura para auditorías",
    "permisos": ["READ"],
    "fechaCreacion": "2024-01-01T00:00:00Z",
    "activo": true
  }
]
```

### 2. GET /api/Rol/{id}
**Obtener rol específico**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Administrador",
  "descripcion": "Acceso completo al sistema",
  "permisos": ["CREATE", "READ", "UPDATE", "DELETE", "ADMIN"],
  "fechaCreacion": "2024-01-01T00:00:00Z",
  "activo": true
}
```

**Response (404 Not Found):**
```json
{
  "message": "Rol no encontrado"
}
```

### 3. POST /api/Rol
**Crear nuevo rol**

**Request Body:**
```json
{
  "nombre": "Supervisor",
  "descripcion": "Supervisión de operaciones de compliance",
  "permisos": ["READ", "UPDATE", "APPROVE"],
  "fechaCreacion": "2024-01-15T10:00:00Z",
  "activo": true
}
```

**Response (200 OK):**
```json
{
  "message": "Rol creado exitosamente"
}
```

### 4. PUT /api/Rol/{id}
**Actualizar rol**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Request Body:**
```json
{
  "nombre": "Supervisor Senior",
  "descripcion": "Supervisión avanzada de operaciones de compliance",
  "permisos": ["READ", "UPDATE", "APPROVE", "REPORT"],
  "fechaCreacion": "2024-01-15T10:00:00Z",
  "activo": true
}
```

**Response (200 OK):**
```json
{
  "message": "Rol actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Rol no encontrado"
}
```

### 5. DELETE /api/Rol/{id}
**Eliminar rol**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Response (200 OK):**
```json
{
  "message": "Rol eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Rol no encontrado"
}
```

## DTOs

### RolDto
```json
{
  "id": "long",
  "nombre": "string",
  "descripcion": "string",
  "permisos": "string[]",
  "fechaCreacion": "datetime",
  "activo": "bool"
}
```

### CreateRolDto
```json
{
  "nombre": "string",
  "descripcion": "string",
  "permisos": "string[]",
  "fechaCreacion": "datetime",
  "activo": "bool"
}
```