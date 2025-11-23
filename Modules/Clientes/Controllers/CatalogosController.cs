using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Clientes.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Clientes.Controllers;

[ApiController]
[Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
public class CatalogosController : ControllerBase
{
    private readonly ICatalogoService _catalogoService;

    public CatalogosController(ICatalogoService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    [HttpGet("actividad-economica")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerActividadEconomica()
    {
        var actividades = _catalogoService.ObtenerActividadEconomica();
        return Ok(actividades);
    }

    [HttpGet("operaciones")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerOperaciones()
    {
        var operaciones = _catalogoService.ObtenerOperaciones();
        return Ok(operaciones);
    }

    [HttpGet("paises")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerPaises()
    {
        var paises = _catalogoService.ObtenerPaises();
        return Ok(paises);
    }

    [HttpGet("provincias")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerProvincias([FromQuery] string? pais = null)
    {
        if (pais == null || pais == "República Dominicana")
        {
            var provincias = _catalogoService.ObtenerProvinciasRD();
            return Ok(provincias);
        }
        
        return Ok(new List<object>());
    }

    [HttpGet("municipios")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerMunicipios([FromQuery] string provincia)
    {
        if (string.IsNullOrWhiteSpace(provincia))
        {
            return BadRequest(new { message = "Provincia es requerida" });
        }

        var municipios = _catalogoService.ObtenerMunicipiosPorProvincia(provincia);
        return Ok(municipios);
    }

    [HttpGet("peps")]
    [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
    public IActionResult ObtenerPeps()
    {
        var peps = _catalogoService.ObtenerPeps();
        return Ok(peps);
    }
}
