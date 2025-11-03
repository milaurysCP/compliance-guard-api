# Módulo Referencia

## Descripción
Gestión de referencias y recomendaciones para clientes.

## Endpoints

### 1. GET /api/Referencias
**Obtener lista de referencias**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "recomendacion": "Cliente confiable",
    "descripcion": "Ha mantenido operaciones limpias durante 5 años",
    "clienteId": 1
  }
]
```

### 2. GET /api/Referencias/{id}
**Obtener referencia específica**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Response (200 OK):**
```json
{
  "id": 1,
  "recomendacion": "Cliente confiable",
  "descripcion": "Ha mantenido operaciones limpias durante 5 años",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

### 3. POST /api/Referencias
**Crear nueva referencia**

**Request Body:**
```json
{
  "recomendacion": "Cliente recomendado",
  "descripcion": "Nuevo cliente con buenas referencias bancarias",
  "clienteId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Referencia creada exitosamente"
}
```

### 4. PUT /api/Referencias/{id}
**Actualizar referencia**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Request Body:**
```json
{
  "recomendacion": "Cliente muy confiable",
  "descripcion": "Ha mantenido operaciones limpias durante 7 años",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Referencia actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

### 5. DELETE /api/Referencias/{id}
**Eliminar referencia**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Response (200 OK):**
```json
{
  "message": "Referencia eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

## DTOs

### ReferenciaDto
```json
{
  "id": "long",
  "recomendacion": "string",
  "descripcion": "string",
  "clienteId": "long"
}
```

### CreateReferenciaDto
```json
{
  "recomendacion": "string",
  "descripcion": "string",
  "clienteId": "long"
}
```