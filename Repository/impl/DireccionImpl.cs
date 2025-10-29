using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class DireccionImpl : IDireccion
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public DireccionImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DireccionDto>> obtenerDireccionesPorCliente(long clienteId)
    {
        var direcciones = await _context.Direcciones
            .Where(d => d.ClienteId == clienteId)
            .Select(d => _mapper.Map<DireccionDto>(d))
            .ToListAsync();

        return direcciones;
    }

    public async Task crearDireccion(CreateDireccionDto createDireccionDto, long clienteId)
    {
        var direccion = _mapper.Map<Direccion>(createDireccionDto);
        direccion.ClienteId = clienteId;

        _context.Direcciones.Add(direccion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarDireccion(long id, CreateDireccionDto updateDireccionDto)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion == null)
        {
            return false;
        }

        _mapper.Map(updateDireccionDto, direccion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarDireccion(long id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion == null)
        {
            return false;
        }

        _context.Direcciones.Remove(direccion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<DireccionDto?> obtenerDireccion(long id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);

        if (direccion == null)
        {
            return null;
        }

        return _mapper.Map<DireccionDto>(direccion);
    }
}