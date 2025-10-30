using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.DTOs;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProgresoCapacitacionController : ControllerBase
    {
        private readonly IProgresoCapacitacion _progresoCapacitacionService;

        public ProgresoCapacitacionController(IProgresoCapacitacion progresoCapacitacionService)
        {
            _progresoCapacitacionService = progresoCapacitacionService;
        }

        // GET: api/progresocapacitacion
        [HttpGet]
        public async Task<ActionResult<List<ProgresoCapacitacionDto>>> GetProgresoCapacitaciones()
        {
            var progresoCapacitaciones = await _progresoCapacitacionService.GetAllAsync();
            return Ok(progresoCapacitaciones);
        }

        // GET: api/progresocapacitacion/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgresoCapacitacionDto>> GetProgresoCapacitacion(long id)
        {
            var progresoCapacitacion = await _progresoCapacitacionService.GetByIdAsync(id);
            if (progresoCapacitacion == null)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }
            return Ok(progresoCapacitacion);
        }

        // GET: api/progresocapacitacion/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<List<ProgresoCapacitacionDto>>> GetProgresoByUsuario(long usuarioId)
        {
            var progresoCapacitaciones = await _progresoCapacitacionService.GetByUsuarioIdAsync(usuarioId);
            return Ok(progresoCapacitaciones);
        }

        // GET: api/progresocapacitacion/capacitacion/{capacitacionId}
        [HttpGet("capacitacion/{capacitacionId}")]
        public async Task<ActionResult<List<ProgresoCapacitacionDto>>> GetProgresoByCapacitacion(long capacitacionId)
        {
            var progresoCapacitaciones = await _progresoCapacitacionService.GetByCapacitacionIdAsync(capacitacionId);
            return Ok(progresoCapacitaciones);
        }

        // POST: api/progresocapacitacion
        [HttpPost]
        public async Task<ActionResult<ProgresoCapacitacionDto>> CreateProgresoCapacitacion(CreateProgresoCapacitacionDto createProgresoCapacitacionDto)
        {
            var progresoCapacitacion = await _progresoCapacitacionService.CreateAsync(createProgresoCapacitacionDto);
            return CreatedAtAction(nameof(GetProgresoCapacitacion), new { id = progresoCapacitacion.Id }, progresoCapacitacion);
        }

        // PUT: api/progresocapacitacion/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgresoCapacitacion(long id, CreateProgresoCapacitacionDto updateProgresoCapacitacionDto)
        {
            var progresoCapacitacion = await _progresoCapacitacionService.UpdateAsync(id, updateProgresoCapacitacionDto);
            if (progresoCapacitacion == null)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }
            return Ok(progresoCapacitacion);
        }

        // PUT: api/progresocapacitacion/{id}/completar
        [HttpPut("{id}/completar")]
        public async Task<IActionResult> CompletarCapacitacion(long id, CompletarCapacitacionDto completarCapacitacionDto)
        {
            var progresoCapacitacion = await _progresoCapacitacionService.CompletarCapacitacionAsync(id, completarCapacitacionDto);
            if (progresoCapacitacion == null)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }
            return Ok(new { message = "Capacitación marcada como completada" });
        }

        // DELETE: api/progresocapacitacion/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgresoCapacitacion(long id)
        {
            var result = await _progresoCapacitacionService.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new { message = "Progreso de capacitación no encontrado" });
            }
            return Ok(new { message = "Progreso de capacitación eliminado exitosamente" });
        }
    }
}