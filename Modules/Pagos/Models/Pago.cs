using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Operaciones.Models;

namespace ComplianceGuardPro.Modules.Pagos.Models
{
    public class Pago
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        public string? Moneda { get; set; }

        [StringLength(100)]
        public string? TipoPago { get; set; }

        [StringLength(50)]
        public string? CodigoPago { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Monto { get; set; }

        // Campos legacy
        public string? Tipo { get; set; }

        public string? Codigo { get; set; }

        public long OperacionId { get; set; }

        [ForeignKey("OperacionId")]
        public virtual Operacion Operacion { get; set; } = null!;
    }
}