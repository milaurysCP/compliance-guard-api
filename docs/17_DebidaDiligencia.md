# Módulo DebidaDiligencia

## Descripción
Gestión de procesos de debida diligencia para clientes, incluyendo riesgos y documentos asociados.

## Endpoints

### 1. GET /api/DebidaDiligencia
**Obtener lista de debidas diligencias**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Debida Diligencia Cliente ABC",
    "descripcion": "Evaluación completa de riesgos",
    "fechaInicio": "2024-01-01T00:00:00Z",
    "fechaFin": null,
    "estado": "En Progreso",
    "observaciones": "Pendiente revisión de documentos",
    "clienteId": 1
  }
]
```

### 2. GET /api/DebidaDiligencia/{id}
**Obtener debida diligencia específica**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Response (200 OK):**
```json
{
  "id": 1,
  "titulo": "Debida Diligencia Cliente ABC",
  "descripcion": "Evaluación completa de riesgos",
  "fechaInicio": "2024-01-01T00:00:00Z",
  "fechaFin": null,
  "estado": "En Progreso",
  "observaciones": "Pendiente revisión de documentos",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

### 3. POST /api/DebidaDiligencia
**Crear nueva debida diligencia**

**Request Body:**
```json
{
  "titulo": "Debida Diligencia Nuevo Cliente",
  "descripcion": "Evaluación inicial de riesgos",
  "fechaInicio": "2024-01-15T10:00:00Z",
  "estado": "En Progreso",
  "observaciones": "Cliente nuevo requiere evaluación completa",
  "clienteId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Debida diligencia creada exitosamente"
}
```

### 4. PUT /api/DebidaDiligencia/{id}
**Actualizar debida diligencia**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Request Body:**
```json
{
  "titulo": "Debida Diligencia Cliente ABC - Actualizada",
  "descripcion": "Evaluación completa de riesgos - Versión actualizada",
  "fechaInicio": "2024-01-01T00:00:00Z",
  "fechaFin": "2024-01-15T15:00:00Z",
  "estado": "Completada",
  "observaciones": "Evaluación finalizada exitosamente",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Debida diligencia actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

### 5. DELETE /api/DebidaDiligencia/{id}
**Eliminar debida diligencia**

**Parámetros de ruta:**
- `id` (long): ID de la debida diligencia

**Response (200 OK):**
```json
{
  "message": "Debida diligencia eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Debida diligencia no encontrada"
}
```

## DTOs

### DebidaDiligenciaDto
```json
{
  "id": "long",
  "titulo": "string",
  "descripcion": "string",
  "fechaInicio": "datetime",
  "fechaFin": "datetime?",
  "estado": "string",
  "observaciones": "string",
  "clienteId": "long"
}
```

### CreateDebidaDiligenciaDto
```json
{
  "titulo": "string",
  "descripcion": "string",
  "fechaInicio": "datetime",
  "fechaFin": "datetime?",
  "estado": "string",
  "observaciones": "string",
  "clienteId": "long"
}
```