# Módulo Transaccion

## Descripción
Gestión de transacciones financieras realizadas por los clientes, incluyendo información detallada sobre instituciones financieras y formas de pago.

## Endpoints

### 1. GET /api/Transacciones/cliente/{clienteId}
**Obtener transacciones por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "tipo": "Depósito",
    "institucionFinanciera": "Banco Popular",
    "descripcion": "Depósito en cuenta corriente",
    "propositoProducto": "Compra de activos",
    "formaDeposito": "Transferencia bancaria",
    "formaExpectativa": "Efectivo",
    "clienteId": 1
  }
]
```

### 2. GET /api/Transacciones/{id}
**Obtener transacción específica**

**Parámetros de ruta:**
- `id` (long): ID de la transacción

**Response (200 OK):**
```json
{
  "id": 1,
  "tipo": "Depósito",
  "institucionFinanciera": "Banco Popular",
  "descripcion": "Depósito en cuenta corriente",
  "propositoProducto": "Compra de activos",
  "formaDeposito": "Transferencia bancaria",
  "formaExpectativa": "Efectivo",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Transacción no encontrada"
}
```

### 3. POST /api/Transacciones
**Crear nueva transacción**

**Request Body:**
```json
{
  "tipo": "Retiro",
  "institucionFinanciera": "Banco BHD",
  "descripcion": "Retiro para inversión",
  "propositoProducto": "Inversión en bolsa",
  "formaDeposito": "Cheque",
  "formaExpectativa": "Transferencia",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Transacción creada exitosamente"
}
```

### 4. PUT /api/Transacciones/{id}
**Actualizar transacción**

**Parámetros de ruta:**
- `id` (long): ID de la transacción

**Request Body:**
```json
{
  "tipo": "Transferencia",
  "institucionFinanciera": "Banco Scotiabank",
  "descripcion": "Transferencia internacional",
  "propositoProducto": "Pago de servicios",
  "formaDeposito": "Transferencia SWIFT",
  "formaExpectativa": "Transferencia",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Transacción actualizada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Transacción no encontrada"
}
```

### 5. DELETE /api/Transacciones/{id}
**Eliminar transacción**

**Parámetros de ruta:**
- `id` (long): ID de la transacción

**Response (200 OK):**
```json
{
  "message": "Transacción eliminada exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Transacción no encontrada"
}
```

## DTOs

### TransaccionDto
```json
{
  "id": "long",
  "tipo": "string",
  "institucionFinanciera": "string",
  "descripcion": "string",
  "propositoProducto": "string",
  "formaDeposito": "string",
  "formaExpectativa": "string",
  "clienteId": "long"
}
```

### CreateTransaccionDto
```json
{
  "tipo": "string",
  "institucionFinanciera": "string",
  "descripcion": "string",
  "propositoProducto": "string",
  "formaDeposito": "string",
  "formaExpectativa": "string",
  "clienteId": "long"
}
```
