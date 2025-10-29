using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaccion
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; }

        [StringLength(200)]
        public string? InstitucionFinanciera { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [StringLength(200)]
        public string? PropositoProducto { get; set; }

        [StringLength(100)]
        public string? FormaDeposito { get; set; }

        [StringLength(100)]
        public string? FormaExpectativa { get; set; }

        public long ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }