# Módulo Responsable

## Descripción
Gestión de responsables asociados a clientes y procesos de compliance.

## Endpoints

### 1. GET /api/Responsables
**Obtener lista de responsables**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Carlos",
    "apellido": "Rodríguez",
    "cargo": "Gerente de Compliance",
    "clienteId": 1
  }
]
```

### 2. GET /api/Responsables/{id}
**Obtener responsable específico**

**Parámetros de ruta:**
- `id` (long): ID del responsable

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Carlos",
  "apellido": "Rodríguez",
  "cargo": "Gerente de Compliance",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Responsable no encontrado"
}
```

### 3. POST /api/Responsables
**Crear nuevo responsable**

**Request Body:**
```json
{
  "nombre": "Ana",
  "apellido": "Martínez",
  "cargo": "Analista de Riesgos",
  "clienteId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Responsable creado exitosamente"
}
```

### 4. PUT /api/Responsables/{id}
**Actualizar responsable**

**Parámetros de ruta:**
- `id` (long): ID del responsable

**Request Body:**
```json
{
  "nombre": "Carlos",
  "apellido": "Rodríguez",
  "cargo": "Director de Compliance",
  "clienteId": 1
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

### 5. DELETE /api/Responsables/{id}
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
  "nombre": "string",
  "apellido": "string",
  "cargo": "string",
  "clienteId": "long"
}
```

### CreateResponsableDto
```json
{
  "nombre": "string",
  "apellido": "string",
  "cargo": "string",
  "clienteId": "long"
}
```