using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Contactos.DTOs;
using ComplianceGuardPro.Modules.Contactos.Services;

namespace ComplianceGuardPro.Modules.Contactos.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactosController : ControllerBase
{
    private readonly IContacto _contactoService;

    public ContactosController(IContacto contactoService)
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

    [HttpPost]
    public async Task<IActionResult> CrearContacto([FromBody] CreateContactoDto crearContactoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _contactoService.crearContacto(crearContactoDto);
        return Ok(new { message = "Contacto creado exitosamente" });
    }

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearContactoPorCliente(long clienteId, [FromBody] CreateContactoDto crearContactoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Override ClienteId from URL if provided in body
        crearContactoDto.ClienteId = clienteId;
        await _contactoService.crearContacto(crearContactoDto);
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