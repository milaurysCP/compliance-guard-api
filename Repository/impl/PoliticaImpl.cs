using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class PoliticaImpl : IPolitica
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PoliticaImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PoliticaDto>> obtenerPoliticas()
    {
        var politicas = await _context.Politicas
            .Select(p => _mapper.Map<PoliticaDto>(p))
            .ToListAsync();

        return politicas;
    }

    public async Task crearPolitica(CreatePoliticaDto createPoliticaDto)
    {
        var politica = _mapper.Map<Politica>(createPoliticaDto);

        _context.Politicas.Add(politica);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarPolitica(long id, CreatePoliticaDto updatePoliticaDto)
    {
        var politica = await _context.Politicas.FindAsync(id);
        if (politica == null)
        {
            return false;
        }

        _mapper.Map(updatePoliticaDto, politica);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarPolitica(long id)
    {
        var politica = await _context.Politicas.FindAsync(id);
        if (politica == null)
        {
            return false;
        }

        _context.Politicas.Remove(politica);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PoliticaDto?> obtenerPolitica(long id)
    {
        var politica = await _context.Politicas.FindAsync(id);

        if (politica == null)
        {
            return null;
        }

        return _mapper.Map<PoliticaDto>(politica);
    }
}