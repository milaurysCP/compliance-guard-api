using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class ResponsableImpl : IResponsable
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ResponsableImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ResponsableDto>> obtenerResponsablesPorCliente(long clienteId)
    {
        var responsables = await _context.Responsables
            .Where(r => r.ClienteId == clienteId)
            .Select(r => _mapper.Map<ResponsableDto>(r))
            .ToListAsync();

        return responsables;
    }

    public async Task crearResponsable(CreateResponsableDto createResponsableDto)
    {
        var responsable = _mapper.Map<Responsable>(createResponsableDto);

        _context.Responsables.Add(responsable);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarResponsable(long id, CreateResponsableDto updateResponsableDto)
    {
        var responsable = await _context.Responsables.FindAsync(id);
        if (responsable == null)
        {
            return false;
        }

        _mapper.Map(updateResponsableDto, responsable);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarResponsable(long id)
    {
        var responsable = await _context.Responsables.FindAsync(id);
        if (responsable == null)
        {
            return false;
        }

        _context.Responsables.Remove(responsable);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ResponsableDto?> obtenerResponsable(long id)
    {
        var responsable = await _context.Responsables.FindAsync(id);

        if (responsable == null)
        {
            return null;
        }

        return _mapper.Map<ResponsableDto>(responsable);
    }
}