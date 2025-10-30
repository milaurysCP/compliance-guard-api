using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Riesgos.DTOs;

namespace ComplianceGuardPro.Modules.Riesgos.Services
{
    public interface IRiesgo
    {
        Task<List<RiesgoDto>> obtenerRiesgos();
        Task crearRiesgo(CreateRiesgoDto createRiesgoDto);
        Task<bool> actualizarRiesgo(long id, CreateRiesgoDto updateRiesgoDto);
        Task<bool> eliminarRiesgo(long id);
        Task<RiesgoDto?> obtenerRiesgo(long id);
    }
}