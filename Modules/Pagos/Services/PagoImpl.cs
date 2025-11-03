using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Pagos.DTOs;
using ComplianceGuardPro.Modules.Pagos.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Pagos.Services
{
    public class PagoImpl : IPago
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PagoImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PagoDto>> obtenerPagosPorOperacion(long operacionId)
        {
            var pagos = await _context.Pagos
                .Include(p => p.Operacion)
                .Where(p => p.OperacionId == operacionId)
                .Select(p => _mapper.Map<PagoDto>(p))
                .ToListAsync();

            return pagos;
        }

        public async Task crearPago(CreatePagoDto createPagoDto)
        {
            var pago = _mapper.Map<Pago>(createPagoDto);
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> actualizarPago(long id, CreatePagoDto updatePagoDto)
        {
            var pago = await _context.Pagos.FirstOrDefaultAsync(p => p.Id == id);

            if (pago == null)
            {
                return false;
            }

            _mapper.Map(updatePagoDto, pago);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> eliminarPago(long id)
        {
            var pago = await _context.Pagos.FirstOrDefaultAsync(p => p.Id == id);

            if (pago == null)
            {
                return false;
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PagoDto?> obtenerPago(long id)
        {
            var pago = await _context.Pagos
                .Include(p => p.Operacion)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pago == null)
            {
                return null;
            }

            return _mapper.Map<PagoDto>(pago);
        }
    }
}