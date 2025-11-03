# Módulo Intermediario

## Descripción
Gestión de intermediarios asociados a los clientes para cumplimiento normativo.

## Endpoints

### 1. GET /api/Intermediarios/cliente/{clienteId}
**Obtener intermediarios por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Banco Nacional",
    "clienteId": 1
  },
  {
    "id": 2,
    "nombre": "Casa de Bolsa XYZ",
    "clienteId": 1
  }
]
```

### 2. GET /api/Intermediarios/{id}
**Obtener intermediario específico**

**Parámetros de ruta:**
- `id` (long): ID del intermediario

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Banco Nacional",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Intermediario no encontrado"
}
```

### 3. POST /api/Intermediarios
**Crear nuevo intermediario**

**Request Body:**
```json
{
  "nombre": "Financiera ABC",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Intermediario creado exitosamente"
}
```

### 4. PUT /api/Intermediarios/{id}
**Actualizar intermediario**

**Parámetros de ruta:**
- `id` (long): ID del intermediario

**Request Body:**
```json
{
  "nombre": "Financiera ABC S.A.",
  "clienteId": 1
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

### 5. DELETE /api/Intermediarios/{id}
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
  "clienteId": "long"
}
```

### CreateIntermediarioDto
```json
{
  "nombre": "string",
  "clienteId": "long"
}
```
