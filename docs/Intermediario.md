# Módulo Intermediario

## Descripción
Gestión de intermediarios financieros y entidades relacionadas con las operaciones.

## Endpoints

### 1. GET /api/Intermediario
**Obtener lista de intermediarios**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Banco Nacional",
    "tipo": "Banco",
    "pais": "México",
    "numeroRegistro": "BN001",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "nombre": "Casa de Bolsa XYZ",
    "tipo": "Casa de Bolsa",
    "pais": "México",
    "numeroRegistro": "CB002",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/Intermediario/{id}
**Obtener intermediario específico**

**Parámetros de ruta:**
- `id` (long): ID del intermediario

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Banco Nacional",
  "tipo": "Banco",
  "pais": "México",
  "numeroRegistro": "BN001",
  "fechaRegistro": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Intermediario no encontrado"
}
```

### 3. POST /api/Intermediario
**Crear nuevo intermediario**

**Request Body:**
```json
{
  "nombre": "Financiera ABC",
  "tipo": "Institución Financiera",
  "pais": "México",
  "numeroRegistro": "FI003",
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Intermediario creado exitosamente"
}
```

### 4. PUT /api/Intermediario/{id}
**Actualizar intermediario**

**Parámetros de ruta:**
- `id` (long): ID del intermediario

**Request Body:**
```json
{
  "nombre": "Financiera ABC S.A.",
  "tipo": "Institución Financiera",
  "pais": "México",
  "numeroRegistro": "FI003",
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Intermediario actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Intermediario no encontrado"
}
```

### 5. DELETE /api/Intermediario/{id}
**Eliminar intermediario**

**Parámetros de ruta:**
- `id` (long): ID del intermediario

**Response (200 OK):**
```json
{
  "message": "Intermediario eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Intermediario no encontrado"
}
```

## DTOs

### IntermediarioDto
```json
{
  "id": "long",
  "nombre": "string",
  "tipo": "string",
  "pais": "string",
  "numeroRegistro": "string",
  "fechaRegistro": "datetime"
}
```

### CreateIntermediarioDto
```json
{
  "nombre": "string",
  "tipo": "string",
  "pais": "string",
  "numeroRegistro": "string",
  "fechaRegistro": "datetime"
}
```