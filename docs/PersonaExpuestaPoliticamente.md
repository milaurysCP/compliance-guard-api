# Módulo PersonaExpuestaPoliticamente

## Descripción
Gestión de Personas Expuestas Políticamente (PEP) asociadas a los clientes para evaluación de riesgos de compliance.

## Endpoints

### 1. GET /api/PersonaExpuestaPoliticamente/cliente/{clienteId}
**Obtener personas expuestas políticamente por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Juan Pérez García",
    "cargo": "Ministro de Hacienda",
    "ordenanza": "Ordenanza 001-2024",
    "institucion": "Ministerio de Hacienda",
    "clienteId": 1
  }
]
```

### 2. GET /api/PersonaExpuestaPoliticamente/{id}
**Obtener persona expuesta políticamente específica**

**Parámetros de ruta:**
- `id` (long): ID de la persona expuesta políticamente

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Juan Pérez García",
  "cargo": "Ministro de Hacienda",
  "ordenanza": "Ordenanza 001-2024",
  "institucion": "Ministerio de Hacienda",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Persona expuesta políticamente no encontrada"
}
```

### 3. POST /api/PersonaExpuestaPoliticamente
**Crear nueva persona expuesta políticamente**

**Request Body:**
```json
{
  "nombre": "María González López",
  "cargo": "Directora Ejecutiva",
  "ordenanza": "Ordenanza 002-2024",
  "institucion": "Banco Central",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Persona expuesta políticamente creada exitosamente"
}
```

### 4. PUT /api/PersonaExpuestaPoliticamente/{id}
**Actualizar persona expuesta políticamente**

**Parámetros de ruta:**
- `id` (long): ID de la persona expuesta políticamente

**Request Body:**
```json
{
  "nombre": "María González López",
  "cargo": "Ex-Directora Ejecutiva",
  "ordenanza": "Ordenanza 002-2024",
  "institucion": "Banco Central",
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

### 5. DELETE /api/PersonaExpuestaPoliticamente/{id}
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