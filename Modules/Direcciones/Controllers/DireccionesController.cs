using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Direcciones.DTOs;
using ComplianceGuardPro.Modules.Direcciones.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Direcciones.Controllers;

[Route("api/[controller]")]
[ApiController]
    // [Authorize] // Deshabilitado temporalmente
public class DireccionesController : ControllerBase
{
    private readonly IDireccion _direccionService;

    public DireccionesController(IDireccion direccionService)
    {
        _direccionService = direccionService;
    }

    [HttpGet("cliente/{clienteId}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerDireccionesPorCliente(long clienteId)
    {
        var direcciones = await _direccionService.obtenerDireccionesPorCliente(clienteId);
        return Ok(direcciones);
    }

    [HttpGet("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ObtenerDireccion(long id)
    {
        var direccion = await _direccionService.obtenerDireccion(id);
        if (direccion == null)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }
        return Ok(direccion);
    }

    [HttpPost]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> CrearDireccion([FromBody] CreateDireccionDto crearDireccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _direccionService.crearDireccion(crearDireccionDto);
        return Ok(new { message = "Dirección creada exitosamente" });
    }

    [HttpPost("cliente/{clienteId}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> CrearDireccionPorCliente(long clienteId, [FromBody] CreateDireccionDto crearDireccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Override ClienteId from URL if provided in body
        crearDireccionDto.ClienteId = clienteId;
        await _direccionService.crearDireccion(crearDireccionDto);
        return Ok(new { message = "Dirección creada exitosamente" });
    }

    [HttpPut("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public async Task<IActionResult> ActualizarDireccion(long id, [FromBody] CreateDireccionDto actualizarDireccionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _direccionService.actualizarDireccion(id, actualizarDireccionDto);
        if (!resultado)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }

        return Ok(new { message = "Dirección actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
    public async Task<IActionResult> EliminarDireccion(long id)
    {
        var resultado = await _direccionService.eliminarDireccion(id);
        if (!resultado)
        {
            return NotFound(new { message = "Dirección no encontrada" });
        }

        return Ok(new { message = "Dirección eliminada exitosamente" });
    }
}
