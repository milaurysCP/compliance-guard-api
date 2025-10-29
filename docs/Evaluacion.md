# Módulo Evaluacion

## Descripción
Gestión de evaluaciones de riesgo realizadas a los clientes, incluyendo puntuaciones y niveles de riesgo.

## Endpoints

### 1. GET /api/Evaluacion/cliente/{clienteId}
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
    "nivelRiesgo": "Alto"
  }
]
```

### 2. GET /api/Evaluacion/riesgo/{riesgoId}
**Obtener evaluaciones por riesgo**

**Parámetros de ruta:**
- `riesgoId` (long): ID del riesgo

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "riesgoId": 1,
    "clienteId": 1,
    "puntaje": 75,
    "fechaEvaluacion": "2024-01-15T10:30:00Z",
    "nivelRiesgo": "Alto"
  }
]
```

### 3. GET /api/Evaluacion/{id}
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
  "nivelRiesgo": "Alto"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Evaluación no encontrada"
}
```

### 4. POST /api/Evaluacion
**Crear nueva evaluación**

**Request Body:**
```json
{
  "riesgoId": 1,
  "clienteId": 1,
  "puntaje": 85,
  "fechaEvaluacion": "2024-01-20T14:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Evaluación creada exitosamente"
}
```

### 5. PUT /api/Evaluacion/{id}
**Actualizar evaluación**

**Parámetros de ruta:**
- `id` (long): ID de la evaluación

**Request Body:**
```json
{
  "riesgoId": 1,
  "clienteId": 1,
  "puntaje": 90,
  "fechaEvaluacion": "2024-01-20T14:00:00Z"
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

### 6. DELETE /api/Evaluacion/{id}
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
  "nivelRiesgo": "string"
}
```

### CreateEvaluacionDto
```json
{
  "riesgoId": "long",
  "clienteId": "long",
  "puntaje": "int (0-100)",
  "fechaEvaluacion": "datetime"
}
```