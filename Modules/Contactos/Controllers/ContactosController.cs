using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Contactos.DTOs;
using ComplianceGuardPro.Modules.Contactos.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Contactos.Controllers;

[Route("api/[controller]")]
[ApiController]
    // [Authorize] // Deshabilitado temporalmente
public class ContactosController : ControllerBase
{
    private readonly IContacto _contactoService;

    public ContactosController(IContacto contactoService)
    {
        _contactoService = contactoService;
    }

    [HttpGet("cliente/{clienteId}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerContactosPorCliente(long clienteId)
    {
        var contactos = await _contactoService.obtenerContactosPorCliente(clienteId);
        return Ok(contactos);
    }

    [HttpGet("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
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
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
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
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
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
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
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
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
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
