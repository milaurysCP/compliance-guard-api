using AutoMapper;
using ComplianceGuardPro.Data;
using Microsoft.EntityFrameworkCore;

public class EvaluacionImpl : IEvaluacion
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EvaluacionImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EvaluacionDto>> obtenerEvaluacionesPorCliente(long clienteId)
    {
        var evaluaciones = await _context.Evaluaciones
            .Include(e => e.Riesgo)
            .Where(e => e.ClienteId == clienteId)
            .Select(e => new EvaluacionDto
            {
                Id = e.Id,
                RiesgoId = e.RiesgoId,
                ClienteId = e.ClienteId,
                Puntaje = e.Puntaje,
                FechaEvaluacion = e.FechaEvaluacion,
                NivelRiesgo = e.Riesgo.Nombre
            })
            .ToListAsync();

        return evaluaciones;
    }

    public async Task<List<EvaluacionDto>> obtenerEvaluacionesPorRiesgo(long riesgoId)
    {
        var evaluaciones = await _context.Evaluaciones
            .Include(e => e.Riesgo)
            .Where(e => e.RiesgoId == riesgoId)
            .Select(e => new EvaluacionDto
            {
                Id = e.Id,
                RiesgoId = e.RiesgoId,
                ClienteId = e.ClienteId,
                Puntaje = e.Puntaje,
                FechaEvaluacion = e.FechaEvaluacion,
                NivelRiesgo = e.Riesgo.Nombre
            })
            .ToListAsync();

        return evaluaciones;
    }

    public async Task crearEvaluacion(CreateEvaluacionDto createEvaluacionDto)
    {
        var evaluacion = _mapper.Map<Evaluacion>(createEvaluacionDto);

        _context.Evaluaciones.Add(evaluacion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarEvaluacion(long id, CreateEvaluacionDto updateEvaluacionDto)
    {
        var evaluacion = await _context.Evaluaciones.FindAsync(id);
        if (evaluacion == null)
        {
            return false;
        }

        _mapper.Map(updateEvaluacionDto, evaluacion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> eliminarEvaluacion(long id)
    {
        var evaluacion = await _context.Evaluaciones.FindAsync(id);
        if (evaluacion == null)
        {
            return false;
        }

        _context.Evaluaciones.Remove(evaluacion);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<EvaluacionDto?> obtenerEvaluacion(long id)
    {
        var evaluacion = await _context.Evaluaciones
            .Include(e => e.Riesgo)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (evaluacion == null)
        {
            return null;
        }

        return new EvaluacionDto
        {
            Id = evaluacion.Id,
            RiesgoId = evaluacion.RiesgoId,
            ClienteId = evaluacion.ClienteId,
            Puntaje = evaluacion.Puntaje,
            FechaEvaluacion = evaluacion.FechaEvaluacion,
            NivelRiesgo = evaluacion.Riesgo.Nombre
        };
    }
}