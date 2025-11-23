using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.DebidaDiligencia.DTOs;
using ComplianceGuardPro.Modules.DebidaDiligencia.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class DebidaDiligenciaController : ControllerBase
    {
        private readonly IDebidaDiligencia _debidaDiligenciaService;

        public DebidaDiligenciaController(IDebidaDiligencia debidaDiligenciaService)
        {
            _debidaDiligenciaService = debidaDiligenciaService;
        }

        [HttpGet]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerDebidaDiligencias()
        {
            var debidaDiligencias = await _debidaDiligenciaService.obtenerDebidaDiligencias();
            return Ok(debidaDiligencias);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerDebidaDiligencia(long id)
        {
            var debidaDiligencia = await _debidaDiligenciaService.obtenerDebidaDiligencia(id);
            if (debidaDiligencia == null)
            {
                return NotFound(new { message = "Debida diligencia no encontrada" });
            }
            return Ok(debidaDiligencia);
        }

        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> CrearDebidaDiligencia([FromBody] CreateDebidaDiligenciaDto crearDebidaDiligenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _debidaDiligenciaService.crearDebidaDiligencia(crearDebidaDiligenciaDto);
            return Ok(new { message = "Debida diligencia creada exitosamente" });
        }

        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ActualizarDebidaDiligencia(long id, [FromBody] CreateDebidaDiligenciaDto actualizarDebidaDiligenciaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _debidaDiligenciaService.actualizarDebidaDiligencia(id, actualizarDebidaDiligenciaDto);
            if (!resultado)
            {
                return NotFound(new { message = "Debida diligencia no encontrada" });
            }

            return Ok(new { message = "Debida diligencia actualizada exitosamente" });
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> EliminarDebidaDiligencia(long id)
        {
            var resultado = await _debidaDiligenciaService.eliminarDebidaDiligencia(id);
            if (!resultado)
            {
                return NotFound(new { message = "Debida diligencia no encontrada" });
            }

            return Ok(new { message = "Debida diligencia eliminada exitosamente" });
        }
    }
}
