using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Politica.DTOs;
using ComplianceGuardPro.Modules.Politica.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Politica.Services
{
    public class PoliticaImpl : IPolitica
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PoliticaImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PoliticaDto>> GetAllAsync()
        {
            var politicas = await _context.Politicas
                .OrderByDescending(p => p.FechaCreacion)
                .ToListAsync();

            return _mapper.Map<List<PoliticaDto>>(politicas);
        }

        public async Task<PoliticaDto?> GetByIdAsync(long id)
        {
            var politica = await _context.Politicas.FindAsync(id);
            return politica == null ? null : _mapper.Map<PoliticaDto>(politica);
        }

        public async Task<PoliticaDto> CreateAsync(CreatePoliticaDto createDto)
        {
            var politica = _mapper.Map<Models.Politica>(createDto);
            if (politica.FechaCreacion == default)
            {
                politica.FechaCreacion = DateTime.Now;
            }

            _context.Politicas.Add(politica);
            await _context.SaveChangesAsync();

            return _mapper.Map<PoliticaDto>(politica);
        }

        public async Task<PoliticaDto?> UpdateAsync(long id, CreatePoliticaDto updateDto)
        {
            var politica = await _context.Politicas.FindAsync(id);
            if (politica == null)
                return null;

            _mapper.Map(updateDto, politica);
            await _context.SaveChangesAsync();

            return _mapper.Map<PoliticaDto>(politica);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var politica = await _context.Politicas.FindAsync(id);
            if (politica == null)
                return false;

            _context.Politicas.Remove(politica);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}