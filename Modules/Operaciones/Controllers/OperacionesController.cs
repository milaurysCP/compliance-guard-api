using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Operaciones.DTOs;
using ComplianceGuardPro.Modules.Operaciones.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Operaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class OperacionesController : ControllerBase
{
    private readonly IOperacion _operacionService;

    public OperacionesController(IOperacion operacionService)
    {
        _operacionService = operacionService;
    }

    [HttpGet("cliente/{clienteId}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerOperacionesPorCliente(long clienteId)
    {
        var operaciones = await _operacionService.obtenerOperacionesPorCliente(clienteId);
        return Ok(operaciones);
    }

    [HttpGet("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerOperacion(long id)
    {
        var operacion = await _operacionService.obtenerOperacion(id);
        if (operacion == null)
        {
            return NotFound(new { message = "Operación no encontrada" });
        }
        return Ok(operacion);
    }

    [HttpPost]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> CrearOperacion([FromBody] CreateOperacionDto crearOperacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _operacionService.crearOperacion(crearOperacionDto);
        return Ok(new { message = "Operación creada exitosamente" });
    }

    [HttpPut("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ActualizarOperacion(long id, [FromBody] CreateOperacionDto actualizarOperacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _operacionService.actualizarOperacion(id, actualizarOperacionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Operación no encontrada" });
        }

        return Ok(new { message = "Operación actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
    public async Task<IActionResult> EliminarOperacion(long id)
    {
        var resultado = await _operacionService.eliminarOperacion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Operación no encontrada" });
        }

        return Ok(new { message = "Operación eliminada exitosamente" });
    }
}}
