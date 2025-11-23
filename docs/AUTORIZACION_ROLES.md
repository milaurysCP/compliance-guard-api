# Sistema de Autorización por Roles - ComplianceGuardPro API

## 📋 Descripción General

El sistema de autorización basado en roles protege todas las rutas de la API según el rol del usuario autenticado. Aunque la autenticación está temporalmente deshabilitada, la infraestructura de roles está completamente implementada y lista para activarse.

## 👥 Roles Definidos

El sistema maneja **4 roles principales**:

| Rol | Puede Leer | Puede Crear | Puede Actualizar | Puede Eliminar |
|-----|------------|-------------|------------------|----------------|
| **OFICIAL_CUMPLIMIENTO** | ✅ | ✅ | ✅ | ✅ |
| **ANALISTA** | ✅ | ✅ | ✅ | ❌ |
| **TECNICO** | ✅ | ✅ | ✅ | ❌ |
| **OFICIAL_SUPLENTE** | ✅ | ✅ | ✅ | ❌ |

### Características Principales:

- ✅ **Todos los roles** pueden: Leer, Crear y Actualizar
- ❌ **Solo OFICIAL_CUMPLIMIENTO** puede: Eliminar registros

## 🏗️ Arquitectura Implementada

### 1. Enum de Roles (`UserRole.cs`)
```csharp
public enum UserRole
{
    OFICIAL_CUMPLIMIENTO,
    ANALISTA,
    TECNICO,
    OFICIAL_SUPLENTE
}
```

### 2. Constantes de Roles (`Roles.cs`)
```csharp
public static class Roles
{
    public const string OFICIAL_CUMPLIMIENTO = "OFICIAL_CUMPLIMIENTO";
    public const string ANALISTA = "ANALISTA";
    public const string TECNICO = "TECNICO";
    public const string OFICIAL_SUPLENTE = "OFICIAL_SUPLENTE";
}
```

### 3. Atributo de Autorización (`RoleAuthorizeAttribute.cs`)

Filtro de autorización personalizado que:
- Valida si el usuario está autenticado
- Extrae el rol del claim `"role"` del JWT
- Verifica si el rol está en la lista de roles permitidos
- Retorna `403 Forbidden` si no tiene permisos
- Retorna `401 Unauthorized` si no está autenticado

## 🔐 Implementación en Controladores

### Operaciones de Lectura (GET)
Todos los roles tienen acceso:
```csharp
[HttpGet]
[RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
public async Task<IActionResult> ObtenerTodos()
```

### Operaciones de Creación (POST)
Todos los roles tienen acceso:
```csharp
[HttpPost]
[RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
public async Task<IActionResult> Crear([FromBody] CreateDto dto)
```

### Operaciones de Actualización (PUT)
Todos los roles tienen acceso:
```csharp
[HttpPut("{id}")]
[RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
public async Task<IActionResult> Actualizar(long id, [FromBody] UpdateDto dto)
```

### Operaciones de Eliminación (DELETE)
**Solo OFICIAL_CUMPLIMIENTO**:
```csharp
[HttpDelete("{id}")]
[RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
public async Task<IActionResult> Eliminar(long id)
```

## 📝 Controladores Protegidos

Se han aplicado los atributos de autorización a **todos** los controladores del sistema:

### Módulos de Cliente
- ✅ `ClientesController`
- ✅ `ContactosController`
- ✅ `DireccionesController`
- ✅ `BeneficiariosFinalesController`
- ✅ `ActividadesEconomicasController`
- ✅ `IntermediariosController`
- ✅ `PerfilesFinancierosController`
- ✅ `CatalogosController`

### Módulos de Operaciones
- ✅ `OperacionesController`
- ✅ `PagosController`
- ✅ `TransaccionesController`

### Módulos de Riesgo y Cumplimiento
- ✅ `RiesgosController`
- ✅ `EvaluacionesController`
- ✅ `DebidaDiligenciaController`
- ✅ `MitigacionController`

### Módulos de Información
- ✅ `PersonasExpuestasPoliticamenteController`
- ✅ `ResponsablesController`
- ✅ `ReferenciasController`

### Módulos de Sistema
- ✅ `UsuariosController`
- ✅ `RolController`
- ✅ `DocumentosController`
- ✅ `ReportesController`
- ✅ `MensajesChatController`
- ✅ `FaqController`
- ✅ `CapacitacionesController`
- ✅ `PoliticasController`

## 🔑 Estructura del JWT

Para que la autorización funcione correctamente, el token JWT debe incluir el claim de rol:

```json
{
  "id": "123",
  "name": "Juan Pérez",
  "role": "OFICIAL_CUMPLIMIENTO",
  "exp": 1718749200
}
```

### Ejemplo de Generación del Token (En UsuariosService)

```csharp
var claims = new[]
{
    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
    new Claim(ClaimTypes.Name, usuario.Nombre),
    new Claim("role", usuario.Rol.Nombre), // ⬅️ IMPORTANTE: Claim de rol
    new Claim(ClaimTypes.Email, usuario.Email)
};
```

## ⚙️ Activación del Sistema

Actualmente la protección está **LISTA PERO DESHABILITADA**. Para activarla:

### 1. Habilitar Autenticación en `Program.cs`

Descomentar las líneas de configuración de JWT:
```csharp
// Agregar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// En el pipeline
app.UseAuthentication();
app.UseAuthorization();
```

### 2. No se Requiere Más Configuración

Los atributos `[RoleAuthorize]` ya están aplicados en todos los controladores y comenzarán a funcionar automáticamente al habilitar la autenticación.

## 📊 Respuestas de Error

### 401 Unauthorized (No Autenticado)
```json
{
  "message": "Usuario no autenticado",
  "error": "UNAUTHORIZED"
}
```

### 401 Unauthorized (Sin Rol en Token)
```json
{
  "message": "No se encontró el rol del usuario en el token",
  "error": "MISSING_ROLE"
}
```

### 403 Forbidden (Sin Permisos)
```json
{
  "message": "No tiene permisos suficientes. Se requiere uno de los siguientes roles: OFICIAL_CUMPLIMIENTO",
  "error": "FORBIDDEN",
  "userRole": "ANALISTA",
  "requiredRoles": ["OFICIAL_CUMPLIMIENTO"]
}
```

## 🔒 Excepciones de Rutas Públicas

Las siguientes rutas **NO requieren autenticación**:

- `POST /api/Usuarios/login` - Inicio de sesión
- `POST /api/Usuarios/register` - Registro de usuario

Estas rutas no tienen el atributo `[RoleAuthorize]` aplicado.

## 🎯 Ejemplos de Uso

### Ejemplo 1: Usuario Analista intenta eliminar
```http
DELETE /api/Clientes/123
Authorization: Bearer eyJhbGc...

Respuesta: 403 Forbidden
{
  "message": "No tiene permisos suficientes...",
  "userRole": "ANALISTA",
  "requiredRoles": ["OFICIAL_CUMPLIMIENTO"]
}
```

### Ejemplo 2: Oficial de Cumplimiento elimina
```http
DELETE /api/Clientes/123
Authorization: Bearer eyJhbGc...

Respuesta: 200 OK
{
  "message": "Cliente eliminado exitosamente"
}
```

### Ejemplo 3: Cualquier rol consulta datos
```http
GET /api/Clientes
Authorization: Bearer eyJhbGc...

Respuesta: 200 OK
[...lista de clientes...]
```

## 📁 Estructura de Archivos

```
Shared/
└── Authorization/
    ├── UserRole.cs              # Enum de roles
    ├── Roles.cs                 # Constantes de roles
    └── RoleAuthorizeAttribute.cs # Filtro de autorización
```

## ✅ Checklist de Implementación

- [x] Crear enum `UserRole` con los 4 roles
- [x] Crear clase `Roles` con constantes
- [x] Implementar `RoleAuthorizeAttribute`
- [x] Aplicar autorización a ClientesController
- [x] Aplicar autorización a UsuariosController  
- [x] Aplicar autorización a ContactosController
- [x] Aplicar autorización a BeneficiariosFinalesController
- [x] Aplicar autorización a DireccionesController
- [x] Aplicar autorización a ActividadesEconomicasController
- [x] Aplicar autorización a IntermediariosController
- [x] Aplicar autorización a PerfilesFinancierosController
- [x] Aplicar autorización a OperacionesController
- [x] Aplicar autorización a PagosController
- [x] Aplicar autorización a TransaccionesController
- [x] Aplicar autorización a RiesgosController
- [x] Aplicar autorización a EvaluacionesController
- [x] Aplicar autorización a MensajesChatController
- [x] Aplicar autorización a DebidaDiligenciaController
- [x] Aplicar autorización a PersonasExpuestasPoliticamenteController
- [x] Aplicar autorización a DocumentosController
- [x] Aplicar autorización a ReportesController
- [x] Aplicar autorización a ResponsablesController
- [x] Aplicar autorización a ReferenciasController
- [x] Aplicar autorización a PoliticasController
- [x] Aplicar autorización a MitigacionController
- [x] Aplicar autorización a FaqController
- [x] Aplicar autorización a CapacitacionesController
- [x] Aplicar autorización a CatalogosController
- [x] Aplicar autorización a RolController
- [ ] Habilitar autenticación JWT en Program.cs (cuando se requiera)

## 🚀 Próximos Pasos

1. **Configurar JWT**: Agregar configuración de JWT en `appsettings.json`
2. **Habilitar Autenticación**: Descomentar código en `Program.cs`
3. **Actualizar Servicio de Login**: Asegurar que el JWT incluya el claim `"role"`
4. **Testing**: Probar con diferentes roles
5. **Documentación Swagger**: Agregar información de seguridad en Swagger

---

**Fecha de Implementación**: 23 de Noviembre, 2025  
**Estado**: ✅ Completado - Listo para activación
