# Módulo Direccion

## Descripción
Gestión de direcciones físicas de clientes.

## Endpoints

### 1. GET /api/Direcciones/cliente/{clienteId}
**Obtener direcciones por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "calle": "Av. Principal",
    "numero": "123",
    "sector": "Centro",
    "municipio": "Santo Domingo",
    "provincia": "Distrito Nacional",
    "pais": "República Dominicana",
    "codigoPostal": "10101"
  }
]
```

### 2. GET /api/Direcciones/{id}
**Obtener dirección específica**

**Parámetros de ruta:**
- `id` (long): ID de la dirección

**Response (200 OK):**
```json
{
  "id": 1,
  "calle": "Av. Principal",
  "numero": "123",
  "sector": "Centro",
  "municipio": "Santo Domingo",
  "provincia": "Distrito Nacional",
  "pais": "República Dominicana",
  "codigoPostal": "10101"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Dirección no encontrada"
}
```

### 3. POST /api/Direcciones/cliente/{clienteId}
**Crear nueva dirección**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Request Body:**
```json
{
  "calle": "Calle Nueva",
  "numero": "456",
  "sector": "Zona Industrial",
  "municipio": "Santiago",
  "provincia": "Santiago",
  "pais": "República Dominicana",
  "codigoPostal": "51000"
}
```

**Response (200 OK):**
```json
{
  "message": "Dirección creada exitosamente"
}
```

### 4. PUT /api/Direcciones/{id}
**Actualizar dirección**

**Parámetros de ruta:**
- `id` (long): ID de la dirección

**Request Body:**
```json
{
  "calle": "Calle Actualizada",
  "numero": "456",
  "sector": "Zona Industrial",
  "municipio": "Santiago",
  "provincia": "Santiago",
  "pais": "República Dominicana",
  "codigoPostal": "51000"
}
```

**Response (200 OK):**
```json
{
  "message": "Dirección actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Dirección no encontrada"
}
```

### 5. DELETE /api/Direcciones/{id}
**Eliminar dirección**

**Parámetros de ruta:**
- `id` (long): ID de la dirección

**Response (200 OK):**
```json
{
  "message": "Dirección eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Dirección no encontrada"
}
```

## DTOs

### DireccionDto
```json
{
  "id": "long",
  "calle": "string",
  "numero": "string",
  "sector": "string",
  "municipio": "string",
  "provincia": "string",
  "pais": "string",
  "codigoPostal": "string"
}
```

### CreateDireccionDto
```json
{
  "calle": "string",
  "numero": "string",
  "sector": "string",
  "municipio": "string",
  "provincia": "string",
  "pais": "string",
  "codigoPostal": "string"
}
```
