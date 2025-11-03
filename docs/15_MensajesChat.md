# Módulo MensajeChat

## Descripción
Sistema de mensajería interna para comunicación entre usuarios del sistema de compliance.

## Endpoints

### 1. GET /api/MensajesChat
**Obtener lista de mensajes**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "mensaje": "Por favor revisar la evaluación del cliente ABC Corp",
    "fechaEnvio": "2024-01-15T10:30:00Z",
    "usuarioNombre": "Juan Pérez"
  },
  {
    "id": 2,
    "usuarioId": 2,
    "mensaje": "Evaluación revisada. Requiere documentación adicional",
    "fechaEnvio": "2024-01-15T11:00:00Z",
    "usuarioNombre": "María González"
  }
]
```

### 2. GET /api/MensajesChat/usuario/{usuarioId}
**Obtener mensajes por usuario**

**Parámetros de ruta:**
- `usuarioId` (long): ID del usuario

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "mensaje": "Mensaje de prueba",
    "fechaEnvio": "2024-01-15T10:30:00Z",
    "usuarioNombre": "Juan Pérez"
  }
]
```

### 3. GET /api/MensajesChat/{id}
**Obtener mensaje específico**

**Parámetros de ruta:**
- `id` (long): ID del mensaje

**Response (200 OK):**
```json
{
  "id": 1,
  "usuarioId": 1,
  "mensaje": "Por favor revisar la evaluación del cliente ABC Corp",
  "fechaEnvio": "2024-01-15T10:30:00Z",
  "usuarioNombre": "Juan Pérez"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Mensaje no encontrado"
}
```

### 4. POST /api/MensajesChat
**Crear nuevo mensaje**

**Request Body:**
```json
{
  "usuarioId": 1,
  "mensaje": "Se requiere aprobación para la transacción de alto riesgo",
  "fechaEnvio": "2024-01-15T14:00:00Z"
}
```

**Response (201 Created):**
```json
{
  "usuarioId": 1,
  "mensaje": "Se requiere aprobación para la transacción de alto riesgo",
  "fechaEnvio": "2024-01-15T14:00:00Z"
}
```

## DTOs

### MensajeChatDto
```json
{
  "id": "long",
  "usuarioId": "long",
  "mensaje": "string",
  "fechaEnvio": "datetime",
  "usuarioNombre": "string"
}
```

### CreateMensajeChatDto
```json
{
  "usuarioId": "long",
  "mensaje": "string",
  "fechaEnvio": "datetime"
}
```
