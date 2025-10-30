using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Mitigacion.DTOs;
using ComplianceGuardPro.Modules.Mitigacion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Mitigacion.Services
{
    public class MitigacionImpl : IMitigacion
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MitigacionImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MitigacionDto>> obtenerMitigacionesPorRiesgo(long riesgoId)
        {
            var mitigaciones = await _context.Mitigaciones
                .Include(m => m.Riesgo)
                .Where(m => m.RiesgoId == riesgoId)
                .Select(m => new MitigacionDto
                {
                    Id = m.Id,
                    RiesgoId = m.RiesgoId,
                    Accion = m.Accion,
                    Responsable = m.Responsable,
                    Estado = m.Estado,
                    FechaInicio = m.FechaInicio,
                    FechaCierre = m.FechaCierre,
                    Observaciones = m.Observaciones,
                    Eficacia = m.Eficacia,
                    RiesgoNombre = m.Riesgo.Nombre
                })
                .ToListAsync();

            return mitigaciones;
        }

        public async Task crearMitigacion(CreateMitigacionDto createMitigacionDto)
        {
            var mitigacion = _mapper.Map<Models.Mitigacion>(createMitigacionDto);
            _context.Mitigaciones.Add(mitigacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> actualizarMitigacion(long id, CreateMitigacionDto updateMitigacionDto)
        {
            var mitigacion = await _context.Mitigaciones.FindAsync(id);
            if (mitigacion == null)
            {
                return false;
            }

            _mapper.Map(updateMitigacionDto, mitigacion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> eliminarMitigacion(long id)
        {
            var mitigacion = await _context.Mitigaciones.FindAsync(id);
            if (mitigacion == null)
            {
                return false;
            }

            _context.Mitigaciones.Remove(mitigacion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<MitigacionDto?> obtenerMitigacion(long id)
        {
            var mitigacion = await _context.Mitigaciones
                .Include(m => m.Riesgo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mitigacion == null)
            {
                return null;
            }

            return new MitigacionDto
            {
                Id = mitigacion.Id,
                RiesgoId = mitigacion.RiesgoId,
                Accion = mitigacion.Accion,
                Responsable = mitigacion.Responsable,
                Estado = mitigacion.Estado,
                FechaInicio = mitigacion.FechaInicio,
                FechaCierre = mitigacion.FechaCierre,
                Observaciones = mitigacion.Observaciones,
                Eficacia = mitigacion.Eficacia,
                RiesgoNombre = mitigacion.Riesgo.Nombre
            };
        }
    }
}