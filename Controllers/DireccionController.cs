using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DireccionController : ControllerBase
{
    private readonly IDireccion _direccionService;

    public DireccionController(IDireccion direccionService)
    {
        _direccionService = direccionService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerDireccionesPorCliente(long clienteId)
    {
        var direcciones = await _direccionService.obtenerDireccionesPorCliente(clienteId);
        return Ok(direcciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerDireccion(long id)
    {
        var direccion = await _direccionService.obtenerDireccion(id);
        if (direccion == null)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }
        return Ok(direccion);
    }

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearDireccion(long clienteId, [FromBody] CreateDireccionDto crearDireccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _direccionService.crearDireccion(crearDireccionDto, clienteId);
        return Ok(new { message = "Dirección creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarDireccion(long id, [FromBody] CreateDireccionDto actualizarDireccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _direccionService.actualizarDireccion(id, actualizarDireccionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }

        return Ok(new { message = "Dirección actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarDireccion(long id)
    {
        var resultado = await _direccionService.eliminarDireccion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }

        return Ok(new { message = "Dirección eliminada exitosamente" });
    }
}