using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Mitigacion.DTOs;
using ComplianceGuardPro.Modules.Mitigacion.Services;

namespace ComplianceGuardPro.Modules.Mitigacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class MitigacionController : ControllerBase
    {
        private readonly IMitigacion _mitigacionService;

        public MitigacionController(IMitigacion mitigacionService)
        {
            _mitigacionService = mitigacionService;
        }

        [HttpGet("riesgo/{riesgoId}")]
        public async Task<IActionResult> ObtenerMitigacionesPorRiesgo(long riesgoId)
        {
            var mitigaciones = await _mitigacionService.obtenerMitigacionesPorRiesgo(riesgoId);
            return Ok(mitigaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerMitigacion(long id)
        {
            var mitigacion = await _mitigacionService.obtenerMitigacion(id);
            if (mitigacion == null)
            {
                return NotFound(new { message = "Mitigación no encontrada" });
            }
            return Ok(mitigacion);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMitigacion([FromBody] CreateMitigacionDto crearMitigacionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mitigacionService.crearMitigacion(crearMitigacionDto);
            return Ok(new { message = "Mitigación creada exitosamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMitigacion(long id, [FromBody] CreateMitigacionDto actualizarMitigacionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _mitigacionService.actualizarMitigacion(id, actualizarMitigacionDto);
            if (!resultado)
            {
                return NotFound(new { message = "Mitigación no encontrada" });
            }

            return Ok(new { message = "Mitigación actualizada exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMitigacion(long id)
        {
            var resultado = await _mitigacionService.eliminarMitigacion(id);
            if (!resultado)
            {
                return NotFound(new { message = "Mitigación no encontrada" });
            }

            return Ok(new { message = "Mitigación eliminada exitosamente" });
        }
    }
}
