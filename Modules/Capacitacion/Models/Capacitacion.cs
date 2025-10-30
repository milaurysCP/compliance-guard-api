using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Capacitacion.Models
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

        [Range(1, 100)]
        public int DuracionHoras { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [StringLength(200)]
        public string? Instructor { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}