# Módulo Rol

## Descripción
Gestión de roles del sistema de compliance.

## Endpoints

### 1. GET /api/Roles
**Obtener lista de roles**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Administrador",
    "descripcion": "Acceso completo al sistema"
  },
  {
    "id": 2,
    "nombre": "Analista Compliance",
    "descripcion": "Acceso a análisis y reportes de compliance"
  }
]
```

### 2. GET /api/Roles/{id}
**Obtener rol específico**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Administrador",
  "descripcion": "Acceso completo al sistema"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Rol no encontrado"
}
```

### 3. POST /api/Roles
**Crear nuevo rol**

**Request Body:**
```json
{
  "nombre": "Supervisor",
  "descripcion": "Supervisión de operaciones de compliance"
}
```

**Response (201 Created):**
```json
{
  "id": 3,
  "nombre": "Supervisor",
  "descripcion": "Supervisión de operaciones de compliance"
}
```

### 4. PUT /api/Roles/{id}
**Actualizar rol**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Request Body:**
```json
{
  "nombre": "Supervisor Senior",
  "descripcion": "Supervisión avanzada de operaciones de compliance"
}
```

**Response (200 OK):**
```json
{
  "id": 3,
  "nombre": "Supervisor Senior",
  "descripcion": "Supervisión avanzada de operaciones de compliance"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Rol no encontrado"
}
```

### 5. DELETE /api/Roles/{id}
**Eliminar rol**

**Parámetros de ruta:**
- `id` (long): ID del rol

**Response (204 No Content):**

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
  "descripcion": "string"
}
```

### CreateRolDto
```json
{
  "nombre": "string",
  "descripcion": "string"
}
```