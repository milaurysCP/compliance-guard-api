using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.FAQ.DTOs
{
    public class UpdateFaqDto
    {
        [Required(ErrorMessage = "La pregunta original es obligatoria")]
        public string PreguntaOriginal { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva pregunta es obligatoria")]
        [StringLength(500, ErrorMessage = "La pregunta no puede exceder 500 caracteres")]
        public string NuevaPregunta { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva respuesta es obligatoria")]
        [StringLength(2000, ErrorMessage = "La respuesta no puede exceder 2000 caracteres")]
        public string NuevaRespuesta { get; set; } = string.Empty;
    }
}
