using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.DTOs;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Services
{
    public class PersonaExpuestaPoliticamenteImpl : IPersonaExpuestaPoliticamente
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PersonaExpuestaPoliticamenteImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PersonaExpuestaPoliticamenteDto>> GetAllAsync()
        {
            var personas = await _context.PersonasExpuestasPoliticamente
                .Include(p => p.Cliente)
                .ToListAsync();

            return _mapper.Map<List<PersonaExpuestaPoliticamenteDto>>(personas);
        }

        public async Task<List<PersonaExpuestaPoliticamenteDto>> GetByClienteIdAsync(long clienteId)
        {
            var personas = await _context.PersonasExpuestasPoliticamente
                .Include(p => p.Cliente)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();

            return _mapper.Map<List<PersonaExpuestaPoliticamenteDto>>(personas);
        }

        public async Task<PersonaExpuestaPoliticamenteDto?> GetByIdAsync(long id)
        {
            var persona = await _context.PersonasExpuestasPoliticamente
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id);

            return persona == null ? null : _mapper.Map<PersonaExpuestaPoliticamenteDto>(persona);
        }

        public async Task<PersonaExpuestaPoliticamenteDto> CreateAsync(CreatePersonaExpuestaPoliticamenteDto createDto)
        {
            var persona = _mapper.Map<Models.PersonaExpuestaPoliticamente>(createDto);
            _context.PersonasExpuestasPoliticamente.Add(persona);
            await _context.SaveChangesAsync();

            // Recargar con la navegación incluida
            await _context.Entry(persona).Reference(p => p.Cliente).LoadAsync();

            return _mapper.Map<PersonaExpuestaPoliticamenteDto>(persona);
        }

        public async Task<PersonaExpuestaPoliticamenteDto?> UpdateAsync(long id, CreatePersonaExpuestaPoliticamenteDto updateDto)
        {
            var persona = await _context.PersonasExpuestasPoliticamente.FindAsync(id);
            if (persona == null)
                return null;

            _mapper.Map(updateDto, persona);
            await _context.SaveChangesAsync();

            // Recargar con la navegación incluida
            await _context.Entry(persona).Reference(p => p.Cliente).LoadAsync();

            return _mapper.Map<PersonaExpuestaPoliticamenteDto>(persona);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var persona = await _context.PersonasExpuestasPoliticamente.FindAsync(id);
            if (persona == null)
                return false;

            _context.PersonasExpuestasPoliticamente.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}