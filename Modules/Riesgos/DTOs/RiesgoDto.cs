using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Riesgos.DTOs
{
    public class RiesgoDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificador { get; set; }
        public string? Tipo { get; set; }
        public string? Categoria { get; set; }
        public string? Estado { get; set; }
        public string? DescripcionRiesgo { get; set; }
        public string? Objetivo { get; set; }
        public string? Fase { get; set; }
        public string? Causa { get; set; }
        public string? Efecto { get; set; }
        public string? Disparador { get; set; }
        public string? DisparadorDescripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateRiesgoDto
    {
        [Required]
        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Identificador { get; set; }

        [StringLength(50)]
        public string? Tipo { get; set; }

        [StringLength(50)]
        public string? Categoria { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        [StringLength(255)]
        public string? DescripcionRiesgo { get; set; }

        [StringLength(50)]
        public string? Objetivo { get; set; }

        [StringLength(50)]
        public string? Fase { get; set; }

        [StringLength(200)]
        public string? Causa { get; set; }

        [StringLength(200)]
        public string? Efecto { get; set; }

        [StringLength(100)]
        public string? Disparador { get; set; }

        [StringLength(100)]
        public string? DisparadorDescripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [Required]
        public long DebidaDiligenciaId { get; set; }

        [Required]
        public long ClienteId { get; set; }
    }
}
