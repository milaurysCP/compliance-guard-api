# Módulo PersonaExpuestaPoliticamente

## Descripción
Gestión de personas expuestas políticamente (PEP) asociadas a clientes.

## Endpoints

### 1. GET /api/PersonasExpuestasPoliticamente
**Obtener lista de personas expuestas políticamente**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Juan Pérez",
    "cargo": "Ministro de Economía",
    "ordenanza": "Decreto 123/2020",
    "institucion": "Ministerio de Economía",
    "clienteId": 1
  }
]
```

### 2. GET /api/PersonasExpuestasPoliticamente/{id}
**Obtener persona expuesta políticamente específica**

**Parámetros de ruta:**
- `id` (long): ID de la persona expuesta políticamente

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Juan Pérez",
  "cargo": "Ministro de Economía",
  "ordenanza": "Decreto 123/2020",
  "institucion": "Ministerio de Economía",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Persona expuesta políticamente no encontrada"
}
```

### 3. POST /api/PersonasExpuestasPoliticamente
**Crear nueva persona expuesta políticamente**

**Request Body:**
```json
{
  "nombre": "María González",
  "cargo": "Diputada Nacional",
  "ordenanza": "Ley 456/2021",
  "institucion": "Cámara de Diputados",
  "clienteId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Persona expuesta políticamente creada exitosamente"
}
```

### 4. PUT /api/PersonasExpuestasPoliticamente/{id}
**Actualizar persona expuesta políticamente**

**Parámetros de ruta:**
- `id` (long): ID de la persona expuesta políticamente

**Request Body:**
```json
{
  "nombre": "Juan Pérez",
  "cargo": "Ex-Ministro de Economía",
  "ordenanza": "Decreto 123/2020",
  "institucion": "Ministerio de Economía",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Persona expuesta políticamente actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Persona expuesta políticamente no encontrada"
}
```

### 5. DELETE /api/PersonasExpuestasPoliticamente/{id}
**Eliminar persona expuesta políticamente**

**Parámetros de ruta:**
- `id` (long): ID de la persona expuesta políticamente

**Response (200 OK):**
```json
{
  "message": "Persona expuesta políticamente eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Persona expuesta políticamente no encontrada"
}
```

## DTOs

### PersonaExpuestaPoliticamenteDto
```json
{
  "id": "long",
  "nombre": "string",
  "cargo": "string",
  "ordenanza": "string",
  "institucion": "string",
  "clienteId": "long"
}
```

### CreatePersonaExpuestaPoliticamenteDto
```json
{
  "nombre": "string",
  "cargo": "string",
  "ordenanza": "string",
  "institucion": "string",
  "clienteId": "long"
}
```