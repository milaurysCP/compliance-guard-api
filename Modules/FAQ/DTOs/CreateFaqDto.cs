using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.FAQ.DTOs
{
    public class CreateFaqDto
    {
        [Required(ErrorMessage = "La pregunta es obligatoria")]
        [StringLength(500, ErrorMessage = "La pregunta no puede exceder 500 caracteres")]
        public string Pregunta { get; set; } = string.Empty;

        [Required(ErrorMessage = "La respuesta es obligatoria")]
        [StringLength(2000, ErrorMessage = "La respuesta no puede exceder 2000 caracteres")]
        public string Respuesta { get; set; } = string.Empty;
    }
}
