using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PerfilFinanciero
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? NivelIngreso { get; set; }

        [StringLength(200)]
        public string? Fuente { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }