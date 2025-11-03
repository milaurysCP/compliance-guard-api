# Módulo Evaluacion

## Descripción
Gestión de evaluaciones de riesgo realizadas a los clientes.

## Endpoints

### 1. GET /api/Evaluaciones/cliente/{clienteId}
**Obtener evaluaciones por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "riesgoId": 1,
    "clienteId": 1,
    "puntaje": 75,
    "fechaEvaluacion": "2024-01-15T10:30:00Z",
    "usuarioEvaluador": "Juan Pérez",
    "observaciones": "Evaluación inicial",
    "riesgoNombre": "Lavado de Activos",
    "clienteNombre": "Empresa ABC"
  }
]
```

### 2. GET /api/Evaluaciones/{id}
**Obtener evaluación específica**

**Parámetros de ruta:**
- `id` (long): ID de la evaluación

**Response (200 OK):**
```json
{
  "id": 1,
  "riesgoId": 1,
  "clienteId": 1,
  "puntaje": 75,
  "fechaEvaluacion": "2024-01-15T10:30:00Z",
  "usuarioEvaluador": "Juan Pérez",
  "observaciones": "Evaluación inicial",
  "riesgoNombre": "Lavado de Activos",
  "clienteNombre": "Empresa ABC"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Evaluación no encontrada"
}
```

### 3. POST /api/Evaluaciones
**Crear nueva evaluación**

**Request Body:**
```json
{
  "riesgoId": 1,
  "clienteId": 1,
  "puntaje": 85,
  "fechaEvaluacion": "2024-01-20T14:00:00Z",
  "usuarioEvaluador": "María González",
  "observaciones": "Evaluación de seguimiento"
}
```

**Response (200 OK):**
```json
{
  "message": "Evaluación creada exitosamente"
}
```

### 4. PUT /api/Evaluaciones/{id}
**Actualizar evaluación**

**Parámetros de ruta:**
- `id` (long): ID de la evaluación

**Request Body:**
```json
{
  "riesgoId": 1,
  "clienteId": 1,
  "puntaje": 90,
  "fechaEvaluacion": "2024-01-20T14:00:00Z",
  "usuarioEvaluador": "María González",
  "observaciones": "Evaluación actualizada"
}
```

**Response (200 OK):**
```json
{
  "message": "Evaluación actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Evaluación no encontrada"
}
```

### 5. DELETE /api/Evaluaciones/{id}
**Eliminar evaluación**

**Parámetros de ruta:**
- `id` (long): ID de la evaluación

**Response (200 OK):**
```json
{
  "message": "Evaluación eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Evaluación no encontrada"
}
```

## DTOs

### EvaluacionDto
```json
{
  "id": "long",
  "riesgoId": "long",
  "clienteId": "long",
  "puntaje": "int",
  "fechaEvaluacion": "datetime",
  "usuarioEvaluador": "string",
  "observaciones": "string",
  "riesgoNombre": "string",
  "clienteNombre": "string"
}
```

### CreateEvaluacionDto
```json
{
  "riesgoId": "long",
  "clienteId": "long",
  "puntaje": "int",
  "fechaEvaluacion": "datetime",
  "usuarioEvaluador": "string",
  "observaciones": "string"
}
```
