using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ResponsableController : ControllerBase
{
    private readonly IResponsable _responsableService;

    public ResponsableController(IResponsable responsableService)
    {
        _responsableService = responsableService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerResponsablesPorCliente(long clienteId)
    {
        try
        {
            var responsables = await _responsableService.obtenerResponsablesPorCliente(clienteId);
            return Ok(responsables);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerResponsable(long id)
    {
        try
        {
            var responsable = await _responsableService.obtenerResponsable(id);
            if (responsable == null)
            {
                return NotFound(new { message = "Responsable no encontrado" });
            }
            return Ok(responsable);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CrearResponsable([FromBody] CreateResponsableDto createResponsableDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _responsableService.crearResponsable(createResponsableDto);
            return CreatedAtAction(nameof(ObtenerResponsable), new { id = 0 }, createResponsableDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarResponsable(long id, [FromBody] CreateResponsableDto updateResponsableDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _responsableService.actualizarResponsable(id, updateResponsableDto);
            if (!result)
            {
                return NotFound(new { message = "Responsable no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarResponsable(long id)
    {
        try
        {
            var result = await _responsableService.eliminarResponsable(id);
            if (!result)
            {
                return NotFound(new { message = "Responsable no encontrado" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}