using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Models
{
    public class Capacitacion
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Titulo { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}