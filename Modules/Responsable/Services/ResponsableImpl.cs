using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Responsable.DTOs;
using ComplianceGuardPro.Modules.Responsable.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplianceGuardPro.Modules.Responsable.Services
{
    public class ResponsableImpl : IResponsable
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResponsableImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResponsableDto>> GetAllAsync()
        {
            var responsables = await _context.Responsables
                .Include(r => r.Cliente)
                .ToListAsync();

            return _mapper.Map<List<ResponsableDto>>(responsables);
        }

        public async Task<List<ResponsableDto>> GetByClienteIdAsync(long clienteId)
        {
            var responsables = await _context.Responsables
                .Include(r => r.Cliente)
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();

            return _mapper.Map<List<ResponsableDto>>(responsables);
        }

        public async Task<ResponsableDto?> GetByIdAsync(long id)
        {
            var responsable = await _context.Responsables
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(r => r.Id == id);

            return responsable == null ? null : _mapper.Map<ResponsableDto>(responsable);
        }

        public async Task<ResponsableDto> CreateAsync(CreateResponsableDto createDto)
        {
            var responsable = _mapper.Map<Models.Responsable>(createDto);
            _context.Responsables.Add(responsable);
            await _context.SaveChangesAsync();

            // Recargar con la navegación incluida
            await _context.Entry(responsable).Reference(r => r.Cliente).LoadAsync();

            return _mapper.Map<ResponsableDto>(responsable);
        }

        public async Task<ResponsableDto?> UpdateAsync(long id, CreateResponsableDto updateDto)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            if (responsable == null)
                return null;

            _mapper.Map(updateDto, responsable);
            await _context.SaveChangesAsync();

            // Recargar con la navegación incluida
            await _context.Entry(responsable).Reference(r => r.Cliente).LoadAsync();

            return _mapper.Map<ResponsableDto>(responsable);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var responsable = await _context.Responsables.FindAsync(id);
            if (responsable == null)
                return false;

            _context.Responsables.Remove(responsable);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}