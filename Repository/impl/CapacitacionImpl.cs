using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class CapacitacionImpl : ICapacitacion
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CapacitacionImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CapacitacionDto>> obtenerCapacitaciones()
    {
        var capacitaciones = await _context.Capacitaciones
            .Include(c => c.Progresos)
            .Select(c => new CapacitacionDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                Descripcion = c.Descripcion,
                FechaCreacion = c.FechaCreacion,
                CantidadProgresos = c.Progresos.Count
            })
            .ToListAsync();

        return capacitaciones;
    }

    public async Task crearCapacitacion(CreateCapacitacionDto createCapacitacionDto)
    {
        var capacitacion = _mapper.Map<Capacitacion>(createCapacitacionDto);

        _context.Capacitaciones.Add(capacitacion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarCapacitacion(long id, CreateCapacitacionDto updateCapacitacionDto)
    {
        var capacitacion = await _context.Capacitaciones.FindAsync(id);
        if (capacitacion == null)
        {
            return false;
        }

        _mapper.Map(updateCapacitacionDto, capacitacion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarCapacitacion(long id)
    {
        var capacitacion = await _context.Capacitaciones
            .Include(c => c.Progresos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (capacitacion == null)
        {
            return false;
        }

        // Verificar si tiene progresos asociados
        if (capacitacion.Progresos.Any())
        {
            return false;
        }

        _context.Capacitaciones.Remove(capacitacion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<CapacitacionDto?> obtenerCapacitacion(long id)
    {
        var capacitacion = await _context.Capacitaciones
            .Include(c => c.Progresos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (capacitacion == null)
        {
            return null;
        }

        return new CapacitacionDto
        {
            Id = capacitacion.Id,
            Titulo = capacitacion.Titulo,
            Descripcion = capacitacion.Descripcion,
            FechaCreacion = capacitacion.FechaCreacion,
            CantidadProgresos = capacitacion.Progresos.Count
        };
    }
}