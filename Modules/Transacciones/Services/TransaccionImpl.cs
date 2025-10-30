using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Transacciones.DTOs;
using ComplianceGuardPro.Modules.Transacciones.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Transacciones.Services
{
    public class TransaccionImpl : ITransaccion
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TransaccionImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    public async Task<List<TransaccionDto>> obtenerTransaccionesPorCliente(long clienteId)
    {
        var transacciones = await _context.Transacciones
            .Where(t => t.ClienteId == clienteId)
            .Select(t => _mapper.Map<TransaccionDto>(t))
            .ToListAsync();

        return transacciones;
    }

    public async Task crearTransaccion(CreateTransaccionDto createTransaccionDto)
    {
        var transaccion = _mapper.Map<Transaccion>(createTransaccionDto);

        _context.Transacciones.Add(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarTransaccion(long id, CreateTransaccionDto updateTransaccionDto)
    {
        var transaccion = await _context.Transacciones.FindAsync(id);
        if (transaccion == null)
        {
            return false;
        }

        _mapper.Map(updateTransaccionDto, transaccion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarTransaccion(long id)
    {
        var transaccion = await _context.Transacciones.FindAsync(id);
        if (transaccion == null)
        {
            return false;
        }

        _context.Transacciones.Remove(transaccion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<TransaccionDto?> obtenerTransaccion(long id)
    {
        var transaccion = await _context.Transacciones.FindAsync(id);

        if (transaccion == null)
        {
            return null;
        }

        return _mapper.Map<TransaccionDto>(transaccion);
    }
}
}