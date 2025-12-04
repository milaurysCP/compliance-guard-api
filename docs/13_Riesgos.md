# Módulo Riesgos

## Descripción
Gestión de riesgos identificados en el sistema de compliance. El módulo permite clasificar y cuantificar riesgos mediante frecuencia, nivel e impacto.

## Endpoints

### 1. GET /api/Riesgos
**Obtener lista de riesgos**

**Autorización:** Oficial de Cumplimiento, Analista, Técnico, Oficial Suplente

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Lavado de Activos",
    "frecuencia": 3,
    "nivel": "Alto",
    "impacto": 5
  },
  {
    "id": 2,
    "nombre": "Financiamiento del Terrorismo",
    "frecuencia": 2,
    "nivel": "Medio",
    "impacto": 4
  }
]
```

### 2. GET /api/Riesgos/{id}
**Obtener riesgo específico**

**Autorización:** Oficial de Cumplimiento, Analista, Técnico, Oficial Suplente

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Response (200 OK):**
```json
{
  "id": 1,
  "nombre": "Lavado de Activos",
  "frecuencia": 3,
  "nivel": "Alto",
  "impacto": 5
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado"
}
```

### 3. POST /api/Riesgos
**Crear nuevo riesgo**

**Autorización:** Oficial de Cumplimiento, Analista, Técnico, Oficial Suplente

**Request Body:**
```json
{
  "nombre": "Corrupción",
  "frecuencia": 2,
  "nivel": "Medio",
  "impacto": 3
}
```

**Response (200 OK):**
```json
{
  "message": "Riesgo creado exitosamente"
}
```

**Response (400 Bad Request):**
```json
{
  "errors": {
    "nombre": ["El nombre es requerido"]
  }
}
```

### 4. PUT /api/Riesgos/{id}
**Actualizar riesgo**

**Autorización:** Oficial de Cumplimiento, Analista, Técnico, Oficial Suplente

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Request Body:**
```json
{
  "nombre": "Corrupción y Soborno",
  "frecuencia": 3,
  "nivel": "Alto",
  "impacto": 4
}
```

**Response (200 OK):**
```json
{
  "message": "Riesgo actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado"
}
```

**Response (400 Bad Request):**
```json
{
  "errors": {
    "nombre": ["El nombre no puede exceder 200 caracteres"]
  }
}
```

### 5. DELETE /api/Riesgos/{id}
**Eliminar riesgo**

**Autorización:** Oficial de Cumplimiento

**Parámetros de ruta:**
- `id` (long): ID del riesgo

**Response (200 OK):**
```json
{
  "message": "Riesgo eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Riesgo no encontrado o tiene evaluaciones asociadas"
}
```

## DTOs

### RiesgoDto
```json
{
  "id": "long",
  "nombre": "string (max 200)",
  "frecuencia": "int? (nullable)",
  "nivel": "string? (max 50, nullable)",
  "impacto": "int? (nullable)"
}
```

### CreateRiesgoDto
```json
{
  "nombre": "string? (max 200)",
  "frecuencia": "int? (nullable)",
  "nivel": "string? (max 50, nullable)",
  "impacto": "int? (nullable)"
}
```

## Modelo de Datos

### Propiedades
- **Id**: Identificador único del riesgo
- **Nombre**: Nombre descriptivo del riesgo (máximo 200 caracteres)
- **Frecuencia**: Valor numérico que indica la frecuencia de ocurrencia del riesgo
- **Nivel**: Clasificación del nivel de riesgo (ej: "Alto", "Medio", "Bajo") - máximo 50 caracteres
- **Impacto**: Valor numérico que indica el impacto potencial del riesgo

## Notas
- Solo el Oficial de Cumplimiento puede eliminar riesgos
- No se puede eliminar un riesgo si tiene evaluaciones asociadas
- Todos los campos son opcionales excepto el ID
- Los valores de frecuencia e impacto son numéricos y pueden usarse para cálculos de riesgo
- El nivel es un campo de texto libre para clasificación cualitativa
