using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Usuarios.Models;

namespace ComplianceGuardPro.Modules.ProgresoCapacitacion.Models
{
    public class ProgresoCapacitacion
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UsuarioId { get; set; }

        [Required]
        public long CapacitacionId { get; set; }

        [Range(0, 100)]
        public decimal ProgresoPorcentaje { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaCompletado { get; set; }

        [Range(0, 100)]
        public int? Calificacion { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        [ForeignKey("CapacitacionId")]
        public virtual ComplianceGuardPro.Modules.Capacitacion.Models.Capacitacion Capacitacion { get; set; } = null!;
    }
}