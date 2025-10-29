# Módulo ActividadEconomica

## Descripción
Catálogo de actividades económicas y sectores para clasificación de clientes.

## Endpoints

### 1. GET /api/ActividadEconomica
**Obtener lista de actividades económicas**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "codigo": "6201",
    "nombre": "Desarrollo de software",
    "descripcion": "Desarrollo, mantenimiento y consultoría de software",
    "sector": "Tecnología",
    "riesgoAsociado": "Bajo",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "codigo": "6419",
    "nombre": "Servicios financieros",
    "descripcion": "Servicios financieros no clasificados en otras categorías",
    "sector": "Financiero",
    "riesgoAsociado": "Alto",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 3,
    "codigo": "5610",
    "nombre": "Restaurantes y servicios de comida",
    "descripcion": "Explotación de restaurantes, bares y cantinas",
    "sector": "Servicios",
    "riesgoAsociado": "Medio",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/ActividadEconomica/{id}
**Obtener actividad económica específica**

**Parámetros de ruta:**
- `id` (long): ID de la actividad económica

**Response (200 OK):**
```json
{
  "id": 1,
  "codigo": "6201",
  "nombre": "Desarrollo de software",
  "descripcion": "Desarrollo, mantenimiento y consultoría de software",
  "sector": "Tecnología",
  "riesgoAsociado": "Bajo",
  "activo": true,
  "fechaRegistro": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Actividad económica no encontrada"
}
```

### 3. GET /api/ActividadEconomica/sector/{sector}
**Obtener actividades por sector**

**Parámetros de ruta:**
- `sector` (string): Nombre del sector

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "codigo": "6201",
    "nombre": "Desarrollo de software",
    "descripcion": "Desarrollo, mantenimiento y consultoría de software",
    "sector": "Tecnología",
    "riesgoAsociado": "Bajo",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 4,
    "codigo": "6202",
    "nombre": "Consultoría informática",
    "descripcion": "Asesoría y consultoría en tecnología de la información",
    "sector": "Tecnología",
    "riesgoAsociado": "Bajo",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 4. GET /api/ActividadEconomica/riesgo/{riesgo}
**Obtener actividades por nivel de riesgo**

**Parámetros de ruta:**
- `riesgo` (string): Nivel de riesgo (Bajo, Medio, Alto)

**Response (200 OK):**
```json
[
  {
    "id": 2,
    "codigo": "6419",
    "nombre": "Servicios financieros",
    "descripcion": "Servicios financieros no clasificados en otras categorías",
    "sector": "Financiero",
    "riesgoAsociado": "Alto",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 5,
    "codigo": "6499",
    "nombre": "Otras actividades financieras",
    "descripcion": "Otras actividades de servicios financieros n.c.p.",
    "sector": "Financiero",
    "riesgoAsociado": "Alto",
    "activo": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 5. POST /api/ActividadEconomica
**Crear nueva actividad económica**

**Request Body:**
```json
{
  "codigo": "7110",
  "nombre": "Arquitectura e ingeniería",
  "descripcion": "Servicios de arquitectura e ingeniería y actividades conexas de consultoría técnica",
  "sector": "Construcción",
  "riesgoAsociado": "Medio",
  "activo": true,
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Actividad económica creada exitosamente"
}
```

### 6. PUT /api/ActividadEconomica/{id}
**Actualizar actividad económica**

**Parámetros de ruta:**
- `id` (long): ID de la actividad económica

**Request Body:**
```json
{
  "codigo": "7110",
  "nombre": "Arquitectura, ingeniería y actividades conexas",
  "descripcion": "Servicios de arquitectura, ingeniería y actividades conexas de consultoría técnica",
  "sector": "Profesional",
  "riesgoAsociado": "Medio",
  "activo": true,
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Actividad económica actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Actividad económica no encontrada"
}
```

### 7. DELETE /api/ActividadEconomica/{id}
**Eliminar actividad económica**

**Parámetros de ruta:**
- `id` (long): ID de la actividad económica

**Response (200 OK):**
```json
{
  "message": "Actividad económica eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Actividad económica no encontrada"
}
```

## DTOs

### ActividadEconomicaDto
```json
{
  "id": "long",
  "codigo": "string",
  "nombre": "string",
  "descripcion": "string",
  "sector": "string",
  "riesgoAsociado": "string",
  "activo": "bool",
  "fechaRegistro": "datetime"
}
```

### CreateActividadEconomicaDto
```json
{
  "codigo": "string",
  "nombre": "string",
  "descripcion": "string",
  "sector": "string",
  "riesgoAsociado": "string",
  "activo": "bool",
  "fechaRegistro": "datetime"
}
```