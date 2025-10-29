# Módulo Usuario

## Descripción
Gestión de usuarios del sistema, incluyendo autenticación, registro y consulta de detalles.

## Endpoints

### 1. POST /api/Usuario/login
**Autenticar usuario**

**Request Body:**
```json
{
  "usuarioLogin": "admin",
  "clave": "password123"
}
```

**Response (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "usuario": {
    "id": 1,
    "usuarioLogin": "admin",
    "rolId": 1,
    "nombreRol": "Administrador",
    "estaActivo": true
  }
}
```

**Response (401 Unauthorized):**
```json
{
  "message": "Credenciales inválidas"
}
```

### 2. POST /api/Usuario/registrar
**Crear nuevo usuario**

**Request Body:**
```json
{
  "usuarioLogin": "nuevo_usuario",
  "clave": "password123",
  "rolId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Usuario creado exitosamente"
}
```

### 3. GET /api/Usuario/{id}
**Obtener detalle de usuario**

**Parámetros de ruta:**
- `id` (long): ID del usuario

**Response (200 OK):**
```json
{
  "id": 1,
  "usuarioLogin": "admin",
  "rolId": 1,
  "nombreRol": "Administrador",
  "estaActivo": true,
  "mensajeChat": []
}
```

**Response (404 Not Found):**
```json
{
  "message": "Usuario no encontrado"
}
```

## DTOs

### LoginDto
```json
{
  "usuarioLogin": "string",
  "clave": "string"
}
```

### CreateUsuarioDto
```json
{
  "usuarioLogin": "string",
  "clave": "string (mínimo 8 caracteres)",
  "rolId": "long"
}
```

### UsuarioDto
```json
{
  "id": "long",
  "usuarioLogin": "string",
  "rolId": "long",
  "nombreRol": "string",
  "estaActivo": "boolean"
}
```

### LoginResponseDto
```json
{
  "token": "string",
  "usuario": "UsuarioDto"
}
```

### DetalleUsuarioDto
```json
{
  "id": "long",
  "usuarioLogin": "string",
  "rolId": "long",
  "nombreRol": "string",
  "estaActivo": "boolean",
  "mensajeChat": "MensajeChatDto[]"
}
```