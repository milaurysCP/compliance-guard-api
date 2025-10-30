using ComplianceGuardPro.Modules.DebidaDiligencia.DTOs;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Services
{
    public interface IDebidaDiligencia
    {
        Task<List<DebidaDiligenciaDto>> obtenerDebidaDiligencias();
        Task<DebidaDiligenciaDto?> obtenerDebidaDiligencia(long id);
        Task crearDebidaDiligencia(CreateDebidaDiligenciaDto createDebidaDiligenciaDto);
        Task<bool> actualizarDebidaDiligencia(long id, CreateDebidaDiligenciaDto updateDebidaDiligenciaDto);
        Task<bool> eliminarDebidaDiligencia(long id);
    }
}