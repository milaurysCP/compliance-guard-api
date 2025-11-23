using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Riesgos.DTOs;
using ComplianceGuardPro.Modules.Riesgos.Services;

namespace ComplianceGuardPro.Modules.Riesgos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class RiesgosController : ControllerBase
    {
        private readonly IRiesgo _riesgoService;

        public RiesgosController(IRiesgo riesgoService)
        {
            _riesgoService = riesgoService;
        }

    [HttpGet]
    public async Task<IActionResult> ObtenerRiesgos()
    {
        var riesgos = await _riesgoService.obtenerRiesgos();
        return Ok(riesgos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerRiesgo(long id)
    {
        var riesgo = await _riesgoService.obtenerRiesgo(id);
        if (riesgo == null)
        {
            return NotFound(new { message = "Riesgo no encontrado" });
        }
        return Ok(riesgo);
    }

    [HttpPost]
    public async Task<IActionResult> CrearRiesgo([FromBody] CreateRiesgoDto crearRiesgoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _riesgoService.crearRiesgo(crearRiesgoDto);
        return Ok(new { message = "Riesgo creado exitosamente" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarRiesgo(long id, [FromBody] CreateRiesgoDto actualizarRiesgoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = await _riesgoService.actualizarRiesgo(id, actualizarRiesgoDto);
        if (!resultado)
        {
            return NotFound(new { message = "Riesgo no encontrado" });
        }

        return Ok(new { message = "Riesgo actualizado exitosamente" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarRiesgo(long id)
    {
        var resultado = await _riesgoService.eliminarRiesgo(id);
        if (!resultado)
        {
            return NotFound(new { message = "Riesgo no encontrado o tiene evaluaciones asociadas" });
        }

        return Ok(new { message = "Riesgo eliminado exitosamente" });
    }
}
}
