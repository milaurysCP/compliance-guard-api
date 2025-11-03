using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Evaluaciones.DTOs;
using ComplianceGuardPro.Modules.Evaluaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Evaluaciones.Services
{
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
                .Include(e => e.Cliente)
                .Where(e => e.ClienteId == clienteId)
                .Select(e => _mapper.Map<EvaluacionDto>(e))
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
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evaluacion == null)
            {
                return null;
            }

            return _mapper.Map<EvaluacionDto>(evaluacion);
        }
    }
}