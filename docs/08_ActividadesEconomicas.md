# Módulo ActividadEconomica

## Descripción
Gestión de actividades económicas de clientes.

## Endpoints

### 1. GET /api/ActividadesEconomicas/cliente/{clienteId}
**Obtener actividades económicas por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipo": "Comercio",
    "descripcion": "Actividades comerciales generales"
  },
  {
    "id": 2,
    "tipo": "Servicios Financieros",
    "descripcion": "Prestación de servicios financieros"
  }
]
```

### 2. GET /api/ActividadesEconomicas/{id}
**Obtener actividad económica específica**

**Parámetros de ruta:**
- `id` (long): ID de la actividad económica

**Response (200 OK):**
```json
{
  "id": 1,
  "tipo": "Comercio",
  "descripcion": "Actividades comerciales generales"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Actividad económica no encontrada"
}
```

### 3. POST /api/ActividadesEconomicas/cliente/{clienteId}
**Crear nueva actividad económica**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Request Body:**
```json
{
  "tipo": "Manufactura",
  "descripcion": "Actividades de producción industrial"
}
```

**Response (200 OK):**
```json
{
  "message": "Actividad económica creada exitosamente"
}
```

### 4. PUT /api/ActividadesEconomicas/{id}
**Actualizar actividad económica**

**Parámetros de ruta:**
- `id` (long): ID de la actividad económica

**Request Body:**
```json
{
  "tipo": "Manufactura Avanzada",
  "descripcion": "Actividades de producción industrial avanzada"
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

### 5. DELETE /api/ActividadesEconomicas/{id}
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
  "tipo": "string",
  "descripcion": "string"
}
```

### CreateActividadEconomicaDto
```json
{
  "tipo": "string",
  "descripcion": "string"
}
```
