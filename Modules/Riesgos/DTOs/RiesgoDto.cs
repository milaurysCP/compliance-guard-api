using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Riesgos.DTOs
{
    public class RiesgoDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Mitigacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CantidadEvaluaciones { get; set; }
    }

    public class CreateRiesgoDto
    {
        [Required]
        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [StringLength(255)]
        public string? Mitigacion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
