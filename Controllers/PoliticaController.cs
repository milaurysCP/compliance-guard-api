using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PoliticaController : ControllerBase
{
    private readonly IPolitica _politicaService;

    public PoliticaController(IPolitica politicaService)
    {
        _politicaService = politicaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerPoliticas()
    {
        var politicas = await _politicaService.obtenerPoliticas();
        return Ok(politicas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPolitica(long id)
    {
        var politica = await _politicaService.obtenerPolitica(id);
        if (politica == null)
        {
            return NotFound(new { message = "Política no encontrada" });
        }
        return Ok(politica);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPolitica([FromBody] CreatePoliticaDto crearPoliticaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _politicaService.crearPolitica(crearPoliticaDto);
        return Ok(new { message = "Política creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarPolitica(long id, [FromBody] CreatePoliticaDto actualizarPoliticaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _politicaService.actualizarPolitica(id, actualizarPoliticaDto);
        if (!resultado)
        {
            return NotFound(new { message = "Política no encontrada" });
        }

        return Ok(new { message = "Política actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarPolitica(long id)
    {
        var resultado = await _politicaService.eliminarPolitica(id);
        if (!resultado)
        {
            return NotFound(new { message = "Política no encontrada" });
        }

        return Ok(new { message = "Política eliminada exitosamente" });
    }
}