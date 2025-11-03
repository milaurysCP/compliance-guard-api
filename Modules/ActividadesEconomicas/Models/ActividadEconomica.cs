using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.Models
{
    public class ActividadEconomica
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        public string? Proveedor { get; set; }

        [StringLength(50)]
        public string? PrincipalCliente { get; set; }

        [StringLength(50)]
        public string? CampoLaboral { get; set; }

        [StringLength(50)]
        public string? Proyecto { get; set; }

        [StringLength(50)]
        public string? Inscripciones { get; set; }

        [StringLength(100)]
        public string? OrigenFondos { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}
