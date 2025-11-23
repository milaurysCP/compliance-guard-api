using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Pagos.DTOs;
using ComplianceGuardPro.Modules.Pagos.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Pagos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class PagosController : ControllerBase
    {
        private readonly IPago _pagoService;

        public PagosController(IPago pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet("operacion/{operacionId}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerPagosPorOperacion(long operacionId)
        {
            var pagos = await _pagoService.obtenerPagosPorOperacion(operacionId);
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ObtenerPago(long id)
        {
            var pago = await _pagoService.obtenerPago(id);
            if (pago == null)
            {
                return NotFound(new { message = "Pago no encontrado" });
            }
            return Ok(pago);
        }

        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> CrearPago([FromBody] CreatePagoDto crearPagoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _pagoService.crearPago(crearPagoDto);
            return Ok(new { message = "Pago creado exitosamente" });
        }

        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> ActualizarPago(long id, [FromBody] CreatePagoDto actualizarPagoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _pagoService.actualizarPago(id, actualizarPagoDto);
            if (!resultado)
            {
                return NotFound(new { message = "Pago no encontrado" });
            }

            return Ok(new { message = "Pago actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> EliminarPago(long id)
        {
            var resultado = await _pagoService.eliminarPago(id);
            if (!resultado)
            {
                return NotFound(new { message = "Pago no encontrado" });
            }

            return Ok(new { message = "Pago eliminado exitosamente" });
        }
    }
}
