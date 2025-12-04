using Microsoft.AspNetCore.Mvc;
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

            // Obtener el ID del usuario desde el token JWT
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out var usuarioId))
            {
                return Unauthorized(new { message = "Token inválido o usuario no autenticado" });
            }

            await _debidaDiligenciaService.crearDebidaDiligencia(crearDebidaDiligenciaDto, usuarioId);
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
