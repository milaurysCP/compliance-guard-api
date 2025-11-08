using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComplianceGuardPro.Modules.FAQ.Services;
using ComplianceGuardPro.Modules.FAQ.DTOs;

namespace ComplianceGuardPro.Modules.FAQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FaqController : ControllerBase
    {
        private readonly IFaqService _faqService;
        private readonly ILogger<FaqController> _logger;

        public FaqController(IFaqService faqService, ILogger<FaqController> logger)
        {
            _faqService = faqService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las preguntas frecuentes sobre la Ley 155-17
        /// </summary>
        /// <returns>Lista completa de FAQs</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFaqs()
        {
            try
            {
                var faqs = await _faqService.GetAllFaqsAsync();
                return Ok(new
                {
                    success = true,
                    data = faqs,
                    total = faqs.Count
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving FAQs");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al obtener las preguntas frecuentes"
                });
            }
        }

        /// <summary>
        /// Busca preguntas frecuentes por término de búsqueda
        /// </summary>
        /// <param name="q">Término de búsqueda (busca en preguntas y respuestas)</param>
        /// <returns>Lista de FAQs que coinciden con la búsqueda</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchFaqs([FromQuery] string q)
        {
            try
            {
                var faqs = await _faqService.SearchFaqsAsync(q);
                return Ok(new
                {
                    success = true,
                    data = faqs,
                    total = faqs.Count,
                    searchTerm = q
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching FAQs with term: {SearchTerm}", q);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al buscar en las preguntas frecuentes"
                });
            }
        }

        /// <summary>
        /// Agrega una nueva pregunta frecuente
        /// </summary>
        /// <param name="createFaqDto">Datos de la nueva FAQ</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost]
        public async Task<IActionResult> AddFaq([FromBody] CreateFaqDto createFaqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Datos inválidos",
                        errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                    });
                }

                var result = await _faqService.AddFaqAsync(createFaqDto);

                if (!result)
                {
                    return Conflict(new
                    {
                        success = false,
                        message = "Ya existe una FAQ con una pregunta similar"
                    });
                }

                return CreatedAtAction(nameof(GetAllFaqs), new
                {
                    success = true,
                    message = "Pregunta frecuente agregada exitosamente",
                    data = createFaqDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding FAQ");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al agregar la pregunta frecuente"
                });
            }
        }

        /// <summary>
        /// Actualiza una pregunta frecuente existente
        /// </summary>
        /// <param name="updateFaqDto">Datos para actualizar la FAQ</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateFaq([FromBody] UpdateFaqDto updateFaqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Datos inválidos",
                        errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                    });
                }

                var result = await _faqService.UpdateFaqAsync(updateFaqDto);

                if (!result)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "No se encontró la pregunta frecuente a actualizar o ya existe una FAQ con la nueva pregunta"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Pregunta frecuente actualizada exitosamente",
                    data = updateFaqDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating FAQ");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al actualizar la pregunta frecuente"
                });
            }
        }

        /// <summary>
        /// Elimina una pregunta frecuente
        /// </summary>
        /// <param name="pregunta">Pregunta a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteFaq([FromQuery] string pregunta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pregunta))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Debe proporcionar la pregunta a eliminar"
                    });
                }

                var result = await _faqService.DeleteFaqAsync(pregunta);

                if (!result)
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "No se encontró la pregunta frecuente a eliminar"
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Pregunta frecuente eliminada exitosamente"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting FAQ");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al eliminar la pregunta frecuente"
                });
            }
        }
    }
}
