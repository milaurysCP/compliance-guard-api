using ComplianceGuardPro.Modules.FAQ.DTOs;

namespace ComplianceGuardPro.Modules.FAQ.Services
{
    public interface IFaqService
    {
        Task<List<FaqDto>> GetAllFaqsAsync();
        Task<List<FaqDto>> SearchFaqsAsync(string searchTerm);
        Task<bool> AddFaqAsync(CreateFaqDto createFaqDto);
        Task<bool> UpdateFaqAsync(UpdateFaqDto updateFaqDto);
        Task<bool> DeleteFaqAsync(string pregunta);
    }
}
