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
                .Include(r => r.Evaluaciones)
                .Select(r => new RiesgoDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Mitigacion = r.Mitigacion,
                    FechaCreacion = r.FechaCreacion,
                    CantidadEvaluaciones = r.Evaluaciones.Count
                })
                .ToListAsync();

            return riesgos;
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
                .Include(r => r.Evaluaciones)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (riesgo == null)
            {
                return false;
            }

            // Verificar si tiene evaluaciones asociadas
            if (riesgo.Evaluaciones.Any())
            {
                // No permitir eliminación si tiene evaluaciones
                return false;
            }

            _context.Riesgos.Remove(riesgo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<RiesgoDto?> obtenerRiesgo(long id)
        {
            var riesgo = await _context.Riesgos
                .Include(r => r.Evaluaciones)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (riesgo == null)
            {
                return null;
            }

            return new RiesgoDto
            {
                Id = riesgo.Id,
                Nombre = riesgo.Nombre,
                Descripcion = riesgo.Descripcion,
                Mitigacion = riesgo.Mitigacion,
                FechaCreacion = riesgo.FechaCreacion,
                CantidadEvaluaciones = riesgo.Evaluaciones.Count
            };
        }
    }
}