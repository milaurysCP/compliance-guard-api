using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Referencia.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Referencia.Services
{
    public class ReferenciaImpl : IReferencia
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReferenciaImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReferenciaDto>> GetAllAsync()
        {
            var referencias = await _context.Referencias
                .ToListAsync();

            return _mapper.Map<List<ReferenciaDto>>(referencias);
        }

        public async Task<List<ReferenciaDto>> GetByClienteIdAsync(long clienteId)
        {
            var referencias = await _context.Referencias
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();

            return _mapper.Map<List<ReferenciaDto>>(referencias);
        }

        public async Task<ReferenciaDto?> GetByIdAsync(long id)
        {
            var referencia = await _context.Referencias
                .FirstOrDefaultAsync(r => r.Id == id);

            return referencia == null ? null : _mapper.Map<ReferenciaDto>(referencia);
        }

        public async Task<ReferenciaDto> CreateAsync(CreateReferenciaDto createDto)
        {
            var referencia = _mapper.Map<Models.Referencia>(createDto);
            _context.Referencias.Add(referencia);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReferenciaDto>(referencia);
        }

        public async Task<ReferenciaDto?> UpdateAsync(long id, CreateReferenciaDto updateDto)
        {
            var referencia = await _context.Referencias.FindAsync(id);
            if (referencia == null)
                return null;

            _mapper.Map(updateDto, referencia);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReferenciaDto>(referencia);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var referencia = await _context.Referencias.FindAsync(id);
            if (referencia == null)
                return false;

            _context.Referencias.Remove(referencia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}