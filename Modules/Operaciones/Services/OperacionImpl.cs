using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Operaciones.DTOs;
using ComplianceGuardPro.Modules.Operaciones.Models;
using ComplianceGuardPro.Modules.Pagos.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Operaciones.Services
{
    public class OperacionImpl : IOperacion
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OperacionImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OperacionDto>> obtenerOperacionesPorCliente(long clienteId)
    {
        var operaciones = await _context.Operaciones
            .Where(o => o.ClienteId == clienteId)
            .Include(o => o.Pagos)
            .Select(o => _mapper.Map<OperacionDto>(o))
            .ToListAsync();

        return operaciones;
    }

    public async Task crearOperacion(CreateOperacionDto createOperacionDto)
    {
        var operacion = _mapper.Map<Operacion>(createOperacionDto);

        // Crear pagos si se proporcionaron
        if (createOperacionDto.Pagos != null && createOperacionDto.Pagos.Any())
        {
            operacion.Pagos = createOperacionDto.Pagos
                .Select(p => _mapper.Map<Pago>(p))
                .ToList();
        }

        _context.Operaciones.Add(operacion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarOperacion(long id, CreateOperacionDto updateOperacionDto)
    {
        var operacion = await _context.Operaciones
            .Include(o => o.Pagos)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (operacion == null)
        {
            return false;
        }

        _mapper.Map(updateOperacionDto, operacion);

        // Actualizar pagos si se proporcionaron
        if (updateOperacionDto.Pagos != null)
        {
            // Remover pagos existentes
            _context.Pagos.RemoveRange(operacion.Pagos);

            // Agregar nuevos pagos
            operacion.Pagos = updateOperacionDto.Pagos
                .Select(p => _mapper.Map<Pago>(p))
                .ToList();
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarOperacion(long id)
    {
        var operacion = await _context.Operaciones
            .Include(o => o.Pagos)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (operacion == null)
        {
            return false;
        }

        // Remover pagos relacionados primero
        _context.Pagos.RemoveRange(operacion.Pagos);
        _context.Operaciones.Remove(operacion);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<OperacionDto?> obtenerOperacion(long id)
    {
        var operacion = await _context.Operaciones
            .Include(o => o.Pagos)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (operacion == null)
        {
            return null;
        }

        return _mapper.Map<OperacionDto>(operacion);
    }
}}
