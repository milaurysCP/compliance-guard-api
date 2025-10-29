using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EvaluacionController : ControllerBase
{
    private readonly IEvaluacion _evaluacionService;

    public EvaluacionController(IEvaluacion evaluacionService)
    {
        _evaluacionService = evaluacionService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerEvaluacionesPorCliente(long clienteId)
    {
        var evaluaciones = await _evaluacionService.obtenerEvaluacionesPorCliente(clienteId);
        return Ok(evaluaciones);
    }

    [HttpGet("riesgo/{riesgoId}")]
    public async Task<IActionResult> ObtenerEvaluacionesPorRiesgo(long riesgoId)
    {
        var evaluaciones = await _evaluacionService.obtenerEvaluacionesPorRiesgo(riesgoId);
        return Ok(evaluaciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerEvaluacion(long id)
    {
        var evaluacion = await _evaluacionService.obtenerEvaluacion(id);
        if (evaluacion == null)
        {
            return NotFound(new { message = "Evaluación no encontrada" });
        }
        return Ok(evaluacion);
    }

    [HttpPost]
    public async Task<IActionResult> CrearEvaluacion([FromBody] CreateEvaluacionDto crearEvaluacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _evaluacionService.crearEvaluacion(crearEvaluacionDto);
        return Ok(new { message = "Evaluación creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarEvaluacion(long id, [FromBody] CreateEvaluacionDto actualizarEvaluacionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _evaluacionService.actualizarEvaluacion(id, actualizarEvaluacionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Evaluación no encontrada" });
        }

        return Ok(new { message = "Evaluación actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarEvaluacion(long id)
    {
        var resultado = await _evaluacionService.eliminarEvaluacion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Evaluación no encontrada" });
        }

        return Ok(new { message = "Evaluación eliminada exitosamente" });
    }
}