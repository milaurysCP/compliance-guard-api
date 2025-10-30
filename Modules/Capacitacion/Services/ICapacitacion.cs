using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Capacitacion.DTOs;

namespace ComplianceGuardPro.Modules.Capacitacion.Services
{
    public interface ICapacitacion
    {
        Task<List<CapacitacionDto>> GetAllAsync();
        Task<CapacitacionDto?> GetByIdAsync(long id);
        Task<CapacitacionDto> CreateAsync(CreateCapacitacionDto createDto);
        Task<CapacitacionDto?> UpdateAsync(long id, CreateCapacitacionDto updateDto);
        Task<bool> DeleteAsync(long id);
    }
}