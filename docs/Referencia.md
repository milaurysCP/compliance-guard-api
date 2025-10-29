# Módulo Referencia

## Descripción
Gestión de referencias bancarias y financieras de clientes.

## Endpoints

### 1. GET /api/Referencia
**Obtener lista de referencias**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "banco": "Banco Nacional",
    "numeroCuenta": "1234567890",
    "tipoCuenta": "Corriente",
    "moneda": "MXN",
    "fechaApertura": "2020-01-15T00:00:00Z",
    "saldoPromedio": 50000.00,
    "estado": "Activa"
  },
  {
    "id": 2,
    "clienteId": 2,
    "banco": "Banco Internacional",
    "numeroCuenta": "0987654321",
    "tipoCuenta": "Ahorro",
    "moneda": "USD",
    "fechaApertura": "2019-06-20T00:00:00Z",
    "saldoPromedio": 25000.00,
    "estado": "Activa"
  }
]
```

### 2. GET /api/Referencia/{id}
**Obtener referencia específica**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "banco": "Banco Nacional",
  "numeroCuenta": "1234567890",
  "tipoCuenta": "Corriente",
  "moneda": "MXN",
  "fechaApertura": "2020-01-15T00:00:00Z",
  "saldoPromedio": 50000.00,
  "estado": "Activa"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

### 3. GET /api/Referencia/cliente/{clienteId}
**Obtener referencias por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "banco": "Banco Nacional",
    "numeroCuenta": "1234567890",
    "tipoCuenta": "Corriente",
    "moneda": "MXN",
    "fechaApertura": "2020-01-15T00:00:00Z",
    "saldoPromedio": 50000.00,
    "estado": "Activa"
  },
  {
    "id": 3,
    "clienteId": 1,
    "banco": "Banco Regional",
    "numeroCuenta": "5555666677",
    "tipoCuenta": "Inversión",
    "moneda": "MXN",
    "fechaApertura": "2021-03-10T00:00:00Z",
    "saldoPromedio": 100000.00,
    "estado": "Activa"
  }
]
```

### 4. POST /api/Referencia
**Crear nueva referencia**

**Request Body:**
```json
{
  "clienteId": 1,
  "banco": "Banco Digital",
  "numeroCuenta": "1111222233",
  "tipoCuenta": "Digital",
  "moneda": "MXN",
  "fechaApertura": "2023-08-01T00:00:00Z",
  "saldoPromedio": 15000.00,
  "estado": "Activa"
}
```

**Response (200 OK):**
```json
{
  "message": "Referencia creada exitosamente"
}
```

### 5. PUT /api/Referencia/{id}
**Actualizar referencia**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Request Body:**
```json
{
  "clienteId": 1,
  "banco": "Banco Digital Plus",
  "numeroCuenta": "1111222233",
  "tipoCuenta": "Digital Premium",
  "moneda": "MXN",
  "fechaApertura": "2023-08-01T00:00:00Z",
  "saldoPromedio": 25000.00,
  "estado": "Activa"
}
```

**Response (200 OK):**
```json
{
  "message": "Referencia actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

### 6. DELETE /api/Referencia/{id}
**Eliminar referencia**

**Parámetros de ruta:**
- `id` (long): ID de la referencia

**Response (200 OK):**
```json
{
  "message": "Referencia eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Referencia no encontrada"
}
```

## DTOs

### ReferenciaDto
```json
{
  "id": "long",
  "clienteId": "long",
  "banco": "string",
  "numeroCuenta": "string",
  "tipoCuenta": "string",
  "moneda": "string",
  "fechaApertura": "datetime",
  "saldoPromedio": "decimal",
  "estado": "string"
}
```

### CreateReferenciaDto
```json
{
  "clienteId": "long",
  "banco": "string",
  "numeroCuenta": "string",
  "tipoCuenta": "string",
  "moneda": "string",
  "fechaApertura": "datetime",
  "saldoPromedio": "decimal",
  "estado": "string"
}
```