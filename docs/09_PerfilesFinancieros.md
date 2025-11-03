# Módulo PerfilFinanciero

## Descripción
Información financiera detallada de clientes para evaluación de riesgo y compliance.

## Endpoints

### 1. GET /api/PerfilesFinancieros/cliente/{clienteId}
**Obtener perfiles financieros por cliente**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nivelIngreso": "Alto",
    "fuente": "Estados Financieros Auditados"
  },
  {
    "id": 2,
    "nivelIngreso": "Medio",
    "fuente": "Declaración Fiscal"
  }
]
```

### 2. GET /api/PerfilesFinancieros/{id}
**Obtener perfil financiero específico**

**Parámetros de ruta:**
- `id` (long): ID del perfil financiero

**Response (200 OK):**
```json
{
  "id": 1,
  "nivelIngreso": "Alto",
  "fuente": "Estados Financieros Auditados"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Perfil financiero no encontrado"
}
```

### 3. POST /api/PerfilesFinancieros/cliente/{clienteId}
**Crear nuevo perfil financiero**

**Parámetros de ruta:**
- `clienteId` (long): ID del cliente

**Request Body:**
```json
{
  "nivelIngreso": "Bajo",
  "fuente": "Análisis Interno"
}
```

**Response (200 OK):**
```json
{
  "message": "Perfil financiero creado exitosamente"
}
```

### 4. PUT /api/PerfilesFinancieros/{id}
**Actualizar perfil financiero**

**Parámetros de ruta:**
- `id` (long): ID del perfil financiero

**Request Body:**
```json
{
  "nivelIngreso": "Medio",
  "fuente": "Análisis Interno Actualizado"
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

### 5. DELETE /api/PerfilesFinancieros/{id}
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
  "nivelIngreso": "string",
  "fuente": "string"
}
```

### CreatePerfilFinancieroDto
```json
{
  "nivelIngreso": "string",
  "fuente": "string"
}
```
