using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Evaluaciones.DTOs;
using ComplianceGuardPro.Modules.Evaluaciones.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Evaluaciones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacion _evaluacionService;

        public EvaluacionesController(IEvaluacion evaluacionService)
        {
            _evaluacionService = evaluacionService;
        }

        [HttpGet("cliente/{clienteId}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerEvaluacionesPorCliente(long clienteId)
        {
            var evaluaciones = await _evaluacionService.obtenerEvaluacionesPorCliente(clienteId);
            return Ok(evaluaciones);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerEvaluacion(long id)
        {
            var evaluacion = await _evaluacionService.obtenerEvaluacion(id);
            if (evaluacion == null)
            {
                return NotFound(new { message = "Evaluación no encontrada" });
            }
            return Ok(evaluacion);
        }

        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> CrearEvaluacion([FromBody] CreateEvaluacionDto crearEvaluacionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _evaluacionService.crearEvaluacion(crearEvaluacionDto);
            return Ok(new { message = "Evaluación creada exitosamente" });
        }

        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ActualizarEvaluacion(long id, [FromBody] CreateEvaluacionDto actualizarEvaluacionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _evaluacionService.actualizarEvaluacion(id, actualizarEvaluacionDto);
            if (!resultado)
            {
                return NotFound(new { message = "Evaluación no encontrada" });
            }

            return Ok(new { message = "Evaluación actualizada exitosamente" });
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> EliminarEvaluacion(long id)
        {
            var resultado = await _evaluacionService.eliminarEvaluacion(id);
            if (!resultado)
            {
                return NotFound(new { message = "Evaluación no encontrada" });
            }

            return Ok(new { message = "Evaluación eliminada exitosamente" });
        }
    }
}
