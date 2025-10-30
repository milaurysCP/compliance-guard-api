using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.DTOs;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.Models;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Services
{
    public class ProgresoCapacitacionImpl : IProgresoCapacitacion
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProgresoCapacitacionImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProgresoCapacitacionDto>> GetAllAsync()
        {
            var progresoCapacitaciones = await _context.ProgresoCapacitaciones
                .Include(p => p.Usuario)
                .Include(p => p.Capacitacion)
                .ToListAsync();

            return _mapper.Map<List<ProgresoCapacitacionDto>>(progresoCapacitaciones);
        }

        public async Task<ProgresoCapacitacionDto?> GetByIdAsync(long id)
        {
            var progresoCapacitacion = await _context.ProgresoCapacitaciones
                .Include(p => p.Usuario)
                .Include(p => p.Capacitacion)
                .FirstOrDefaultAsync(p => p.Id == id);

            return progresoCapacitacion != null ? _mapper.Map<ProgresoCapacitacionDto>(progresoCapacitacion) : null;
        }

        public async Task<List<ProgresoCapacitacionDto>> GetByUsuarioIdAsync(long usuarioId)
        {
            var progresoCapacitaciones = await _context.ProgresoCapacitaciones
                .Include(p => p.Usuario)
                .Include(p => p.Capacitacion)
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();

            return _mapper.Map<List<ProgresoCapacitacionDto>>(progresoCapacitaciones);
        }

        public async Task<List<ProgresoCapacitacionDto>> GetByCapacitacionIdAsync(long capacitacionId)
        {
            var progresoCapacitaciones = await _context.ProgresoCapacitaciones
                .Include(p => p.Usuario)
                .Include(p => p.Capacitacion)
                .Where(p => p.CapacitacionId == capacitacionId)
                .ToListAsync();

            return _mapper.Map<List<ProgresoCapacitacionDto>>(progresoCapacitaciones);
        }

        public async Task<ProgresoCapacitacionDto> CreateAsync(CreateProgresoCapacitacionDto createDto)
        {
            var progresoCapacitacion = _mapper.Map<Models.ProgresoCapacitacion>(createDto);
            _context.ProgresoCapacitaciones.Add(progresoCapacitacion);
            await _context.SaveChangesAsync();

            // Cargar las propiedades de navegación
            await _context.Entry(progresoCapacitacion).Reference(p => p.Usuario).LoadAsync();
            await _context.Entry(progresoCapacitacion).Reference(p => p.Capacitacion).LoadAsync();

            return _mapper.Map<ProgresoCapacitacionDto>(progresoCapacitacion);
        }

        public async Task<ProgresoCapacitacionDto?> UpdateAsync(long id, CreateProgresoCapacitacionDto updateDto)
        {
            var progresoCapacitacion = await _context.ProgresoCapacitaciones.FindAsync(id);
            if (progresoCapacitacion == null)
            {
                return null;
            }

            _mapper.Map(updateDto, progresoCapacitacion);
            await _context.SaveChangesAsync();

            // Cargar las propiedades de navegación
            await _context.Entry(progresoCapacitacion).Reference(p => p.Usuario).LoadAsync();
            await _context.Entry(progresoCapacitacion).Reference(p => p.Capacitacion).LoadAsync();

            return _mapper.Map<ProgresoCapacitacionDto>(progresoCapacitacion);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var progresoCapacitacion = await _context.ProgresoCapacitaciones.FindAsync(id);
            if (progresoCapacitacion == null)
            {
                return false;
            }

            _context.ProgresoCapacitaciones.Remove(progresoCapacitacion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProgresoCapacitacionDto?> CompletarCapacitacionAsync(long id, CompletarCapacitacionDto completarDto)
        {
            var progresoCapacitacion = await _context.ProgresoCapacitaciones.FindAsync(id);
            if (progresoCapacitacion == null)
            {
                return null;
            }

            progresoCapacitacion.ProgresoPorcentaje = 100;
            progresoCapacitacion.Estado = "Completado";
            progresoCapacitacion.FechaCompletado = DateTime.UtcNow;
            progresoCapacitacion.Calificacion = completarDto.Calificacion;
            progresoCapacitacion.Observaciones = completarDto.Observaciones;

            await _context.SaveChangesAsync();

            // Cargar las propiedades de navegación
            await _context.Entry(progresoCapacitacion).Reference(p => p.Usuario).LoadAsync();
            await _context.Entry(progresoCapacitacion).Reference(p => p.Capacitacion).LoadAsync();

            return _mapper.Map<ProgresoCapacitacionDto>(progresoCapacitacion);
        }
    }
}