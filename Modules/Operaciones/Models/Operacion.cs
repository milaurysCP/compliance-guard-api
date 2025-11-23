using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Pagos.Models;

namespace ComplianceGuardPro.Modules.Operaciones.Models
{
    public class Operacion
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? TipoOperacion { get; set; }

        [StringLength(200)]
        public string? EndidadFinanciera { get; set; }

        [StringLength(50)]
        public string? CodigoOperacion { get; set; }

        [StringLength(500)]
        public string? DescripcionOperacion { get; set; }

        [StringLength(500)]
        public string? PropositoOperacion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        // Campos legacy
        public string? Tipo { get; set; }

        public string? Codigo { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        // Propiedad de navegación: Una operación puede tener muchos pagos
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
