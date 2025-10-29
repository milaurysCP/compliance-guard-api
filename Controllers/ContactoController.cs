using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactoController : ControllerBase
{
    private readonly IContacto _contactoService;

    public ContactoController(IContacto contactoService)
    {
        _contactoService = contactoService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerContactosPorCliente(long clienteId)
    {
        var contactos = await _contactoService.obtenerContactosPorCliente(clienteId);
        return Ok(contactos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerContacto(long id)
    {
        var contacto = await _contactoService.obtenerContacto(id);
        if (contacto == null)
        {
            return NotFound(new { message = "Contacto no encontrado" });
        }
        return Ok(contacto);
    }

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearContacto(long clienteId, [FromBody] CreateContactoDto crearContactoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _contactoService.crearContacto(crearContactoDto, clienteId);
        return Ok(new { message = "Contacto creado exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarContacto(long id, [FromBody] CreateContactoDto actualizarContactoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _contactoService.actualizarContacto(id, actualizarContactoDto);
        if (!resultado)
        {
            return NotFound(new { message = "Contacto no encontrado" });
        }

        return Ok(new { message = "Contacto actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarContacto(long id)
    {
        var resultado = await _contactoService.eliminarContacto(id);
        if (!resultado)
        {
            return NotFound(new { message = "Contacto no encontrado" });
        }

        return Ok(new { message = "Contacto eliminado exitosamente" });
    }
}