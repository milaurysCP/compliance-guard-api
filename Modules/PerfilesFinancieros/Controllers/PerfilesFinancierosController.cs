using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Services;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PerfilesFinancierosController : ControllerBase
{
    private readonly IPerfilFinanciero _perfilService;

    public PerfilesFinancierosController(IPerfilFinanciero perfilService)
    {
        _perfilService = perfilService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerPerfilesPorCliente(long clienteId)
    {
        var perfiles = await _perfilService.obtenerPerfilesPorCliente(clienteId);
        return Ok(perfiles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPerfilFinanciero(long id)
    {
        var perfil = await _perfilService.obtenerPerfilFinanciero(id);
        if (perfil == null)
        {
            return NotFound(new { message = "Perfil financiero no encontrado" });
        }
        return Ok(perfil);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPerfilFinanciero([FromBody] CreatePerfilFinancieroDto crearPerfilDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _perfilService.crearPerfilFinanciero(crearPerfilDto);
        return Ok(new { message = "Perfil financiero creado exitosamente" });
    }

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearPerfilFinancieroPorCliente(long clienteId, [FromBody] CreatePerfilFinancieroDto crearPerfilDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Override ClienteId from URL if provided in body
        crearPerfilDto.ClienteId = clienteId;
        await _perfilService.crearPerfilFinanciero(crearPerfilDto);
        return Ok(new { message = "Perfil financiero creado exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarPerfilFinanciero(long id, [FromBody] CreatePerfilFinancieroDto actualizarPerfilDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _perfilService.actualizarPerfilFinanciero(id, actualizarPerfilDto);
        if (!resultado)
        {
            return NotFound(new { message = "Perfil financiero no encontrado" });
        }

        return Ok(new { message = "Perfil financiero actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarPerfilFinanciero(long id)
    {
        var resultado = await _perfilService.eliminarPerfilFinanciero(id);
        if (!resultado)
        {
            return NotFound(new { message = "Perfil financiero no encontrado" });
        }

        return Ok(new { message = "Perfil financiero eliminado exitosamente" });
    }
}}
