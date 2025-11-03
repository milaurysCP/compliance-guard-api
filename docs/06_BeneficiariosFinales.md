# Módulo BeneficiarioFinal

## Descripción
Gestión de beneficiarios finales asociados a los clientes para cumplimiento normativo.

## Endpoints

### 1. GET /api/BeneficiariosFinales/cliente/{clienteId}
**Obtener beneficiarios finales por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "María González",
    "clienteId": 1
  },
  {
    "id": 2,
    "nombre": "Carlos Rodríguez",
    "clienteId": 1
  }
]
```

### 2. GET /api/BeneficiariosFinales/{id}
**Obtener beneficiario final específico**

**Parámetros de ruta:**
- `id` (long): ID del beneficiario final

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "María González",
  "clienteId": 1
}
```

**Response (404 Not Found):**
```json
{
  "message": "Beneficiario final no encontrado"
}
```

### 3. POST /api/BeneficiariosFinales
**Crear nuevo beneficiario final**

**Request Body:**
```json
{
  "nombre": "Ana Martínez",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Beneficiario final creado exitosamente"
}
```

### 4. PUT /api/BeneficiariosFinales/{id}
**Actualizar beneficiario final**

**Parámetros de ruta:**
- `id` (long): ID del beneficiario final

**Request Body:**
```json
{
  "nombre": "Ana Martínez López",
  "clienteId": 1
}
```

**Response (200 OK):**
```json
{
  "message": "Beneficiario final actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Beneficiario final no encontrado"
}
```

### 5. DELETE /api/BeneficiariosFinales/{id}
**Eliminar beneficiario final**

**Parámetros de ruta:**
- `id` (long): ID del beneficiario final

**Response (200 OK):**
```json
{
  "message": "Beneficiario final eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Beneficiario final no encontrado"
}
```

## DTOs

### BeneficiarioFinalDto
```json
{
  "id": "long",
  "nombre": "string",
  "clienteId": "long"
}
```

### CreateBeneficiarioFinalDto
```json
{
  "nombre": "string",
  "clienteId": "long"
}
```
