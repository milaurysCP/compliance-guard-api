using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Riesgos.Models;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.Evaluaciones.Models
{
    public class Evaluacion
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long RiesgoId { get; set; }

        [Required]
        public long ClienteId { get; set; }

        public int? Puntaje { get; set; }

        [Required]
        public DateTime FechaEvaluacion { get; set; }

        [StringLength(100)]
        public string? UsuarioEvaluador { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }

        // Propiedades de navegación
        [ForeignKey("RiesgoId")]
        public virtual Riesgo Riesgo { get; set; } = null!;

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}