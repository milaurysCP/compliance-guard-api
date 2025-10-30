using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.Referencia.Models
{
    public class Referencia
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Recomendacion { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}