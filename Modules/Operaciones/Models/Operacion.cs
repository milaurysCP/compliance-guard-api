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

        public string? Tipo { get; set; }

        public string? Codigo { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        // Propiedad de navegación: Una operación puede tener muchos pagos
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
