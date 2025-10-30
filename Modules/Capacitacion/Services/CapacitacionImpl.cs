using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Capacitacion.DTOs;
using ComplianceGuardPro.Modules.Capacitacion.Models;

namespace ComplianceGuardPro.Modules.Capacitacion.Services
{
    public class CapacitacionImpl : ICapacitacion
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CapacitacionImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CapacitacionDto>> GetAllAsync()
        {
            var capacitaciones = await _context.Capacitaciones.ToListAsync();
            return _mapper.Map<List<CapacitacionDto>>(capacitaciones);
        }

        public async Task<CapacitacionDto?> GetByIdAsync(long id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            return capacitacion != null ? _mapper.Map<CapacitacionDto>(capacitacion) : null;
        }

        public async Task<CapacitacionDto> CreateAsync(CreateCapacitacionDto createDto)
        {
            var capacitacion = _mapper.Map<Models.Capacitacion>(createDto);
            _context.Capacitaciones.Add(capacitacion);
            await _context.SaveChangesAsync();

            return _mapper.Map<CapacitacionDto>(capacitacion);
        }

        public async Task<CapacitacionDto?> UpdateAsync(long id, CreateCapacitacionDto updateDto)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
            {
                return null;
            }

            _mapper.Map(updateDto, capacitacion);
            await _context.SaveChangesAsync();

            return _mapper.Map<CapacitacionDto>(capacitacion);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
            {
                return false;
            }

            _context.Capacitaciones.Remove(capacitacion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}