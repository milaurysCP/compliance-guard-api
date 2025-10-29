# Módulo Operacion

## Descripción
Gestión de operaciones financieras realizadas por los clientes, incluyendo pagos asociados.

## Endpoints

### 1. GET /api/Operacion/cliente/{clienteId}
**Obtener operaciones por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipo": "Transferencia",
    "codigo": "OP-001",
    "clienteId": 1,
    "pagos": [
      {
        "id": 1,
        "tipo": "Efectivo",
        "moneda": "DOP",
        "monto": 50000.00
      }
    ]
  }
]
```

### 2. GET /api/Operacion/{id}
**Obtener operación específica**

**Parámetros de ruta:**
- `id` (long): ID de la operación

**Response (200 OK):**
```json
{
  "id": 1,
  "tipo": "Transferencia",
  "codigo": "OP-001",
  "clienteId": 1,
  "pagos": [
    {
      "id": 1,
      "tipo": "Efectivo",
      "moneda": "DOP",
      "monto": 50000.00
    }
  ]
}
```

**Response (404 Not Found):**
```json
{
  "message": "Operación no encontrada"
}
```

### 3. POST /api/Operacion
**Crear nueva operación**

**Request Body:**
```json
{
  "clienteId": 1,
  "tipo": "Transferencia",
  "codigo": "OP-002",
  "pagos": [
    {
      "tipo": "Efectivo",
      "moneda": "DOP",
      "monto": 75000.50
    },
    {
      "tipo": "Transferencia",
      "moneda": "USD",
      "monto": 1500.00
    }
  ]
}
```

**Response (200 OK):**
```json
{
  "message": "Operación creada exitosamente"
}
```

### 4. PUT /api/Operacion/{id}
**Actualizar operación**

**Parámetros de ruta:**
- `id` (long): ID de la operación

**Request Body:**
```json
{
  "clienteId": 1,
  "tipo": "Transferencia Internacional",
  "codigo": "OP-002-UPD",
  "pagos": [
    {
      "tipo": "Transferencia",
      "moneda": "USD",
      "monto": 2000.00
    }
  ]
}
```

**Response (200 OK):**
```json
{
  "message": "Operación actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Operación no encontrada"
}
```

### 5. DELETE /api/Operacion/{id}
**Eliminar operación**

**Parámetros de ruta:**
- `id` (long): ID de la operación

**Response (200 OK):**
```json
{
  "message": "Operación eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Operación no encontrada"
}
```

## DTOs

### OperacionDto
```json
{
  "id": "long",
  "tipo": "string",
  "codigo": "string",
  "clienteId": "long",
  "pagos": "PagoDto[]"
}
```

### CreateOperacionDto
```json
{
  "clienteId": "long",
  "tipo": "string",
  "codigo": "string",
  "pagos": "CreatePagoDto[]"
}
```

### PagoDto
```json
{
  "id": "long",
  "tipo": "string",
  "moneda": "string",
  "monto": "decimal"
}
```

### CreatePagoDto
```json
{
  "tipo": "string",
  "moneda": "string",
  "monto": "decimal"
}
```