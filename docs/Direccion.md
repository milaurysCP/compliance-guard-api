# Módulo Direccion

## Descripción
Gestión de direcciones físicas y de contacto de clientes y entidades.

## Endpoints

### 1. GET /api/Direccion
**Obtener lista de direcciones**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "tipoDireccion": "Fiscal",
    "calle": "Av. Reforma 123",
    "numeroExterior": "123",
    "numeroInterior": "A",
    "colonia": "Centro",
    "codigoPostal": "06000",
    "ciudad": "Ciudad de México",
    "estado": "CDMX",
    "pais": "México",
    "referencias": "Entre Juárez y 5 de Mayo",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "tipoDireccion": "Comercial",
    "calle": "Paseo de la Reforma",
    "numeroExterior": "456",
    "numeroInterior": null,
    "colonia": "Juárez",
    "codigoPostal": "06600",
    "ciudad": "Ciudad de México",
    "estado": "CDMX",
    "pais": "México",
    "referencias": "Plaza Reforma",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/Direccion/{id}
**Obtener dirección específica**

**Parámetros de ruta:**
- `id` (long): ID de la dirección

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "tipoDireccion": "Fiscal",
  "calle": "Av. Reforma 123",
  "numeroExterior": "123",
  "numeroInterior": "A",
  "colonia": "Centro",
  "codigoPostal": "06000",
  "ciudad": "Ciudad de México",
  "estado": "CDMX",
  "pais": "México",
  "referencias": "Entre Juárez y 5 de Mayo",
  "fechaRegistro": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Dirección no encontrada"
}
```

### 3. GET /api/Direccion/cliente/{clienteId}
**Obtener direcciones por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "tipoDireccion": "Fiscal",
    "calle": "Av. Reforma 123",
    "numeroExterior": "123",
    "numeroInterior": "A",
    "colonia": "Centro",
    "codigoPostal": "06000",
    "ciudad": "Ciudad de México",
    "estado": "CDMX",
    "pais": "México",
    "referencias": "Entre Juárez y 5 de Mayo",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "tipoDireccion": "Comercial",
    "calle": "Paseo de la Reforma",
    "numeroExterior": "456",
    "numeroInterior": null,
    "colonia": "Juárez",
    "codigoPostal": "06600",
    "ciudad": "Ciudad de México",
    "estado": "CDMX",
    "pais": "México",
    "referencias": "Plaza Reforma",
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 4. POST /api/Direccion
**Crear nueva dirección**

**Request Body:**
```json
{
  "clienteId": 2,
  "tipoDireccion": "Sucursal",
  "calle": "Boulevard Manuel Ávila Camacho",
  "numeroExterior": "789",
  "numeroInterior": "PB",
  "colonia": "Polanco",
  "codigoPostal": "11550",
  "ciudad": "Ciudad de México",
  "estado": "CDMX",
  "pais": "México",
  "referencias": "Frente al parque",
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Dirección creada exitosamente"
}
```

### 5. PUT /api/Direccion/{id}
**Actualizar dirección**

**Parámetros de ruta:**
- `id` (long): ID de la dirección

**Request Body:**
```json
{
  "clienteId": 2,
  "tipoDireccion": "Sucursal Principal",
  "calle": "Boulevard Manuel Ávila Camacho",
  "numeroExterior": "789",
  "numeroInterior": "PB",
  "colonia": "Polanco",
  "codigoPostal": "11550",
  "ciudad": "Ciudad de México",
  "estado": "CDMX",
  "pais": "México",
  "referencias": "Frente al parque Chapultepec",
  "fechaRegistro": "2024-01-15T10:00:00Z"
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

### 6. DELETE /api/Direccion/{id}
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
  "clienteId": "long",
  "tipoDireccion": "string",
  "calle": "string",
  "numeroExterior": "string",
  "numeroInterior": "string?",
  "colonia": "string",
  "codigoPostal": "string",
  "ciudad": "string",
  "estado": "string",
  "pais": "string",
  "referencias": "string?",
  "fechaRegistro": "datetime"
}
```

### CreateDireccionDto
```json
{
  "clienteId": "long",
  "tipoDireccion": "string",
  "calle": "string",
  "numeroExterior": "string",
  "numeroInterior": "string?",
  "colonia": "string",
  "codigoPostal": "string",
  "ciudad": "string",
  "estado": "string",
  "pais": "string",
  "referencias": "string?",
  "fechaRegistro": "datetime"
}
```