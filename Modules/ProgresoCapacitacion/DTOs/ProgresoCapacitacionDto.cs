using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.DTOs
{
    public class ProgresoCapacitacionDto
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long CapacitacionId { get; set; }
        public decimal ProgresoPorcentaje { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaCompletado { get; set; }
        public int? Calificacion { get; set; }
        public string? Observaciones { get; set; }
    }

    public class CreateProgresoCapacitacionDto
    {
        [Required]
        public long UsuarioId { get; set; }

        [Required]
        public long CapacitacionId { get; set; }

        [Range(0, 100)]
        public decimal ProgresoPorcentaje { get; set; } = 0;

        [StringLength(50)]
        public string? Estado { get; set; } = "Iniciado";

        [Required]
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;

        public DateTime? FechaCompletado { get; set; }
        public int? Calificacion { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }
    }

    public class CompletarCapacitacionDto
    {
        [Required]
        [Range(0, 100)]
        public int Calificacion { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }
    }
}