using ComplianceGuardPro.Modules.FAQ.DTOs;
using System.Text.Json;

namespace ComplianceGuardPro.Modules.FAQ.Services
{
    public class FaqServiceImpl : IFaqService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FaqServiceImpl> _logger;
        private readonly string _filePath;
        private readonly SemaphoreSlim _fileLock = new SemaphoreSlim(1, 1);

        public FaqServiceImpl(IWebHostEnvironment env, ILogger<FaqServiceImpl> logger)
        {
            _env = env;
            _logger = logger;
            _filePath = Path.Combine(_env.ContentRootPath, "FAQ_Ley_155_17.json");
        }

        public async Task<List<FaqDto>> GetAllFaqsAsync()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    _logger.LogWarning("FAQ file not found at: {FilePath}", _filePath);
                    return new List<FaqDto>();
                }

                var jsonContent = await File.ReadAllTextAsync(_filePath);
                var faqs = JsonSerializer.Deserialize<List<FaqDto>>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return faqs ?? new List<FaqDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading FAQ file");
                return new List<FaqDto>();
            }
        }

        public async Task<List<FaqDto>> SearchFaqsAsync(string searchTerm)
        {
            var allFaqs = await GetAllFaqsAsync();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return allFaqs;
            }

            var searchLower = searchTerm.ToLower();
            
            return allFaqs.Where(faq => 
                faq.Pregunta.ToLower().Contains(searchLower) || 
                faq.Respuesta.ToLower().Contains(searchLower)
            ).ToList();
        }

        public async Task<bool> AddFaqAsync(CreateFaqDto createFaqDto)
        {
            await _fileLock.WaitAsync();
            try
            {
                var faqs = await GetAllFaqsAsync();

                // Verificar si ya existe una pregunta similar
                if (faqs.Any(f => f.Pregunta.Trim().Equals(createFaqDto.Pregunta.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    _logger.LogWarning("FAQ with similar question already exists: {Question}", createFaqDto.Pregunta);
                    return false;
                }

                // Agregar nueva FAQ
                faqs.Add(new FaqDto
                {
                    Pregunta = createFaqDto.Pregunta.Trim(),
                    Respuesta = createFaqDto.Respuesta.Trim()
                });

                // Guardar en archivo
                await SaveFaqsToFileAsync(faqs);
                _logger.LogInformation("FAQ added successfully: {Question}", createFaqDto.Pregunta);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding FAQ");
                return false;
            }
            finally
            {
                _fileLock.Release();
            }
        }

        public async Task<bool> UpdateFaqAsync(UpdateFaqDto updateFaqDto)
        {
            await _fileLock.WaitAsync();
            try
            {
                var faqs = await GetAllFaqsAsync();

                // Buscar la FAQ a actualizar
                var faqToUpdate = faqs.FirstOrDefault(f => 
                    f.Pregunta.Trim().Equals(updateFaqDto.PreguntaOriginal.Trim(), StringComparison.OrdinalIgnoreCase));

                if (faqToUpdate == null)
                {
                    _logger.LogWarning("FAQ not found for update: {Question}", updateFaqDto.PreguntaOriginal);
                    return false;
                }

                // Verificar si la nueva pregunta ya existe en otra FAQ
                if (!updateFaqDto.NuevaPregunta.Equals(updateFaqDto.PreguntaOriginal, StringComparison.OrdinalIgnoreCase))
                {
                    if (faqs.Any(f => f.Pregunta.Trim().Equals(updateFaqDto.NuevaPregunta.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        _logger.LogWarning("FAQ with new question already exists: {Question}", updateFaqDto.NuevaPregunta);
                        return false;
                    }
                }

                // Actualizar FAQ
                faqToUpdate.Pregunta = updateFaqDto.NuevaPregunta.Trim();
                faqToUpdate.Respuesta = updateFaqDto.NuevaRespuesta.Trim();

                // Guardar en archivo
                await SaveFaqsToFileAsync(faqs);
                _logger.LogInformation("FAQ updated successfully: {OldQuestion} -> {NewQuestion}", 
                    updateFaqDto.PreguntaOriginal, updateFaqDto.NuevaPregunta);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating FAQ");
                return false;
            }
            finally
            {
                _fileLock.Release();
            }
        }

        public async Task<bool> DeleteFaqAsync(string pregunta)
        {
            await _fileLock.WaitAsync();
            try
            {
                var faqs = await GetAllFaqsAsync();

                // Buscar la FAQ a eliminar
                var faqToDelete = faqs.FirstOrDefault(f => 
                    f.Pregunta.Trim().Equals(pregunta.Trim(), StringComparison.OrdinalIgnoreCase));

                if (faqToDelete == null)
                {
                    _logger.LogWarning("FAQ not found for deletion: {Question}", pregunta);
                    return false;
                }

                // Eliminar FAQ
                faqs.Remove(faqToDelete);

                // Guardar en archivo
                await SaveFaqsToFileAsync(faqs);
                _logger.LogInformation("FAQ deleted successfully: {Question}", pregunta);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting FAQ");
                return false;
            }
            finally
            {
                _fileLock.Release();
            }
        }

        private async Task SaveFaqsToFileAsync(List<FaqDto> faqs)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonContent = JsonSerializer.Serialize(faqs, options);
            await File.WriteAllTextAsync(_filePath, jsonContent);
        }
    }
}
