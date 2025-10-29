# Módulo Riesgo

## Descripción
Gestión de tipos de riesgo identificados en el sistema de compliance, incluyendo medidas de mitigación.

## Endpoints

### 1. GET /api/Riesgo
**Obtener lista de riesgos**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Lavado de Activos",
    "descripcion": "Riesgo de operaciones destinadas a ocultar origen ilícito de fondos",
    "mitigacion": "Verificación de origen de fondos y beneficiarios",
    "fechaCreacion": "2024-01-01T00:00:00Z",
    "cantidadEvaluaciones": 5
  },
  {
    "id": 2,
    "nombre": "Financiamiento del Terrorismo",
    "descripcion": "Riesgo de financiamiento de actividades terroristas",
    "mitigacion": "Monitoreo de listas internacionales y reportes sospechosos",
    "fechaCreacion": "2024-01-01T00:00:00Z",
    "cantidadEvaluaciones": 3
  }
]
```

### 2. GET /api/Riesgo/{id}
**Obtener riesgo específico**

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Lavado de Activos",
  "descripcion": "Riesgo de operaciones destinadas a ocultar origen ilícito de fondos",
  "mitigacion": "Verificación de origen de fondos y beneficiarios",
  "fechaCreacion": "2024-01-01T00:00:00Z",
  "cantidadEvaluaciones": 5
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado"
}
```

### 3. POST /api/Riesgo
**Crear nuevo riesgo**

**Request Body:**
```json
{
  "nombre": "Corrupción",
  "descripcion": "Riesgo de participación en actos de corrupción",
  "mitigacion": "Verificación de PEP y controles internos",
  "fechaCreacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Riesgo creado exitosamente"
}
```

### 4. PUT /api/Riesgo/{id}
**Actualizar riesgo**

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Request Body:**
```json
{
  "nombre": "Corrupción y Soborno",
  "descripcion": "Riesgo de participación en actos de corrupción y soborno",
  "mitigacion": "Verificación de PEP, controles internos y reportes obligatorios",
  "fechaCreacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Riesgo actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado"
}
```

### 5. DELETE /api/Riesgo/{id}
**Eliminar riesgo**

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Response (200 OK):**
```json
{
  "message": "Riesgo eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado"
}
```

## DTOs

### RiesgoDto
```json
{
  "id": "long",
  "nombre": "string",
  "descripcion": "string",
  "mitigacion": "string",
  "fechaCreacion": "datetime",
  "cantidadEvaluaciones": "int"
}
```

### CreateRiesgoDto
```json
{
  "nombre": "string",
  "descripcion": "string",
  "mitigacion": "string",
  "fechaCreacion": "datetime"
}
```