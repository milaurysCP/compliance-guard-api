using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.DTOs;

namespace ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Services
{
    public interface IPersonaExpuestaPoliticamente
    {
        Task<List<PersonaExpuestaPoliticamenteDto>> GetAllAsync();
        Task<List<PersonaExpuestaPoliticamenteDto>> GetByClienteIdAsync(long clienteId);
        Task<PersonaExpuestaPoliticamenteDto?> GetByIdAsync(long id);
        Task<PersonaExpuestaPoliticamenteDto> CreateAsync(CreatePersonaExpuestaPoliticamenteDto createDto);
        Task<PersonaExpuestaPoliticamenteDto?> UpdateAsync(long id, CreatePersonaExpuestaPoliticamenteDto updateDto);
        Task<bool> DeleteAsync(long id);
    }
}