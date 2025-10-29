# Módulo ProgresoCapacitacion

## Descripción
Seguimiento del progreso de los usuarios en los programas de capacitación.

## Endpoints

### 1. GET /api/ProgresoCapacitacion
**Obtener lista de progreso de capacitaciones**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "capacitacionId": 1,
    "progresoPorcentaje": 75.5,
    "estado": "En Progreso",
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaCompletado": null,
    "calificacion": null,
    "observaciones": "Buen progreso en los módulos iniciales"
  },
  {
    "id": 2,
    "usuarioId": 2,
    "capacitacionId": 1,
    "progresoPorcentaje": 100.0,
    "estado": "Completado",
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaCompletado": "2024-02-01T17:00:00Z",
    "calificacion": 95,
    "observaciones": "Excelente desempeño en todos los módulos"
  }
]
```

### 2. GET /api/ProgresoCapacitacion/{id}
**Obtener progreso específico**

**Parámetros de ruta:**
- `id` (long): ID del progreso

**Response (200 OK):**
```json
{
  "id": 1,
  "usuarioId": 1,
  "capacitacionId": 1,
  "progresoPorcentaje": 75.5,
  "estado": "En Progreso",
  "fechaInicio": "2024-02-01T09:00:00Z",
  "fechaCompletado": null,
  "calificacion": null,
  "observaciones": "Buen progreso en los módulos iniciales"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Progreso de capacitación no encontrado"
}
```

### 3. GET /api/ProgresoCapacitacion/usuario/{usuarioId}
**Obtener progreso por usuario**

**Parámetros de ruta:**
- `usuarioId` (long): ID del usuario

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "capacitacionId": 1,
    "progresoPorcentaje": 75.5,
    "estado": "En Progreso",
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaCompletado": null,
    "calificacion": null,
    "observaciones": "Buen progreso en los módulos iniciales"
  },
  {
    "id": 3,
    "usuarioId": 1,
    "capacitacionId": 2,
    "progresoPorcentaje": 30.0,
    "estado": "En Progreso",
    "fechaInicio": "2024-02-15T09:00:00Z",
    "fechaCompletado": null,
    "calificacion": null,
    "observaciones": "Inició recientemente el curso"
  }
]
```

### 4. GET /api/ProgresoCapacitacion/capacitacion/{capacitacionId}
**Obtener progreso por capacitación**

**Parámetros de ruta:**
- `capacitacionId` (long): ID de la capacitación

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "capacitacionId": 1,
    "progresoPorcentaje": 75.5,
    "estado": "En Progreso",
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaCompletado": null,
    "calificacion": null,
    "observaciones": "Buen progreso en los módulos iniciales"
  },
  {
    "id": 2,
    "usuarioId": 2,
    "capacitacionId": 1,
    "progresoPorcentaje": 100.0,
    "estado": "Completado",
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaCompletado": "2024-02-01T17:00:00Z",
    "calificacion": 95,
    "observaciones": "Excelente desempeño en todos los módulos"
  }
]
```

### 5. POST /api/ProgresoCapacitacion
**Crear nuevo progreso de capacitación**

**Request Body:**
```json
{
  "usuarioId": 3,
  "capacitacionId": 1,
  "progresoPorcentaje": 0.0,
  "estado": "Iniciado",
  "fechaInicio": "2024-02-20T09:00:00Z",
  "fechaCompletado": null,
  "calificacion": null,
  "observaciones": "Usuario inscrito recientemente"
}
```

**Response (200 OK):**
```json
{
  "message": "Progreso de capacitación creado exitosamente"
}
```

### 6. PUT /api/ProgresoCapacitacion/{id}
**Actualizar progreso de capacitación**

**Parámetros de ruta:**
- `id` (long): ID del progreso

**Request Body:**
```json
{
  "usuarioId": 1,
  "capacitacionId": 1,
  "progresoPorcentaje": 85.0,
  "estado": "En Progreso",
  "fechaInicio": "2024-02-01T09:00:00Z",
  "fechaCompletado": null,
  "calificacion": null,
  "observaciones": "Avance significativo en módulos avanzados"
}
```

**Response (200 OK):**
```json
{
  "message": "Progreso de capacitación actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Progreso de capacitación no encontrado"
}
```

### 7. PUT /api/ProgresoCapacitacion/{id}/completar
**Marcar capacitación como completada**

**Parámetros de ruta:**
- `id` (long): ID del progreso

**Request Body:**
```json
{
  "calificacion": 88,
  "observaciones": "Capacitación completada satisfactoriamente"
}
```

**Response (200 OK):**
```json
{
  "message": "Capacitación marcada como completada"
}
```

### 8. DELETE /api/ProgresoCapacitacion/{id}
**Eliminar progreso de capacitación**

**Parámetros de ruta:**
- `id` (long): ID del progreso

**Response (200 OK):**
```json
{
  "message": "Progreso de capacitación eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Progreso de capacitación no encontrado"
}
```

## DTOs

### ProgresoCapacitacionDto
```json
{
  "id": "long",
  "usuarioId": "long",
  "capacitacionId": "long",
  "progresoPorcentaje": "decimal",
  "estado": "string",
  "fechaInicio": "datetime",
  "fechaCompletado": "datetime?",
  "calificacion": "int?",
  "observaciones": "string"
}
```

### CreateProgresoCapacitacionDto
```json
{
  "usuarioId": "long",
  "capacitacionId": "long",
  "progresoPorcentaje": "decimal",
  "estado": "string",
  "fechaInicio": "datetime",
  "fechaCompletado": "datetime?",
  "calificacion": "int?",
  "observaciones": "string"
}
```

### CompletarCapacitacionDto
```json
{
  "calificacion": "int",
  "observaciones": "string"
}
```