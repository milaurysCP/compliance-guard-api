# Módulo MensajeChat

## Descripción
Sistema de mensajería interna para comunicación entre usuarios del sistema de compliance.

## Endpoints

### 1. GET /api/MensajeChat
**Obtener lista de mensajes**

**Parámetros de consulta opcionales:**
- `usuarioId` (long): Filtrar por usuario remitente o destinatario
- `limit` (int): Número máximo de mensajes (default: 50)
- `offset` (int): Desplazamiento para paginación (default: 0)

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "remitenteId": 1,
    "destinatarioId": 2,
    "mensaje": "Por favor revisar la evaluación del cliente ABC Corp",
    "fechaEnvio": "2024-01-15T10:30:00Z",
    "leido": false,
    "tipoMensaje": "Notificación",
    "prioridad": "Media"
  },
  {
    "id": 2,
    "remitenteId": 2,
    "destinatarioId": 1,
    "mensaje": "Evaluación revisada. Requiere documentación adicional",
    "fechaEnvio": "2024-01-15T11:00:00Z",
    "leido": true,
    "tipoMensaje": "Respuesta",
    "prioridad": "Alta"
  }
]
```

### 2. GET /api/MensajeChat/{id}
**Obtener mensaje específico**

**Parámetros de ruta:**
- `id` (long): ID del mensaje

**Response (200 OK):**
```json
{
  "id": 1,
  "remitenteId": 1,
  "destinatarioId": 2,
  "mensaje": "Por favor revisar la evaluación del cliente ABC Corp",
  "fechaEnvio": "2024-01-15T10:30:00Z",
  "leido": false,
  "tipoMensaje": "Notificación",
  "prioridad": "Media"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Mensaje no encontrado"
}
```

### 3. GET /api/MensajeChat/conversacion/{usuarioId1}/{usuarioId2}
**Obtener conversación entre dos usuarios**

**Parámetros de ruta:**
- `usuarioId1` (long): ID del primer usuario
- `usuarioId2` (long): ID del segundo usuario

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "remitenteId": 1,
    "destinatarioId": 2,
    "mensaje": "Hola, necesito consultar sobre el cliente XYZ",
    "fechaEnvio": "2024-01-15T09:00:00Z",
    "leido": true,
    "tipoMensaje": "Consulta",
    "prioridad": "Baja"
  },
  {
    "id": 2,
    "remitenteId": 2,
    "destinatarioId": 1,
    "mensaje": "Claro, ¿qué necesitas saber?",
    "fechaEnvio": "2024-01-15T09:05:00Z",
    "leido": true,
    "tipoMensaje": "Respuesta",
    "prioridad": "Baja"
  },
  {
    "id": 3,
    "remitenteId": 1,
    "destinatarioId": 2,
    "mensaje": "Me urge la información del perfil financiero",
    "fechaEnvio": "2024-01-15T09:10:00Z",
    "leido": false,
    "tipoMensaje": "Urgente",
    "prioridad": "Alta"
  }
]
```

### 4. GET /api/MensajeChat/no-leidos/{usuarioId}
**Obtener mensajes no leídos de un usuario**

**Parámetros de ruta:**
- `usuarioId` (long): ID del usuario destinatario

**Response (200 OK):**
```json
[
  {
    "id": 3,
    "remitenteId": 1,
    "destinatarioId": 2,
    "mensaje": "Me urge la información del perfil financiero",
    "fechaEnvio": "2024-01-15T09:10:00Z",
    "leido": false,
    "tipoMensaje": "Urgente",
    "prioridad": "Alta"
  },
  {
    "id": 5,
    "remitenteId": 3,
    "destinatarioId": 2,
    "mensaje": "Actualización del riesgo del cliente",
    "fechaEnvio": "2024-01-15T14:20:00Z",
    "leido": false,
    "tipoMensaje": "Notificación",
    "prioridad": "Media"
  }
]
```

### 5. POST /api/MensajeChat
**Enviar nuevo mensaje**

**Request Body:**
```json
{
  "remitenteId": 1,
  "destinatarioId": 2,
  "mensaje": "Se requiere aprobación para la transacción de alto riesgo",
  "tipoMensaje": "Aprobación",
  "prioridad": "Alta"
}
```

**Response (200 OK):**
```json
{
  "message": "Mensaje enviado exitosamente",
  "mensajeId": 6
}
```

### 6. PUT /api/MensajeChat/{id}/marcar-leido
**Marcar mensaje como leído**

**Parámetros de ruta:**
- `id` (long): ID del mensaje

**Response (200 OK):**
```json
{
  "message": "Mensaje marcado como leído"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Mensaje no encontrado"
}
```

### 7. PUT /api/MensajeChat/marcar-todos-leidos/{usuarioId}
**Marcar todos los mensajes como leídos para un usuario**

**Parámetros de ruta:**
- `usuarioId` (long): ID del usuario destinatario

**Response (200 OK):**
```json
{
  "message": "Todos los mensajes marcados como leídos",
  "mensajesActualizados": 5
}
```

### 8. DELETE /api/MensajeChat/{id}
**Eliminar mensaje**

**Parámetros de ruta:**
- `id` (long): ID del mensaje

**Response (200 OK):**
```json
{
  "message": "Mensaje eliminado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Mensaje no encontrado"
}
```

## DTOs

### MensajeChatDto
```json
{
  "id": "long",
  "remitenteId": "long",
  "destinatarioId": "long",
  "mensaje": "string",
  "fechaEnvio": "datetime",
  "leido": "bool",
  "tipoMensaje": "string",
  "prioridad": "string"
}
```

### CreateMensajeChatDto
```json
{
  "remitenteId": "long",
  "destinatarioId": "long",
  "mensaje": "string",
  "tipoMensaje": "string",
  "prioridad": "string"
}
```

### MensajeLeidoResponseDto
```json
{
  "message": "string",
  "mensajesActualizados": "int"
}
```