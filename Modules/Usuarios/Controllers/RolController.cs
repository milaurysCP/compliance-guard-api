using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Usuarios.DTOs;
using ComplianceGuardPro.Modules.Usuarios.Services;

namespace ComplianceGuardPro.Modules.Usuarios.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RolController : ControllerBase
{
    private readonly IRol _rolService;

    public RolController(IRol rolService)
    {
        _rolService = rolService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerRoles()
    {
        try
        {
            var roles = await _rolService.obtenerRoles();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerRol(long id)
    {
        try
        {
            var rol = await _rolService.obtenerRol(id);
            if (rol == null)
            {
                return NotFound(new { message = "Rol no encontrado" });
            }
            return Ok(rol);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CrearRol([FromBody] CreateRolDto createRolDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _rolService.crearRol(createRolDto);
            return CreatedAtAction(nameof(ObtenerRol), new { id = 0 }, createRolDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarRol(long id, [FromBody] CreateRolDto updateRolDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _rolService.actualizarRol(id, updateRolDto);
            if (!result)
            {
                return NotFound(new { message = "Rol no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarRol(long id)
    {
        try
        {
            var result = await _rolService.eliminarRol(id);
            if (!result)
            {
                return NotFound(new { message = "Rol no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}