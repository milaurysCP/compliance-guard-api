using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class PersonaExpuestaPoliticamenteImpl : IPersonaExpuestaPoliticamente
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PersonaExpuestaPoliticamenteImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PersonaExpuestaPoliticamenteDto>> obtenerPersonasExpuestasPorCliente(long clienteId)
    {
        var personas = await _context.PersonasExpuestasPoliticamente
            .Where(p => p.ClienteId == clienteId)
            .Select(p => _mapper.Map<PersonaExpuestaPoliticamenteDto>(p))
            .ToListAsync();

        return personas;
    }

    public async Task crearPersonaExpuestaPoliticamente(CreatePersonaExpuestaPoliticamenteDto createPersonaDto)
    {
        var persona = _mapper.Map<PersonaExpuestaPoliticamente>(createPersonaDto);

        _context.PersonasExpuestasPoliticamente.Add(persona);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarPersonaExpuestaPoliticamente(long id, CreatePersonaExpuestaPoliticamenteDto updatePersonaDto)
    {
        var persona = await _context.PersonasExpuestasPoliticamente.FindAsync(id);
        if (persona == null)
        {
            return false;
        }

        _mapper.Map(updatePersonaDto, persona);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarPersonaExpuestaPoliticamente(long id)
    {
        var persona = await _context.PersonasExpuestasPoliticamente.FindAsync(id);
        if (persona == null)
        {
            return false;
        }

        _context.PersonasExpuestasPoliticamente.Remove(persona);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PersonaExpuestaPoliticamenteDto?> obtenerPersonaExpuestaPoliticamente(long id)
    {
        var persona = await _context.PersonasExpuestasPoliticamente.FindAsync(id);

        if (persona == null)
        {
            return null;
        }

        return _mapper.Map<PersonaExpuestaPoliticamenteDto>(persona);
    }
}