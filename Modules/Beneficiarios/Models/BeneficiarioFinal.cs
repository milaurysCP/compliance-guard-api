using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;

namespace ComplianceGuardPro.Modules.Beneficiarios.Models;

 public class BeneficiarioFinal
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(200)]
        public string? Apellidos { get; set; }

        [StringLength(50)]
        public string? Identificacion { get; set; }

        [StringLength(100)]
        public string? Nacionalidad { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }