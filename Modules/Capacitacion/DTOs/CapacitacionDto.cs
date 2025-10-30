using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Capacitacion.DTOs
{
    public class CapacitacionDto
    {
        public long Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int DuracionHoras { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Instructor { get; set; }
        public string? Estado { get; set; }
    }

    public class CreateCapacitacionDto
    {
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
        public string? Estado { get; set; } = "Programada";
    }
}