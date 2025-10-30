using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Evaluaciones.DTOs
{
    public class EvaluacionDto
    {
        public long Id { get; set; }
        public long RiesgoId { get; set; }
        public long ClienteId { get; set; }
        public int? Puntaje { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public string? UsuarioEvaluador { get; set; }
        public string? Observaciones { get; set; }
        public string? RiesgoNombre { get; set; }
        public string? ClienteNombre { get; set; }
    }

    public class CreateEvaluacionDto
    {
        [Required]
        public long RiesgoId { get; set; }

        [Required]
        public long ClienteId { get; set; }

        public int? Puntaje { get; set; }

        [Required]
        public DateTime FechaEvaluacion { get; set; }

        [StringLength(100)]
        public string? UsuarioEvaluador { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }
    }
}
