# Módulo Pago

## Descripción
Registro y seguimiento de pagos realizados por clientes en operaciones financieras.

## Endpoints

### 1. GET /api/Pago
**Obtener lista de pagos**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "transaccionId": 1,
    "monto": 50000.00,
    "moneda": "MXN",
    "metodoPago": "Transferencia Bancaria",
    "referencia": "TRF2024001",
    "fechaPago": "2024-01-15T10:30:00Z",
    "estado": "Completado",
    "bancoOrigen": "Banco Nacional",
    "bancoDestino": "Banco Internacional",
    "cuentaOrigen": "1234567890",
    "cuentaDestino": "0987654321",
    "observaciones": "Pago completado exitosamente"
  },
  {
    "id": 2,
    "transaccionId": 2,
    "monto": 25000.00,
    "moneda": "USD",
    "metodoPago": "Cheque",
    "referencia": "CHQ2024002",
    "fechaPago": "2024-01-16T14:20:00Z",
    "estado": "Pendiente",
    "bancoOrigen": "Bank of America",
    "bancoDestino": "Citibank",
    "cuentaOrigen": "9876543210",
    "cuentaDestino": "0123456789",
    "observaciones": "Cheque en proceso de compensación"
  }
]
```

### 2. GET /api/Pago/{id}
**Obtener pago específico**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Response (200 OK):**
```json
{
  "id": 1,
  "transaccionId": 1,
  "monto": 50000.00,
  "moneda": "MXN",
  "metodoPago": "Transferencia Bancaria",
  "referencia": "TRF2024001",
  "fechaPago": "2024-01-15T10:30:00Z",
  "estado": "Completado",
  "bancoOrigen": "Banco Nacional",
  "bancoDestino": "Banco Internacional",
  "cuentaOrigen": "1234567890",
  "cuentaDestino": "0987654321",
  "observaciones": "Pago completado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Pago no encontrado"
}
```

### 3. GET /api/Pago/transaccion/{transaccionId}
**Obtener pagos por transacción**

**Parámetros de ruta:**
- `transaccionId` (long): ID de la transacción

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "transaccionId": 1,
    "monto": 30000.00,
    "moneda": "MXN",
    "metodoPago": "Transferencia Bancaria",
    "referencia": "TRF2024001A",
    "fechaPago": "2024-01-15T10:30:00Z",
    "estado": "Completado",
    "bancoOrigen": "Banco Nacional",
    "bancoDestino": "Banco Internacional",
    "cuentaOrigen": "1234567890",
    "cuentaDestino": "0987654321",
    "observaciones": "Primer pago parcial"
  },
  {
    "id": 3,
    "transaccionId": 1,
    "monto": 20000.00,
    "moneda": "MXN",
    "metodoPago": "Transferencia Bancaria",
    "referencia": "TRF2024001B",
    "fechaPago": "2024-01-16T11:45:00Z",
    "estado": "Completado",
    "bancoOrigen": "Banco Nacional",
    "bancoDestino": "Banco Internacional",
    "cuentaOrigen": "1234567890",
    "cuentaDestino": "0987654321",
    "observaciones": "Segundo pago parcial - Completa la transacción"
  }
]
```

### 4. GET /api/Pago/estado/{estado}
**Obtener pagos por estado**

**Parámetros de ruta:**
- `estado` (string): Estado del pago (Pendiente, Completado, Rechazado, Cancelado)

**Response (200 OK):**
```json
[
  {
    "id": 2,
    "transaccionId": 2,
    "monto": 25000.00,
    "moneda": "USD",
    "metodoPago": "Cheque",
    "referencia": "CHQ2024002",
    "fechaPago": "2024-01-16T14:20:00Z",
    "estado": "Pendiente",
    "bancoOrigen": "Bank of America",
    "bancoDestino": "Citibank",
    "cuentaOrigen": "9876543210",
    "cuentaDestino": "0123456789",
    "observaciones": "Cheque en proceso de compensación"
  }
]
```

### 5. POST /api/Pago
**Crear nuevo pago**

**Request Body:**
```json
{
  "transaccionId": 3,
  "monto": 75000.00,
  "moneda": "MXN",
  "metodoPago": "Efectivo",
  "referencia": "EFECT2024003",
  "fechaPago": "2024-01-17T09:15:00Z",
  "estado": "Completado",
  "bancoOrigen": null,
  "bancoDestino": null,
  "cuentaOrigen": null,
  "cuentaDestino": null,
  "observaciones": "Pago en efectivo recibido en ventanilla"
}
```

**Response (200 OK):**
```json
{
  "message": "Pago creado exitosamente"
}
```

### 6. PUT /api/Pago/{id}
**Actualizar pago**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Request Body:**
```json
{
  "transaccionId": 2,
  "monto": 25000.00,
  "moneda": "USD",
  "metodoPago": "Cheque",
  "referencia": "CHQ2024002",
  "fechaPago": "2024-01-16T14:20:00Z",
  "estado": "Completado",
  "bancoOrigen": "Bank of America",
  "bancoDestino": "Citibank",
  "cuentaOrigen": "9876543210",
  "cuentaDestino": "0123456789",
  "observaciones": "Cheque compensado exitosamente"
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

### 7. PUT /api/Pago/{id}/estado
**Actualizar estado del pago**

**Parámetros de ruta:**
- `id` (long): ID del pago

**Request Body:**
```json
{
  "estado": "Rechazado",
  "observaciones": "Cheque rechazado por fondos insuficientes"
}
```

**Response (200 OK):**
```json
{
  "message": "Estado del pago actualizado"
}
```

### 8. DELETE /api/Pago/{id}
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
  "transaccionId": "long",
  "monto": "decimal",
  "moneda": "string",
  "metodoPago": "string",
  "referencia": "string",
  "fechaPago": "datetime",
  "estado": "string",
  "bancoOrigen": "string?",
  "bancoDestino": "string?",
  "cuentaOrigen": "string?",
  "cuentaDestino": "string?",
  "observaciones": "string"
}
```

### CreatePagoDto
```json
{
  "transaccionId": "long",
  "monto": "decimal",
  "moneda": "string",
  "metodoPago": "string",
  "referencia": "string",
  "fechaPago": "datetime",
  "estado": "string",
  "bancoOrigen": "string?",
  "bancoDestino": "string?",
  "cuentaOrigen": "string?",
  "cuentaDestino": "string?",
  "observaciones": "string"
}
```

### UpdateEstadoPagoDto
```json
{
  "estado": "string",
  "observaciones": "string"
}
```