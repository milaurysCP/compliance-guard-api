using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.ProgresoCapacitacion.DTOs;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Services
{
    public interface IProgresoCapacitacion
    {
        Task<List<ProgresoCapacitacionDto>> GetAllAsync();
        Task<ProgresoCapacitacionDto?> GetByIdAsync(long id);
        Task<List<ProgresoCapacitacionDto>> GetByUsuarioIdAsync(long usuarioId);
        Task<List<ProgresoCapacitacionDto>> GetByCapacitacionIdAsync(long capacitacionId);
        Task<ProgresoCapacitacionDto> CreateAsync(CreateProgresoCapacitacionDto createDto);
        Task<ProgresoCapacitacionDto?> UpdateAsync(long id, CreateProgresoCapacitacionDto updateDto);
        Task<bool> DeleteAsync(long id);
        Task<ProgresoCapacitacionDto?> CompletarCapacitacionAsync(long id, CompletarCapacitacionDto completarDto);
    }
}