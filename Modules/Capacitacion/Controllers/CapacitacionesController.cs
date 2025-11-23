using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Capacitacion.DTOs;
using ComplianceGuardPro.Modules.Capacitacion.Services;
using ComplianceGuardPro.Shared.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Capacitacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class CapacitacionesController : ControllerBase
    {
        private readonly ICapacitacion _capacitacionService;

        public CapacitacionesController(ICapacitacion capacitacionService)
        {
            _capacitacionService = capacitacionService;
        }

        // GET: api/capacitacion
        [HttpGet]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<List<CapacitacionDto>>> GetCapacitaciones()
        {
            var capacitaciones = await _capacitacionService.GetAllAsync();
            return Ok(capacitaciones);
        }

        // GET: api/capacitacion/{id}
        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<CapacitacionDto>> GetCapacitacion(long id)
        {
            var capacitacion = await _capacitacionService.GetByIdAsync(id);
            if (capacitacion == null)
            {
                return NotFound(new { message = "Capacitación no encontrada" });
            }
            return Ok(capacitacion);
        }

        // POST: api/capacitacion
        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<CapacitacionDto>> CreateCapacitacion(CreateCapacitacionDto createCapacitacionDto)
        {
            var capacitacion = await _capacitacionService.CreateAsync(createCapacitacionDto);
            return CreatedAtAction(nameof(GetCapacitacion), new { id = capacitacion.Id }, capacitacion);
        }

        // PUT: api/capacitacion/{id}
        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> UpdateCapacitacion(long id, CreateCapacitacionDto updateCapacitacionDto)
        {
            var capacitacion = await _capacitacionService.UpdateAsync(id, updateCapacitacionDto);
            if (capacitacion == null)
            {
                return NotFound(new { message = "Capacitación no encontrada" });
            }
            return Ok(capacitacion);
        }

        // DELETE: api/capacitacion/{id}
        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> DeleteCapacitacion(long id)
        {
            var result = await _capacitacionService.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new { message = "Capacitación no encontrada" });
            }
            return Ok(new { message = "Capacitación eliminada exitosamente" });
        }
    }
}
