using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Mitigacion.DTOs
{
    public class MitigacionDto
    {
        public long Id { get; set; }
        public long RiesgoId { get; set; }
        public string? Accion { get; set; }
        public string? Responsable { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string? Observaciones { get; set; }
        public decimal? Eficacia { get; set; }
        public string? RiesgoNombre { get; set; }
    }

    public class CreateMitigacionDto
    {
        [Required]
        public long RiesgoId { get; set; }

        [Required]
        [StringLength(255)]
        public required string Accion { get; set; }

        [Required]
        [StringLength(150)]
        public required string Responsable { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; } = "Pendiente";

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCierre { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        [Range(0, 100)]
        public decimal? Eficacia { get; set; }
    }
}