using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.DebidaDiligencia.DTOs;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Services
{
    public class DebidaDiligenciaImpl : IDebidaDiligencia
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DebidaDiligenciaImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DebidaDiligenciaDto>> obtenerDebidaDiligencias()
        {
            var debidaDiligencias = await _context.DebidaDiligencias
                .Include(dd => dd.Cliente)
                .Include(dd => dd.Riesgos)
                .Include(dd => dd.Documentos)
                .ToListAsync();

            return debidaDiligencias.Select(dd => _mapper.Map<DebidaDiligenciaDto>(dd)).ToList();
        }

        public async Task<DebidaDiligenciaDto?> obtenerDebidaDiligencia(long id)
        {
            var debidaDiligencia = await _context.DebidaDiligencias
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.Direcciones)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.Contactos)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.ActividadesEconomicas)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.BeneficiariosFinales)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.PerfilesFinancieros)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.Operaciones)
                        .ThenInclude(o => o.Pagos)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.PersonasExpuestasPoliticamente)
                .Include(dd => dd.Cliente)
                    .ThenInclude(c => c.Responsables)
                .Include(dd => dd.Riesgos)
                .Include(dd => dd.Documentos)
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (debidaDiligencia == null)
            {
                return null;
            }

            return _mapper.Map<DebidaDiligenciaDto>(debidaDiligencia);
        }

        public async Task crearDebidaDiligencia(CreateDebidaDiligenciaDto createDebidaDiligenciaDto, long usuarioId)
        {
            var debidaDiligencia = _mapper.Map<ComplianceGuardPro.Modules.DebidaDiligencia.Models.DebidaDiligencia>(createDebidaDiligenciaDto);
            debidaDiligencia.FechaRegistro = DateTime.UtcNow;
            
            _context.DebidaDiligencias.Add(debidaDiligencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> actualizarDebidaDiligencia(long id, CreateDebidaDiligenciaDto updateDebidaDiligenciaDto)
        {
            var debidaDiligencia = await _context.DebidaDiligencias.FirstOrDefaultAsync(dd => dd.Id == id);

            if (debidaDiligencia == null)
            {
                return false;
            }

            _mapper.Map(updateDebidaDiligenciaDto, debidaDiligencia);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> eliminarDebidaDiligencia(long id)
        {
            var debidaDiligencia = await _context.DebidaDiligencias
                .Include(dd => dd.Riesgos)
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (debidaDiligencia == null)
            {
                return false;
            }

            _context.DebidaDiligencias.Remove(debidaDiligencia);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}