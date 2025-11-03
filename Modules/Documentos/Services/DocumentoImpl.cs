using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Documentos.DTOs;
using ComplianceGuardPro.Modules.Documentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Documentos.Services
{
    public class DocumentoImpl : IDocumento
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DocumentoImpl(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DocumentoDto>> obtenerDocumentosPorDebidaDiligencia(long debidaDiligenciaId)
        {
            var documentos = await _context.Documentos
                .Include(d => d.DebidaDiligencia)
                .Where(d => d.DebidaDiligenciaId == debidaDiligenciaId)
                .Select(d => _mapper.Map<DocumentoDto>(d))
                .ToListAsync();

            return documentos;
        }

        public async Task crearDocumento(CreateDocumentoDto createDocumentoDto)
        {
            var documento = _mapper.Map<Documento>(createDocumentoDto);
            _context.Documentos.Add(documento);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> actualizarDocumento(long id, CreateDocumentoDto updateDocumentoDto)
        {
            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return false;
            }

            _mapper.Map(updateDocumentoDto, documento);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> eliminarDocumento(long id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return false;
            }

            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DocumentoDto?> obtenerDocumento(long id)
        {
            var documento = await _context.Documentos
                .Include(d => d.DebidaDiligencia)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (documento == null)
            {
                return null;
            }

            return _mapper.Map<DocumentoDto>(documento);
        }
    }
}