
using Microsoft.AspNetCore.Mvc;
using ComplianceGuardPro.Modules.Usuarios.DTOs;
using ComplianceGuardPro.Modules.Usuarios.Services;

namespace ComplianceGuardPro.Modules.Usuarios.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly Iusuario _usuarioService;

    public UsuarioController(Iusuario usuarioService)
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

    [HttpPost("registrar")]
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
    public async Task<IActionResult> ObtenerDetalleUsuario(long id)
    {
        var detalleUsuario = await _usuarioService.obtenerDetalleUsuario(id);
        if (detalleUsuario == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }
        return Ok(detalleUsuario);
    }
}