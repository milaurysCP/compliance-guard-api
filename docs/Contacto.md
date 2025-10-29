# Módulo Contacto

## Descripción
Gestión de información de contacto de clientes y entidades relacionadas.

## Endpoints

### 1. GET /api/Contacto
**Obtener lista de contactos**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "tipoContacto": "Teléfono Principal",
    "valor": "+52551234567",
    "descripcion": "Teléfono oficina principal",
    "esPrincipal": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "tipoContacto": "Email",
    "valor": "contacto@empresa.com",
    "descripcion": "Correo electrónico principal",
    "esPrincipal": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 3,
    "clienteId": 1,
    "tipoContacto": "Teléfono Móvil",
    "valor": "+52559876543",
    "descripcion": "Teléfono del gerente",
    "esPrincipal": false,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 2. GET /api/Contacto/{id}
**Obtener contacto específico**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "tipoContacto": "Teléfono Principal",
  "valor": "+52551234567",
  "descripcion": "Teléfono oficina principal",
  "esPrincipal": true,
  "fechaRegistro": "2024-01-01T00:00:00Z"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Contacto no encontrado"
}
```

### 3. GET /api/Contacto/cliente/{clienteId}
**Obtener contactos por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "tipoContacto": "Teléfono Principal",
    "valor": "+52551234567",
    "descripcion": "Teléfono oficina principal",
    "esPrincipal": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  },
  {
    "id": 2,
    "clienteId": 1,
    "tipoContacto": "Email",
    "valor": "contacto@empresa.com",
    "descripcion": "Correo electrónico principal",
    "esPrincipal": true,
    "fechaRegistro": "2024-01-01T00:00:00Z"
  }
]
```

### 4. GET /api/Contacto/principal/{clienteId}
**Obtener contacto principal por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
{
  "id": 2,
  "clienteId": 1,
  "tipoContacto": "Email",
  "valor": "contacto@empresa.com",
  "descripcion": "Correo electrónico principal",
  "esPrincipal": true,
  "fechaRegistro": "2024-01-01T00:00:00Z"
}
```

### 5. POST /api/Contacto
**Crear nuevo contacto**

**Request Body:**
```json
{
  "clienteId": 2,
  "tipoContacto": "WhatsApp",
  "valor": "+52551111222",
  "descripcion": "Número de WhatsApp para emergencias",
  "esPrincipal": false,
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Contacto creado exitosamente"
}
```

### 6. PUT /api/Contacto/{id}
**Actualizar contacto**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Request Body:**
```json
{
  "clienteId": 2,
  "tipoContacto": "WhatsApp Business",
  "valor": "+52551111222",
  "descripcion": "Número de WhatsApp Business para atención al cliente",
  "esPrincipal": false,
  "fechaRegistro": "2024-01-15T10:00:00Z"
}
```

**Response (200 OK):**
```json
{
  "message": "Contacto actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Contacto no encontrado"
}
```

### 7. PUT /api/Contacto/{id}/principal
**Establecer contacto como principal**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Response (200 OK):**
```json
{
  "message": "Contacto establecido como principal"
}
```

### 8. DELETE /api/Contacto/{id}
**Eliminar contacto**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Response (200 OK):**
```json
{
  "message": "Contacto eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Contacto no encontrado"
}
```

## DTOs

### ContactoDto
```json
{
  "id": "long",
  "clienteId": "long",
  "tipoContacto": "string",
  "valor": "string",
  "descripcion": "string",
  "esPrincipal": "bool",
  "fechaRegistro": "datetime"
}
```

### CreateContactoDto
```json
{
  "clienteId": "long",
  "tipoContacto": "string",
  "valor": "string",
  "descripcion": "string",
  "esPrincipal": "bool",
  "fechaRegistro": "datetime"
}
```