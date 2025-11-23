using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Politica.DTOs;
using ComplianceGuardPro.Modules.Politica.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Politica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class PoliticasController : ControllerBase
    {
        private readonly IPolitica _politicaService;

        public PoliticasController(IPolitica politicaService)
        {
            _politicaService = politicaService;
        }

        // GET: api/politica
        [HttpGet]
        public async Task<ActionResult<List<PoliticaDto>>> GetPoliticas()
        {
            var politicas = await _politicaService.GetAllAsync();
            return Ok(politicas);
        }

        // GET: api/politica/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PoliticaDto>> GetPolitica(long id)
        {
            var politica = await _politicaService.GetByIdAsync(id);
            if (politica == null)
            {
                return NotFound();
            }
            return Ok(politica);
        }

        // POST: api/politica
        [HttpPost]
        public async Task<ActionResult<PoliticaDto>> CreatePolitica(CreatePoliticaDto createPoliticaDto)
        {
            var politica = await _politicaService.CreateAsync(createPoliticaDto);
            return CreatedAtAction(nameof(GetPolitica), new { id = politica.Id }, politica);
        }

        // PUT: api/politica/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolitica(long id, CreatePoliticaDto updatePoliticaDto)
        {
            var politica = await _politicaService.UpdateAsync(id, updatePoliticaDto);
            if (politica == null)
            {
                return NotFound();
            }
            return Ok(politica);
        }

        // DELETE: api/politica/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitica(long id)
        {
            var result = await _politicaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
