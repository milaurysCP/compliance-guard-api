using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProgresoCapacitacionController : ControllerBase
{
    private readonly IProgresoCapacitacion _progresoCapacitacionService;

    public ProgresoCapacitacionController(IProgresoCapacitacion progresoCapacitacionService)
    {
        _progresoCapacitacionService = progresoCapacitacionService;
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> ObtenerProgresoPorUsuario(long usuarioId)
    {
        try
        {
            var progreso = await _progresoCapacitacionService.obtenerProgresoPorUsuario(usuarioId);
            return Ok(progreso);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("capacitacion/{capacitacionId}")]
    public async Task<IActionResult> ObtenerProgresoPorCapacitacion(long capacitacionId)
    {
        try
        {
            var progreso = await _progresoCapacitacionService.obtenerProgresoPorCapacitacion(capacitacionId);
            return Ok(progreso);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerProgresoCapacitacion(long id)
    {
        try
        {
            var progreso = await _progresoCapacitacionService.obtenerProgresoCapacitacion(id);
            if (progreso == null)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }
            return Ok(progreso);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CrearProgresoCapacitacion([FromBody] CreateProgresoCapacitacionDto createProgresoCapacitacionDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _progresoCapacitacionService.crearProgresoCapacitacion(createProgresoCapacitacionDto);
            return CreatedAtAction(nameof(ObtenerProgresoCapacitacion), new { id = 0 }, createProgresoCapacitacionDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProgresoCapacitacion(long id, [FromBody] CreateProgresoCapacitacionDto updateProgresoCapacitacionDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _progresoCapacitacionService.actualizarProgresoCapacitacion(id, updateProgresoCapacitacionDto);
            if (!result)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProgresoCapacitacion(long id)
    {
        try
        {
            var result = await _progresoCapacitacionService.eliminarProgresoCapacitacion(id);
            if (!result)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}