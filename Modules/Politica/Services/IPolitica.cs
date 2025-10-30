using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Politica.DTOs;

namespace ComplianceGuardPro.Modules.Politica.Services
{
    public interface IPolitica
    {
        Task<List<PoliticaDto>> GetAllAsync();
        Task<PoliticaDto?> GetByIdAsync(long id);
        Task<PoliticaDto> CreateAsync(CreatePoliticaDto createDto);
        Task<PoliticaDto?> UpdateAsync(long id, CreatePoliticaDto updateDto);
        Task<bool> DeleteAsync(long id);
    }
}