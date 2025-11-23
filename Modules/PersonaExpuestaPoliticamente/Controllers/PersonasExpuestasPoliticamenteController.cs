using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.DTOs;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Deshabilitado temporalmente
    public class PersonasExpuestasPoliticamenteController : ControllerBase
    {
        private readonly IPersonaExpuestaPoliticamente _personaService;

        public PersonasExpuestasPoliticamenteController(IPersonaExpuestaPoliticamente personaService)
        {
            _personaService = personaService;
        }

        // GET: api/personaexpuestapoliticamente
        [HttpGet]
        public async Task<ActionResult<List<PersonaExpuestaPoliticamenteDto>>> GetPersonasExpuestasPoliticamente()
        {
            var personas = await _personaService.GetAllAsync();
            return Ok(personas);
        }

        // GET: api/personaexpuestapoliticamente/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<PersonaExpuestaPoliticamenteDto>>> GetPersonasExpuestasPoliticamenteByCliente(long clienteId)
        {
            var personas = await _personaService.GetByClienteIdAsync(clienteId);
            return Ok(personas);
        }

        // GET: api/personaexpuestapoliticamente/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaExpuestaPoliticamenteDto>> GetPersonaExpuestaPoliticamente(long id)
        {
            var persona = await _personaService.GetByIdAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // POST: api/personaexpuestapoliticamente
        [HttpPost]
        public async Task<ActionResult<PersonaExpuestaPoliticamenteDto>> CreatePersonaExpuestaPoliticamente(CreatePersonaExpuestaPoliticamenteDto createPersonaDto)
        {
            var persona = await _personaService.CreateAsync(createPersonaDto);
            return CreatedAtAction(nameof(GetPersonaExpuestaPoliticamente), new { id = persona.Id }, persona);
        }

        // PUT: api/personaexpuestapoliticamente/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonaExpuestaPoliticamente(long id, CreatePersonaExpuestaPoliticamenteDto updatePersonaDto)
        {
            var persona = await _personaService.UpdateAsync(id, updatePersonaDto);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // DELETE: api/personaexpuestapoliticamente/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaExpuestaPoliticamente(long id)
        {
            var result = await _personaService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
