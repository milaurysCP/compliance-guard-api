using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PersonaExpuestaPoliticamenteController : ControllerBase
{
    private readonly IPersonaExpuestaPoliticamente _personaService;

    public PersonaExpuestaPoliticamenteController(IPersonaExpuestaPoliticamente personaService)
    {
        _personaService = personaService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerPersonasExpuestasPorCliente(long clienteId)
    {
        var personas = await _personaService.obtenerPersonasExpuestasPorCliente(clienteId);
        return Ok(personas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPersonaExpuestaPoliticamente(long id)
    {
        var persona = await _personaService.obtenerPersonaExpuestaPoliticamente(id);
        if (persona == null)
        {
            return NotFound(new { message = "Persona expuesta políticamente no encontrada" });
        }
        return Ok(persona);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPersonaExpuestaPoliticamente([FromBody] CreatePersonaExpuestaPoliticamenteDto crearPersonaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _personaService.crearPersonaExpuestaPoliticamente(crearPersonaDto);
        return Ok(new { message = "Persona expuesta políticamente creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarPersonaExpuestaPoliticamente(long id, [FromBody] CreatePersonaExpuestaPoliticamenteDto actualizarPersonaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _personaService.actualizarPersonaExpuestaPoliticamente(id, actualizarPersonaDto);
        if (!resultado)
        {
            return NotFound(new { message = "Persona expuesta políticamente no encontrada" });
        }

        return Ok(new { message = "Persona expuesta políticamente actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarPersonaExpuestaPoliticamente(long id)
    {
        var resultado = await _personaService.eliminarPersonaExpuestaPoliticamente(id);
        if (!resultado)
        {
            return NotFound(new { message = "Persona expuesta políticamente no encontrada" });
        }

        return Ok(new { message = "Persona expuesta políticamente eliminada exitosamente" });
    }
}