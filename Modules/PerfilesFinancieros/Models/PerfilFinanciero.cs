using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.Models
{
    public class PerfilFinanciero
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Ningreso { get; set; }

        [StringLength(200)]
        public string? Fuentes { get; set; }

        // Campo legacy
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NivelIngreso { get; set; }

        [StringLength(200)]
        public string? Fuente { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}
