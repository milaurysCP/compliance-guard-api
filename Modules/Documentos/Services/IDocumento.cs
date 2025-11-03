using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Documentos.DTOs;

namespace ComplianceGuardPro.Modules.Documentos.Services
{
    public interface IDocumento
    {
        Task<List<DocumentoDto>> obtenerDocumentosPorDebidaDiligencia(long debidaDiligenciaId);
        Task crearDocumento(CreateDocumentoDto createDocumentoDto);
        Task<bool> actualizarDocumento(long id, CreateDocumentoDto updateDocumentoDto);
        Task<bool> eliminarDocumento(long id);
        Task<DocumentoDto?> obtenerDocumento(long id);
    }
}