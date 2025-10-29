using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class ProgresoCapacitacionImpl : IProgresoCapacitacion
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProgresoCapacitacionImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProgresoCapacitacionDto>> obtenerProgresoPorUsuario(long usuarioId)
    {
        var progreso = await _context.ProgresoCapacitaciones
            .Where(p => p.UsuarioId == usuarioId)
            .Select(p => _mapper.Map<ProgresoCapacitacionDto>(p))
            .ToListAsync();

        return progreso;
    }

    public async Task<List<ProgresoCapacitacionDto>> obtenerProgresoPorCapacitacion(long capacitacionId)
    {
        var progreso = await _context.ProgresoCapacitaciones
            .Where(p => p.CapacitacionId == capacitacionId)
            .Select(p => _mapper.Map<ProgresoCapacitacionDto>(p))
            .ToListAsync();

        return progreso;
    }

    public async Task crearProgresoCapacitacion(CreateProgresoCapacitacionDto createProgresoCapacitacionDto)
    {
        var progreso = _mapper.Map<ProgresoCapacitacion>(createProgresoCapacitacionDto);

        // Si el progreso es 100, marcar como completado y establecer fecha
        if (createProgresoCapacitacionDto.Progreso == 100)
        {
            progreso.Estado = "Completado";
            progreso.FechaCompletado = createProgresoCapacitacionDto.FechaCompletado ?? DateTime.Now;
        }
        else
        {
            progreso.Estado = "En Progreso";
        }

        _context.ProgresoCapacitaciones.Add(progreso);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarProgresoCapacitacion(long id, CreateProgresoCapacitacionDto updateProgresoCapacitacionDto)
    {
        var progreso = await _context.ProgresoCapacitaciones.FindAsync(id);
        if (progreso == null)
        {
            return false;
        }

        _mapper.Map(updateProgresoCapacitacionDto, progreso);

        // Si el progreso es 100, marcar como completado y establecer fecha
        if (updateProgresoCapacitacionDto.Progreso == 100)
        {
            progreso.Estado = "Completado";
            progreso.FechaCompletado = updateProgresoCapacitacionDto.FechaCompletado ?? DateTime.Now;
        }
        else
        {
            progreso.Estado = "En Progreso";
            progreso.FechaCompletado = null;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarProgresoCapacitacion(long id)
    {
        var progreso = await _context.ProgresoCapacitaciones.FindAsync(id);
        if (progreso == null)
        {
            return false;
        }

        _context.ProgresoCapacitaciones.Remove(progreso);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ProgresoCapacitacionDto?> obtenerProgresoCapacitacion(long id)
    {
        var progreso = await _context.ProgresoCapacitaciones.FindAsync(id);

        if (progreso == null)
        {
            return null;
        }

        return _mapper.Map<ProgresoCapacitacionDto>(progreso);
    }
}