# Módulo Capacitacion

## Descripción
Gestión de programas de capacitación y formación en compliance.

## Endpoints

### 1. GET /api/Capacitacion
**Obtener lista de capacitaciones**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "titulo": "Prevención de Lavado de Activos",
    "descripcion": "Curso básico sobre identificación y prevención de operaciones de lavado de activos",
    "duracionHoras": 8,
    "fechaInicio": "2024-02-01T09:00:00Z",
    "fechaFin": "2024-02-01T17:00:00Z",
    "instructor": "Dr. María González",
    "estado": "Activa"
  },
  {
    "id": 2,
    "titulo": "Conocimiento del Cliente",
    "descripcion": "Programa de formación sobre procedimientos KYC",
    "duracionHoras": 12,
    "fechaInicio": "2024-02-15T09:00:00Z",
    "fechaFin": "2024-02-16T17:00:00Z",
    "instructor": "Lic. Carlos Rodríguez",
    "estado": "Programada"
  }
]
```

### 2. GET /api/Capacitacion/{id}
**Obtener capacitación específica**

**Parámetros de ruta:**
- `id` (long): ID de la capacitación

**Response (200 OK):**
```json
{
  "id": 1,
  "titulo": "Prevención de Lavado de Activos",
  "descripcion": "Curso básico sobre identificación y prevención de operaciones de lavado de activos",
  "duracionHoras": 8,
  "fechaInicio": "2024-02-01T09:00:00Z",
  "fechaFin": "2024-02-01T17:00:00Z",
  "instructor": "Dr. María González",
  "estado": "Activa"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Capacitación no encontrada"
}
```

### 3. POST /api/Capacitacion
**Crear nueva capacitación**

**Request Body:**
```json
{
  "titulo": "Protección de Datos Personales",
  "descripcion": "Curso sobre cumplimiento del RGPD y protección de datos",
  "duracionHoras": 6,
  "fechaInicio": "2024-03-01T09:00:00Z",
  "fechaFin": "2024-03-01T15:00:00Z",
  "instructor": "Lic. Ana López",
  "estado": "Programada"
}
```

**Response (200 OK):**
```json
{
  "message": "Capacitación creada exitosamente"
}
```

### 4. PUT /api/Capacitacion/{id}
**Actualizar capacitación**

**Parámetros de ruta:**
- `id` (long): ID de la capacitación

**Request Body:**
```json
{
  "titulo": "Protección de Datos Personales RGPD",
  "descripcion": "Curso completo sobre cumplimiento del RGPD y protección de datos personales",
  "duracionHoras": 8,
  "fechaInicio": "2024-03-01T09:00:00Z",
  "fechaFin": "2024-03-01T17:00:00Z",
  "instructor": "Lic. Ana López",
  "estado": "Programada"
}
```

**Response (200 OK):**
```json
{
  "message": "Capacitación actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Capacitación no encontrada"
}
```

### 5. DELETE /api/Capacitacion/{id}
**Eliminar capacitación**

**Parámetros de ruta:**
- `id` (long): ID de la capacitación

**Response (200 OK):**
```json
{
  "message": "Capacitación eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Capacitación no encontrada"
}
```

## DTOs

### CapacitacionDto
```json
{
  "id": "long",
  "titulo": "string",
  "descripcion": "string",
  "duracionHoras": "int",
  "fechaInicio": "datetime",
  "fechaFin": "datetime",
  "instructor": "string",
  "estado": "string"
}
```

### CreateCapacitacionDto
```json
{
  "titulo": "string",
  "descripcion": "string",
  "duracionHoras": "int",
  "fechaInicio": "datetime",
  "fechaFin": "datetime",
  "instructor": "string",
  "estado": "string"
}
```