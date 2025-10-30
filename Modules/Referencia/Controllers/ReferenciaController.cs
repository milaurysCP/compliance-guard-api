using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.Referencia.DTOs;
using ComplianceGuardPro.Modules.Referencia.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Referencia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReferenciaController : ControllerBase
    {
        private readonly IReferencia _referenciaService;

        public ReferenciaController(IReferencia referenciaService)
        {
            _referenciaService = referenciaService;
        }

        // GET: api/referencia
        [HttpGet]
        public async Task<ActionResult<List<ReferenciaDto>>> GetReferencias()
        {
            var referencias = await _referenciaService.GetAllAsync();
            return Ok(referencias);
        }

        // GET: api/referencia/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<ReferenciaDto>>> GetReferenciasByCliente(long clienteId)
        {
            var referencias = await _referenciaService.GetByClienteIdAsync(clienteId);
            return Ok(referencias);
        }

        // GET: api/referencia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferenciaDto>> GetReferencia(long id)
        {
            var referencia = await _referenciaService.GetByIdAsync(id);
            if (referencia == null)
            {
                return NotFound();
            }
            return Ok(referencia);
        }

        // POST: api/referencia
        [HttpPost]
        public async Task<ActionResult<ReferenciaDto>> CreateReferencia(CreateReferenciaDto createReferenciaDto)
        {
            var referencia = await _referenciaService.CreateAsync(createReferenciaDto);
            return CreatedAtAction(nameof(GetReferencia), new { id = referencia.Id }, referencia);
        }

        // PUT: api/referencia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReferencia(long id, CreateReferenciaDto updateReferenciaDto)
        {
            var referencia = await _referenciaService.UpdateAsync(id, updateReferenciaDto);
            if (referencia == null)
            {
                return NotFound();
            }
            return Ok(referencia);
        }

        // DELETE: api/referencia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencia(long id)
        {
            var result = await _referenciaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}