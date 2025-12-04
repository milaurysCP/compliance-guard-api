using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Riesgos.DTOs;
using ComplianceGuardPro.Modules.Riesgos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Riesgos.Services
{
    public class RiesgoImpl : IRiesgo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RiesgoImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RiesgoDto>> obtenerRiesgos()
        {
            var riesgos = await _context.Riesgos
                .ToListAsync();

            return riesgos.Select(r => _mapper.Map<RiesgoDto>(r)).ToList();
        }

        public async Task crearRiesgo(CreateRiesgoDto createRiesgoDto)
        {
            var riesgo = _mapper.Map<Riesgo>(createRiesgoDto);

            _context.Riesgos.Add(riesgo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> actualizarRiesgo(long id, CreateRiesgoDto updateRiesgoDto)
        {
            var riesgo = await _context.Riesgos.FindAsync(id);
            if (riesgo == null)
            {
                return false;
            }

            _mapper.Map(updateRiesgoDto, riesgo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> eliminarRiesgo(long id)
        {
            var riesgo = await _context.Riesgos
                .FirstOrDefaultAsync(r => r.Id == id);

            if (riesgo == null)
            {
                return false;
            }

            _context.Riesgos.Remove(riesgo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<RiesgoDto?> obtenerRiesgo(long id)
        {
            var riesgo = await _context.Riesgos
                .FirstOrDefaultAsync(r => r.Id == id);

            if (riesgo == null)
            {
                return null;
            }

            return _mapper.Map<RiesgoDto>(riesgo);
        }
    }
}