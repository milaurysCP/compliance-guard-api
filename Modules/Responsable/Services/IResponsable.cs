using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Responsable.DTOs;

namespace ComplianceGuardPro.Modules.Responsable.Services
{
    public interface IResponsable
    {
        Task<List<ResponsableDto>> GetAllAsync();
        Task<List<ResponsableDto>> GetByClienteIdAsync(long clienteId);
        Task<ResponsableDto?> GetByIdAsync(long id);
        Task<ResponsableDto> CreateAsync(CreateResponsableDto createDto);
        Task<ResponsableDto?> UpdateAsync(long id, CreateResponsableDto updateDto);
        Task<bool> DeleteAsync(long id);
    }
}