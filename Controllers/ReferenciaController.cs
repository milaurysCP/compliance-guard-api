using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReferenciaController : ControllerBase
{
    private readonly IReferencia _referenciaService;

    public ReferenciaController(IReferencia referenciaService)
    {
        _referenciaService = referenciaService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerReferenciasPorCliente(long clienteId)
    {
        try
        {
            var referencias = await _referenciaService.obtenerReferenciasPorCliente(clienteId);
            return Ok(referencias);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerReferencia(long id)
    {
        try
        {
            var referencia = await _referenciaService.obtenerReferencia(id);
            if (referencia == null)
            {
                return NotFound(new { message = "Referencia no encontrada" });
            }
            return Ok(referencia);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CrearReferencia([FromBody] CreateReferenciaDto createReferenciaDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _referenciaService.crearReferencia(createReferenciaDto);
            return CreatedAtAction(nameof(ObtenerReferencia), new { id = 0 }, createReferenciaDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarReferencia(long id, [FromBody] CreateReferenciaDto updateReferenciaDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _referenciaService.actualizarReferencia(id, updateReferenciaDto);
            if (!result)
            {
                return NotFound(new { message = "Referencia no encontrada" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarReferencia(long id)
    {
        try
        {
            var result = await _referenciaService.eliminarReferencia(id);
            if (!result)
            {
                return NotFound(new { message = "Referencia no encontrada" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        }
    }
}