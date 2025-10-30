using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Mitigacion.DTOs;

namespace ComplianceGuardPro.Modules.Mitigacion.Services
{
    public interface IMitigacion
    {
        Task<List<MitigacionDto>> obtenerMitigacionesPorRiesgo(long riesgoId);
        Task crearMitigacion(CreateMitigacionDto createMitigacionDto);
        Task<bool> actualizarMitigacion(long id, CreateMitigacionDto updateMitigacionDto);
        Task<bool> eliminarMitigacion(long id);
        Task<MitigacionDto?> obtenerMitigacion(long id);
    }
}