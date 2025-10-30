using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Referencia.DTOs;

namespace ComplianceGuardPro.Modules.Referencia.Services
{
    public interface IReferencia
    {
        Task<List<ReferenciaDto>> GetAllAsync();
        Task<List<ReferenciaDto>> GetByClienteIdAsync(long clienteId);
        Task<ReferenciaDto?> GetByIdAsync(long id);
        Task<ReferenciaDto> CreateAsync(CreateReferenciaDto createDto);
        Task<ReferenciaDto?> UpdateAsync(long id, CreateReferenciaDto updateDto);
        Task<bool> DeleteAsync(long id);
    }
}