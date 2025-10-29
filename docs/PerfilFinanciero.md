# Módulo PerfilFinanciero

## Descripción
Información financiera detallada de clientes para evaluación de riesgo y compliance.

## Endpoints

### 1. GET /api/PerfilFinanciero
**Obtener lista de perfiles financieros**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "ingresosAnuales": 2500000.00,
    "egresosAnuales": 1800000.00,
    "activos": 5000000.00,
    "pasivos": 2000000.00,
    "patrimonio": 3000000.00,
    "moneda": "MXN",
    "fechaEvaluacion": "2024-01-01T00:00:00Z",
    "fuenteInformacion": "Estados Financieros Auditados",
    "observaciones": "Empresa sólida con buen historial crediticio"
  },
  {
    "id": 2,
    "clienteId": 2,
    "ingresosAnuales": 850000.00,
    "egresosAnuales": 720000.00,
    "activos": 1500000.00,
    "pasivos": 800000.00,
    "patrimonio": 700000.00,
    "moneda": "MXN",
    "fechaEvaluacion": "2024-01-01T00:00:00Z",
    "fuenteInformacion": "Declaración Fiscal",
    "observaciones": "Perfil financiero conservador"
  }
]
```

### 2. GET /api/PerfilFinanciero/{id}
**Obtener perfil financiero específico**

**Parámetros de ruta:**
- `id` (long): ID del perfil financiero

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "ingresosAnuales": 2500000.00,
  "egresosAnuales": 1800000.00,
  "activos": 5000000.00,
  "pasivos": 2000000.00,
  "patrimonio": 3000000.00,
  "moneda": "MXN",
  "fechaEvaluacion": "2024-01-01T00:00:00Z",
  "fuenteInformacion": "Estados Financieros Auditados",
  "observaciones": "Empresa sólida con buen historial crediticio"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Perfil financiero no encontrado"
}
```

### 3. GET /api/PerfilFinanciero/cliente/{clienteId}
**Obtener perfil financiero por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
{
  "id": 1,
  "clienteId": 1,
  "ingresosAnuales": 2500000.00,
  "egresosAnuales": 1800000.00,
  "activos": 5000000.00,
  "pasivos": 2000000.00,
  "patrimonio": 3000000.00,
  "moneda": "MXN",
  "fechaEvaluacion": "2024-01-01T00:00:00Z",
  "fuenteInformacion": "Estados Financieros Auditados",
  "observaciones": "Empresa sólida con buen historial crediticio"
}
```

### 4. GET /api/PerfilFinanciero/cliente/{clienteId}/historial
**Obtener historial de perfiles financieros por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "clienteId": 1,
    "ingresosAnuales": 2200000.00,
    "egresosAnuales": 1700000.00,
    "activos": 4500000.00,
    "pasivos": 1800000.00,
    "patrimonio": 2700000.00,
    "moneda": "MXN",
    "fechaEvaluacion": "2023-01-01T00:00:00Z",
    "fuenteInformacion": "Estados Financieros 2023",
    "observaciones": "Crecimiento sostenido"
  },
  {
    "id": 3,
    "clienteId": 1,
    "ingresosAnuales": 2500000.00,
    "egresosAnuales": 1800000.00,
    "activos": 5000000.00,
    "pasivos": 2000000.00,
    "patrimonio": 3000000.00,
    "moneda": "MXN",
    "fechaEvaluacion": "2024-01-01T00:00:00Z",
    "fuenteInformacion": "Estados Financieros Auditados",
    "observaciones": "Empresa sólida con buen historial crediticio"
  }
]
```

### 5. POST /api/PerfilFinanciero
**Crear nuevo perfil financiero**

**Request Body:**
```json
{
  "clienteId": 3,
  "ingresosAnuales": 1200000.00,
  "egresosAnuales": 950000.00,
  "activos": 2000000.00,
  "pasivos": 1000000.00,
  "patrimonio": 1000000.00,
  "moneda": "MXN",
  "fechaEvaluacion": "2024-01-15T10:00:00Z",
  "fuenteInformacion": "Análisis Interno",
  "observaciones": "Cliente nuevo con potencial de crecimiento"
}
```

**Response (200 OK):**
```json
{
  "message": "Perfil financiero creado exitosamente"
}
```

### 6. PUT /api/PerfilFinanciero/{id}
**Actualizar perfil financiero**

**Parámetros de ruta:**
- `id` (long): ID del perfil financiero

**Request Body:**
```json
{
  "clienteId": 3,
  "ingresosAnuales": 1350000.00,
  "egresosAnuales": 1050000.00,
  "activos": 2200000.00,
  "pasivos": 1100000.00,
  "patrimonio": 1100000.00,
  "moneda": "MXN",
  "fechaEvaluacion": "2024-01-15T10:00:00Z",
  "fuenteInformacion": "Análisis Interno Actualizado",
  "observaciones": "Cliente nuevo con buen potencial de crecimiento"
}
```

**Response (200 OK):**
```json
{
  "message": "Perfil financiero actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Perfil financiero no encontrado"
}
```

### 7. DELETE /api/PerfilFinanciero/{id}
**Eliminar perfil financiero**

**Parámetros de ruta:**
- `id` (long): ID del perfil financiero

**Response (200 OK):**
```json
{
  "message": "Perfil financiero eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Perfil financiero no encontrado"
}
```

## DTOs

### PerfilFinancieroDto
```json
{
  "id": "long",
  "clienteId": "long",
  "ingresosAnuales": "decimal",
  "egresosAnuales": "decimal",
  "activos": "decimal",
  "pasivos": "decimal",
  "patrimonio": "decimal",
  "moneda": "string",
  "fechaEvaluacion": "datetime",
  "fuenteInformacion": "string",
  "observaciones": "string"
}
```

### CreatePerfilFinancieroDto
```json
{
  "clienteId": "long",
  "ingresosAnuales": "decimal",
  "egresosAnuales": "decimal",
  "activos": "decimal",
  "pasivos": "decimal",
  "patrimonio": "decimal",
  "moneda": "string",
  "fechaEvaluacion": "datetime",
  "fuenteInformacion": "string",
  "observaciones": "string"
}
```