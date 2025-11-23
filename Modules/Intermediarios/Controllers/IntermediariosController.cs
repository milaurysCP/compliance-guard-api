using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Intermediarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class IntermediariosController : ControllerBase
    {
        private readonly IIntermediario _intermediarioService;

    public IntermediariosController(IIntermediario intermediarioService)
    {
        _intermediarioService = intermediarioService;
    }

    [HttpGet("cliente/{clienteId}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerIntermediariosPorCliente(long clienteId)
    {
        var intermediarios = await _intermediarioService.obtenerIntermediariosPorCliente(clienteId);
        return Ok(intermediarios);
    }

    [HttpGet("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerIntermediario(long id)
    {
        var intermediario = await _intermediarioService.obtenerIntermediario(id);
        if (intermediario == null)
        {
            return NotFound(new { message = "Intermediario no encontrado" });
        }
        return Ok(intermediario);
    }

    [HttpPost]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> CrearIntermediario([FromBody] CreateIntermediarioDto crearIntermediarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _intermediarioService.crearIntermediario(crearIntermediarioDto);
        return Ok(new { message = "Intermediario creado exitosamente" });
    }

    [HttpPut("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ActualizarIntermediario(long id, [FromBody] CreateIntermediarioDto actualizarIntermediarioDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _intermediarioService.actualizarIntermediario(id, actualizarIntermediarioDto);
        if (!resultado)
        {
            return NotFound(new { message = "Intermediario no encontrado" });
        }

        return Ok(new { message = "Intermediario actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
    public async Task<IActionResult> EliminarIntermediario(long id)
    {
        var resultado = await _intermediarioService.eliminarIntermediario(id);
        if (!resultado)
        {
            return NotFound(new { message = "Intermediario no encontrado" });
        }
        return Ok(new { message = "Intermediario eliminado exitosamente" });
    }
}
}
