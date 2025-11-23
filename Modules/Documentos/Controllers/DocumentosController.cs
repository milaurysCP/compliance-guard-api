using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Documentos.DTOs;
using ComplianceGuardPro.Modules.Documentos.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Documentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class DocumentosController : ControllerBase
    {
        private readonly IDocumento _documentoService;

        public DocumentosController(IDocumento documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet("debida-diligencia/{debidaDiligenciaId}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerDocumentosPorDebidaDiligencia(long debidaDiligenciaId)
        {
            var documentos = await _documentoService.obtenerDocumentosPorDebidaDiligencia(debidaDiligenciaId);
            return Ok(documentos);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerDocumento(long id)
        {
            var documento = await _documentoService.obtenerDocumento(id);
            if (documento == null)
            {
                return NotFound(new { message = "Documento no encontrado" });
            }
            return Ok(documento);
        }

        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> CrearDocumento([FromBody] CreateDocumentoDto crearDocumentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _documentoService.crearDocumento(crearDocumentoDto);
            return Ok(new { message = "Documento creado exitosamente" });
        }

        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ActualizarDocumento(long id, [FromBody] CreateDocumentoDto actualizarDocumentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _documentoService.actualizarDocumento(id, actualizarDocumentoDto);
            if (!resultado)
            {
                return NotFound(new { message = "Documento no encontrado" });
            }

            return Ok(new { message = "Documento actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> EliminarDocumento(long id)
        {
            var resultado = await _documentoService.eliminarDocumento(id);
            if (!resultado)
            {
                return NotFound(new { message = "Documento no encontrado" });
            }

            return Ok(new { message = "Documento eliminado exitosamente" });
        }
    }
}
