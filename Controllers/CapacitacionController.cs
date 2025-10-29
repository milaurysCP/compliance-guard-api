using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CapacitacionController : ControllerBase
{
    private readonly ICapacitacion _capacitacionService;

    public CapacitacionController(ICapacitacion capacitacionService)
    {
        _capacitacionService = capacitacionService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerCapacitaciones()
    {
        var capacitaciones = await _capacitacionService.obtenerCapacitaciones();
        return Ok(capacitaciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerCapacitacion(long id)
    {
        var capacitacion = await _capacitacionService.obtenerCapacitacion(id);
        if (capacitacion == null)
        {
            return NotFound(new { message = "Capacitación no encontrada" });
        }
        return Ok(capacitacion);
    }

    [HttpPost]
    public async Task<IActionResult> CrearCapacitacion([FromBody] CreateCapacitacionDto crearCapacitacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _capacitacionService.crearCapacitacion(crearCapacitacionDto);
        return Ok(new { message = "Capacitación creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarCapacitacion(long id, [FromBody] CreateCapacitacionDto actualizarCapacitacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _capacitacionService.actualizarCapacitacion(id, actualizarCapacitacionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Capacitación no encontrada" });
        }

        return Ok(new { message = "Capacitación actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCapacitacion(long id)
    {
        var resultado = await _capacitacionService.eliminarCapacitacion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Capacitación no encontrada o tiene progresos asociados" });
        }

        return Ok(new { message = "Capacitación eliminada exitosamente" });
    }
}