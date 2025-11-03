# Módulo Pago

## Descripción
Registro y seguimiento de pagos realizados en operaciones financieras.

## Endpoints

### 1. GET /api/Pagos/operacion/{operacionId}
**Obtener pagos por operación**

**Parámetros de ruta:**
- `operacionId` (long): ID de la operación

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipo": "Efectivo",
    "moneda": "DOP",
    "monto": 50000.00
  },
  {
    "id": 2,
    "tipo": "Transferencia",
    "moneda": "USD",
    "monto": 1500.00
  }
]
```

### 2. GET /api/Pagos/{id}
**Obtener pago específico**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Response (200 OK):**
```json
{
  "id": 1,
  "tipo": "Efectivo",
  "moneda": "DOP",
  "monto": 50000.00
}
```

**Response (404 Not Found):**
```json
{
  "message": "Pago no encontrado"
}
```

### 3. POST /api/Pagos
**Crear nuevo pago**

**Request Body:**
```json
{
  "tipo": "Transferencia",
  "moneda": "MXN",
  "monto": 75000.50,
  "operacionId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Pago creado exitosamente"
}
```

### 4. PUT /api/Pagos/{id}
**Actualizar pago**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Request Body:**
```json
{
  "tipo": "Transferencia Internacional",
  "moneda": "USD",
  "monto": 2000.00,
  "operacionId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Pago actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Pago no encontrado"
}
```

### 5. DELETE /api/Pagos/{id}
**Eliminar pago**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Response (200 OK):**
```json
{
  "message": "Pago eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Pago no encontrado"
}
```

## DTOs

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
  "monto": "decimal",
  "operacionId": "long"
}
```
