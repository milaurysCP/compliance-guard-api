using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class ReferenciaImpl : IReferencia
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ReferenciaImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ReferenciaDto>> obtenerReferenciasPorCliente(long clienteId)
    {
        var referencias = await _context.Referencias
            .Where(r => r.ClienteId == clienteId)
            .Select(r => _mapper.Map<ReferenciaDto>(r))
            .ToListAsync();

        return referencias;
    }

    public async Task crearReferencia(CreateReferenciaDto createReferenciaDto)
    {
        var referencia = _mapper.Map<Referencia>(createReferenciaDto);

        _context.Referencias.Add(referencia);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarReferencia(long id, CreateReferenciaDto updateReferenciaDto)
    {
        var referencia = await _context.Referencias.FindAsync(id);
        if (referencia == null)
        {
            return false;
        }

        _mapper.Map(updateReferenciaDto, referencia);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarReferencia(long id)
    {
        var referencia = await _context.Referencias.FindAsync(id);
        if (referencia == null)
        {
            return false;
        }

        _context.Referencias.Remove(referencia);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ReferenciaDto?> obtenerReferencia(long id)
    {
        var referencia = await _context.Referencias.FindAsync(id);

        if (referencia == null)
        {
            return null;
        }

        return _mapper.Map<ReferenciaDto>(referencia);
    }
}