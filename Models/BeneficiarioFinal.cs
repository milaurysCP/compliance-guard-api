using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 public class BeneficiarioFinal
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }