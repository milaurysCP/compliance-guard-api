# Módulo Responsable

## Descripción
Gestión de responsables y contactos de clientes corporativos.

## Endpoints

### 1. GET /api/Responsable
**Obtener lista de responsables**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "nombre": "Juan Pérez",
    "apellido": "García",
    "cargo": "Director General",
    "telefono": "+52551234567",
    "email": "juan.perez@empresa.com",
    "tipoResponsable": "Legal",
    "fechaAsignacion": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "nombre": "María",
    "apellido": "López",
    "cargo": "Gerente de Compliance",
    "telefono": "+52559876543",
    "email": "maria.lopez@empresa.com",
    "tipoResponsable": "Compliance",
    "fechaAsignacion": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/Responsable/{id}
**Obtener responsable específico**

**Parámetros de ruta:**
- `id` (long): ID del responsable

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "nombre": "Juan Pérez",
  "apellido": "García",
  "cargo": "Director General",
  "telefono": "+52551234567",
  "email": "juan.perez@empresa.com",
  "tipoResponsable": "Legal",
  "fechaAsignacion": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Responsable no encontrado"
}
```

### 3. GET /api/Responsable/cliente/{clienteId}
**Obtener responsables por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "nombre": "Juan Pérez",
    "apellido": "García",
    "cargo": "Director General",
    "telefono": "+52551234567",
    "email": "juan.perez@empresa.com",
    "tipoResponsable": "Legal",
    "fechaAsignacion": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "nombre": "María",
    "apellido": "López",
    "cargo": "Gerente de Compliance",
    "telefono": "+52559876543",
    "email": "maria.lopez@empresa.com",
    "tipoResponsable": "Compliance",
    "fechaAsignacion": "2024-01-01T00:00:00Z"
  }
]
```

### 4. POST /api/Responsable
**Crear nuevo responsable**

**Request Body:**
```json
{
  "clienteId": 2,
  "nombre": "Carlos",
  "apellido": "Rodríguez",
  "cargo": "Director Financiero",
  "telefono": "+52551111222",
  "email": "carlos.rodriguez@empresa2.com",
  "tipoResponsable": "Financiero",
  "fechaAsignacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Responsable creado exitosamente"
}
```

### 5. PUT /api/Responsable/{id}
**Actualizar responsable**

**Parámetros de ruta:**
- `id` (long): ID del responsable

**Request Body:**
```json
{
  "clienteId": 2,
  "nombre": "Carlos",
  "apellido": "Rodríguez Sánchez",
  "cargo": "Director Financiero Senior",
  "telefono": "+52551111222",
  "email": "carlos.rodriguez@empresa2.com",
  "tipoResponsable": "Financiero",
  "fechaAsignacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Responsable actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Responsable no encontrado"
}
```

### 6. DELETE /api/Responsable/{id}
**Eliminar responsable**

**Parámetros de ruta:**
- `id` (long): ID del responsable

**Response (200 OK):**
```json
{
  "message": "Responsable eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Responsable no encontrado"
}
```

## DTOs

### ResponsableDto
```json
{
  "id": "long",
  "clienteId": "long",
  "nombre": "string",
  "apellido": "string",
  "cargo": "string",
  "telefono": "string",
  "email": "string",
  "tipoResponsable": "string",
  "fechaAsignacion": "datetime"
}
```

### CreateResponsableDto
```json
{
  "clienteId": "long",
  "nombre": "string",
  "apellido": "string",
  "cargo": "string",
  "telefono": "string",
  "email": "string",
  "tipoResponsable": "string",
  "fechaAsignacion": "datetime"
}
```