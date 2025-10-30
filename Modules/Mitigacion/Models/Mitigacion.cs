using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Riesgos.Models;

namespace ComplianceGuardPro.Modules.Mitigacion.Models
{
    public class Mitigacion
    {
        [Key]
        public long Id { get; set; }

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

        // Propiedad de navegación: Una mitigación pertenece a un riesgo
        [ForeignKey("RiesgoId")]
        public virtual Riesgo Riesgo { get; set; } = null!;
    }
}