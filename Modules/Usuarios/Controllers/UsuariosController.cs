
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComplianceGuardPro.Modules.Usuarios.DTOs;
using ComplianceGuardPro.Modules.Usuarios.Services;

namespace ComplianceGuardPro.Modules.Usuarios.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly Iusuario _usuarioService;

    public UsuariosController(Iusuario usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var loginResponse = await _usuarioService.autenticarUsuario(loginDto);
        if (loginResponse == null)
        {
            return Unauthorized(new { message = "Credenciales inválidas" });
        }

        return Ok(loginResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> CrearUsuario([FromBody] CreateUsuarioDto crearUsuarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _usuarioService.crearUsuario(crearUsuarioDto);
        return Ok(new { message = "Usuario creado exitosamente" });
    }

    [HttpGet("{id}")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> ObtenerDetalleUsuario(long id)
    {
        var detalleUsuario = await _usuarioService.obtenerDetalleUsuario(id);
        if (detalleUsuario == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }
        return Ok(detalleUsuario);
    }

    [HttpGet]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> ObtenerUsuarios()
    {
        var usuarios = await _usuarioService.obtenerUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("perfil")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> ObtenerPerfilUsuario()
    {
        // Obtener el ID del usuario desde el token JWT
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out var userId))
        {
            return Unauthorized(new { message = "Token inválido o usuario no autenticado" });
        }

        var perfilUsuario = await _usuarioService.obtenerDetalleUsuario(userId);
        if (perfilUsuario == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(perfilUsuario);
    }

    [HttpPut("{id}")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> ActualizarUsuario(long id, [FromBody] UpdateUsuarioDto actualizarUsuarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _usuarioService.actualizarUsuario(id, actualizarUsuarioDto);
        if (!resultado)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(new { message = "Usuario actualizado exitosamente" });
    }

    [HttpPut("{id}/password")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> ActualizarClave(long id, [FromBody] UpdatePasswordDto updatePasswordDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _usuarioService.actualizarClave(id, updatePasswordDto);
        if (!resultado)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(new { message = "Contraseña actualizada exitosamente" });
    }

    [HttpPut("{id}/status")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> CambiarEstado(long id, [FromBody] CambiarEstadoDto cambiarEstadoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _usuarioService.cambiarEstado(id, cambiarEstadoDto);
        if (!resultado)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(new { message = "Estado del usuario actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    // [Authorize] // Deshabilitado temporalmente
    public async Task<IActionResult> EliminarUsuario(long id)
    {
        var resultado = await _usuarioService.eliminarUsuario(id);
        if (!resultado)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(new { message = "Usuario eliminado exitosamente" });
    }
}
