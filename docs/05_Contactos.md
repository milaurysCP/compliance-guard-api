# Módulo Contactos

## Descripción
Gestión de contactos de clientes.

## Endpoints

### 1. GET /api/Contactos/cliente/{clienteId}
**Obtener contactos por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipo": "Teléfono",
    "valor": "+52551234567"
  },
  {
    "id": 2,
    "tipo": "Correo",
    "valor": "contacto@empresa.com"
  }
]
```

### 2. GET /api/Contactos/{id}
**Obtener contacto específico**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Response (200 OK):**
```json
{
  "id": 1,
  "tipo": "Teléfono",
  "valor": "+52551234567"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Contacto no encontrado"
}
```

### 3. POST /api/Contactos/cliente/{clienteId}
**Crear nuevo contacto**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Request Body:**
```json
{
  "tipo": "Móvil",
  "valor": "+52559876543"
}
```

**Response (200 OK):**
```json
{
  "message": "Contacto creado exitosamente"
}
```

### 4. PUT /api/Contactos/{id}
**Actualizar contacto**

**Parámetros de ruta:**
- `id` (long): ID del contacto

**Request Body:**
```json
{
  "tipo": "Móvil",
  "valor": "+52559876543"
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

### 5. DELETE /api/Contactos/{id}
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
  "tipo": "string",
  "valor": "string"
}
```

### CreateContactoDto
```json
{
  "tipo": "string",
  "valor": "string"
}
```