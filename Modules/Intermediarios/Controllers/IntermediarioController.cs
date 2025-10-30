using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.Services;

namespace ComplianceGuardPro.Modules.Intermediarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IntermediarioController : ControllerBase
    {
        private readonly IIntermediario _intermediarioService;

    public IntermediarioController(IIntermediario intermediarioService)
    {
        _intermediarioService = intermediarioService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerIntermediariosPorCliente(long clienteId)
    {
        var intermediarios = await _intermediarioService.obtenerIntermediariosPorCliente(clienteId);
        return Ok(intermediarios);
    }

    [HttpGet("{id}")]
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
