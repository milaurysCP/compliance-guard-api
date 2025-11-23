using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models
{
    public class PersonaExpuestaPoliticamente
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? CargoPeps { get; set; }

        [StringLength(100)]
        public string? TipoPeps { get; set; }

        [StringLength(200)]
        public string? NombrePeps { get; set; }

        [StringLength(100)]
        public string? Decreto { get; set; }

        [StringLength(200)]
        public string? InstitucionPeps { get; set; }

        // Campos legacy
        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(100)]
        public string? Cargo { get; set; }

        [StringLength(100)]
        public string? Ordenanza { get; set; }

        [StringLength(200)]
        public string? Institucion { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }
}