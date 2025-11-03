using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.DTOs
{
    public class DebidaDiligenciaDto
    {
        public long Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateDebidaDiligenciaDto
    {
        [Required]
        [StringLength(200)]
        public required string Titulo { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        [StringLength(1000)]
        public string? Observaciones { get; set; }

        [Required]
        public long ClienteId { get; set; }
    }
}