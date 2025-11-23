using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Services;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class ActividadesEconomicasController : ControllerBase
{
    private readonly IActividadEconomica _actividadService;

    public ActividadesEconomicasController(IActividadEconomica actividadService)
    {
        _actividadService = actividadService;
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ObtenerActividadesPorCliente(long clienteId)
    {
        var actividades = await _actividadService.obtenerActividadesPorCliente(clienteId);
        return Ok(actividades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerActividadEconomica(long id)
    {
        var actividad = await _actividadService.obtenerActividadEconomica(id);
        if (actividad == null)
        {
            return NotFound(new { message = "Actividad económica no encontrada" });
        }
        return Ok(actividad);
    }

    [HttpPost]
    public async Task<IActionResult> CrearActividadEconomica([FromBody] CreateActividadEconomicaDto crearActividadDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _actividadService.crearActividadEconomica(crearActividadDto);
        return Ok(new { message = "Actividad económica creada exitosamente" });
    }

    [HttpPost("cliente/{clienteId}")]
    public async Task<IActionResult> CrearActividadEconomicaPorCliente(long clienteId, [FromBody] CreateActividadEconomicaDto crearActividadDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Override ClienteId from URL if provided in body
        crearActividadDto.ClienteId = clienteId;
        await _actividadService.crearActividadEconomica(crearActividadDto);
        return Ok(new { message = "Actividad económica creada exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarActividadEconomica(long id, [FromBody] CreateActividadEconomicaDto actualizarActividadDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _actividadService.actualizarActividadEconomica(id, actualizarActividadDto);
        if (!resultado)
        {
            return NotFound(new { message = "Actividad económica no encontrada" });
        }

        return Ok(new { message = "Actividad económica actualizada exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarActividadEconomica(long id)
    {
        var resultado = await _actividadService.eliminarActividadEconomica(id);
        if (!resultado)
        {
            return NotFound(new { message = "Actividad económica no encontrada" });
        }

        return Ok(new { message = "Actividad económica eliminada exitosamente" });
    }
}}
