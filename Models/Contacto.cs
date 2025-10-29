using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contacto
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string? Tipo { get; set; } // Teléfono / Móvil / Correo

    [StringLength(200)]
    public string? Valor { get; set; }

    public long ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public virtual Cliente Cliente { get; set; } = null!;
}
