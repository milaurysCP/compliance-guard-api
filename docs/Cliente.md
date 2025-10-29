# Módulo Cliente

## Descripción
Gestión de clientes del sistema de compliance, incluyendo información básica y entidades relacionadas (direcciones, contactos).

## Endpoints

### 1. GET /api/Cliente
**Obtener lista de clientes**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipoCliente": "Persona Jurídica",
    "nombre": "Empresa ABC S.A.",
    "documentoIdentidad": "123456789"
  },
  {
    "id": 2,
    "tipoCliente": "Persona Natural",
    "nombre": "Juan Pérez",
    "documentoIdentidad": "098765432"
  }
]
```

### 2. POST /api/Cliente
**Crear nuevo cliente**

**Request Body:**
```json
{
  "tipoCliente": "Persona Jurídica",
  "nombre": "Empresa XYZ Ltda.",
  "documentoIdentidad": "112233445",
  "direcciones": [
    {
      "calle": "Av. Principal",
      "numero": "123",
      "sector": "Centro",
      "municipio": "Santo Domingo",
      "provincia": "Distrito Nacional",
      "pais": "República Dominicana"
    }
  ],
  "contactos": [
    {
      "tipo": "Correo",
      "valor": "contacto@empresa.com"
    }
  ]
}
```

**Response (200 OK):**
```json
{
  "message": "Cliente creado exitosamente"
}
```

### 3. PUT /api/Cliente/{id}
**Actualizar cliente**

**Parámetros de ruta:**
- `id` (long): ID del cliente

**Request Body:**
```json
{
  "nombre": "Empresa XYZ Ltda. (Actualizado)",
  "url": "https://empresa-xyz.com"
}
```

**Response (200 OK):**
```json
{
  "message": "Cliente actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Cliente no encontrado"
}
```

### 4. GET /api/Cliente/{id}
**Obtener detalle completo de cliente**

**Parámetros de ruta:**
- `id` (long): ID del cliente

**Response (200 OK):**
```json
{
  "id": 1,
  "tipoCliente": "Persona Jurídica",
  "nombre": "Empresa ABC S.A.",
  "url": "https://empresa-abc.com",
  "documentoIdentidad": "123456789",
  "registroComercial": "123456789",
  "fechaNacimiento": null,
  "direcciones": [
    {
      "id": 1,
      "calle": "Av. Principal",
      "numero": "123",
      "sector": "Centro",
      "municipio": "Santo Domingo",
      "provincia": "Distrito Nacional",
      "pais": "República Dominicana"
    }
  ],
  "contactos": [
    {
      "id": 1,
      "tipo": "Correo",
      "valor": "contacto@empresa.com"
    }
  ]
}
```

**Response (404 Not Found):**
```json
{
  "message": "Cliente no encontrado"
}
```

## DTOs

### ClienteSummaryDto
```json
{
  "id": "long",
  "tipoCliente": "string",
  "nombre": "string",
  "documentoIdentidad": "string"
}
```

### ClienteDetailDto
```json
{
  "id": "long",
  "tipoCliente": "string",
  "nombre": "string",
  "url": "string",
  "documentoIdentidad": "string",
  "registroComercial": "string",
  "fechaNacimiento": "date",
  "direcciones": "DireccionDto[]",
  "contactos": "ContactoDto[]"
}
```

### CreateClienteDto
```json
{
  "tipoCliente": "string",
  "nombre": "string",
  "documentoIdentidad": "string",
  "direcciones": "CreateDireccionDto[]",
  "contactos": "CreateContactoDto[]"
}
```

### UpdateClienteDto
```json
{
  "nombre": "string",
  "url": "string"
}
```