# Módulo Politica

## Descripción
Gestión de políticas de compliance y regulaciones aplicables al sistema.

## Endpoints

### 1. GET /api/Politica
**Obtener lista de políticas**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Política de Conocimiento del Cliente",
    "descripcion": "Establece los procedimientos para identificar y verificar la identidad de los clientes",
    "fechaCreacion": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "nombre": "Política de Prevención de Lavado de Activos",
    "descripcion": "Marco normativo para prevenir y detectar operaciones de lavado de activos",
    "fechaCreacion": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/Politica/{id}
**Obtener política específica**

**Parámetros de ruta:**
- `id` (long): ID de la política

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Política de Conocimiento del Cliente",
  "descripcion": "Establece los procedimientos para identificar y verificar la identidad de los clientes",
  "fechaCreacion": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Política no encontrada"
}
```

### 3. POST /api/Politica
**Crear nueva política**

**Request Body:**
```json
{
  "nombre": "Política de Protección de Datos",
  "descripcion": "Establece las medidas para proteger la información personal de los clientes",
  "fechaCreacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Política creada exitosamente"
}
```

### 4. PUT /api/Politica/{id}
**Actualizar política**

**Parámetros de ruta:**
- `id` (long): ID de la política

**Request Body:**
```json
{
  "nombre": "Política de Protección de Datos Personales",
  "descripcion": "Establece las medidas para proteger la información personal y sensible de los clientes según RGPD",
  "fechaCreacion": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Política actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Política no encontrada"
}
```

### 5. DELETE /api/Politica/{id}
**Eliminar política**

**Parámetros de ruta:**
- `id` (long): ID de la política

**Response (200 OK):**
```json
{
  "message": "Política eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Política no encontrada"
}
```

## DTOs

### PoliticaDto
```json
{
  "id": "long",
  "nombre": "string",
  "descripcion": "string",
  "fechaCreacion": "datetime"
}
```

### CreatePoliticaDto
```json
{
  "nombre": "string",
  "descripcion": "string",
  "fechaCreacion": "datetime"
}
```