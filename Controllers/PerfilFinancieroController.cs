using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PerfilFinancieroController : ControllerBase
{
    private readonly IPerfilFinanciero _perfilService;

    public PerfilFinancieroController(IPerfilFinanciero perfilService)
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

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearPerfilFinanciero(long clienteId, [FromBody] CreatePerfilFinancieroDto crearPerfilDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _perfilService.crearPerfilFinanciero(crearPerfilDto, clienteId);
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
}