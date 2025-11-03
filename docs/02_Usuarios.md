# Módulo Usuario

## Descripción
Gestión de usuarios del sistema, incluyendo autenticación, registro y consulta de detalles.

## Endpoints

### 1. POST /api/Usuarios/login
**Autenticar usuario**

**Request Body:**
```json
{
  "usuarioLogin": "admin",
  "clave": "12345678"
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

### 2. POST /api/Usuarios/register
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

### 3. GET /api/Usuarios
**Obtener lista de usuarios**

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioLogin": "admin",
    "rolId": 1,
    "nombreRol": "Administrador",
    "estaActivo": true
  }
]
```

### 4. GET /api/Usuarios/{id}
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

### 5. GET /api/Usuarios/perfil
**Obtener perfil del usuario actual**

**Response (200 OK):**
```json
{
  "message": "Perfil del usuario actual"
}
```

### 6. PUT /api/Usuarios/{id}
**Actualizar usuario**

**Parámetros de ruta:**
- `id` (long): ID del usuario

**Request Body:**
```json
{
  "rolId": 2
}
```

**Response (200 OK):**
```json
{
  "message": "Usuario actualizado exitosamente"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Usuario no encontrado"
}
```

### 7. DELETE /api/Usuarios/{id}
**Eliminar usuario**

**Parámetros de ruta:**
- `id` (long): ID del usuario

**Response (200 OK):**
```json
{
  "message": "Usuario eliminado exitosamente"
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

### UpdateUsuarioDto
```json
{
  "rolId": "long"
}
```

### UpdatePasswordDto
```json
{
  "nuevaClave": "string (mínimo 8 caracteres)"
}
```

### CambiarEstadoDto
```json
{
  "estaActivo": "boolean"
}
```