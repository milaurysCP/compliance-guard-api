using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Responsable.DTOs;
using ComplianceGuardPro.Modules.Responsable.Services;
using ComplianceGuardPro.Shared.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Responsable.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class ResponsablesController : ControllerBase
    {
        private readonly IResponsable _responsableService;

        public ResponsablesController(IResponsable responsableService)
        {
            _responsableService = responsableService;
        }

        // GET: api/responsable
        [HttpGet]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<List<ResponsableDto>>> GetResponsables()
        {
            var responsables = await _responsableService.GetAllAsync();
            return Ok(responsables);
        }

        // GET: api/responsable/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<List<ResponsableDto>>> GetResponsablesByCliente(long clienteId)
        {
            var responsables = await _responsableService.GetByClienteIdAsync(clienteId);
            return Ok(responsables);
        }

        // GET: api/responsable/{id}
        [HttpGet("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<ResponsableDto>> GetResponsable(long id)
        {
            var responsable = await _responsableService.GetByIdAsync(id);
            if (responsable == null)
            {
                return NotFound();
            }
            return Ok(responsable);
        }

        // POST: api/responsable
        [HttpPost]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<ActionResult<ResponsableDto>> CreateResponsable(CreateResponsableDto createResponsableDto)
        {
            var responsable = await _responsableService.CreateAsync(createResponsableDto);
            return CreatedAtAction(nameof(GetResponsable), new { id = responsable.Id }, responsable);
        }

        // PUT: api/responsable/{id}
        [HttpPut("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> UpdateResponsable(long id, CreateResponsableDto updateResponsableDto)
        {
            var responsable = await _responsableService.UpdateAsync(id, updateResponsableDto);
            if (responsable == null)
            {
                return NotFound();
            }
            return Ok(responsable);
        }

        // DELETE: api/responsable/{id}
        [HttpDelete("{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO)]
        public async Task<IActionResult> DeleteResponsable(long id)
        {
            var result = await _responsableService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
