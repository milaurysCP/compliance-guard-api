using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string UsuarioLogin { get; set; } // Renombrado para evitar conflicto con el nombre de la clase

    [Required]
    [StringLength(255)]
    public required string ClaveHash { get; set; }

    [StringLength(255)]
    public string? Token { get; set; }

    public long RolId { get; set; }
    public bool EstaActivo { get; set; } = false;

    // Propiedades de navegación
    [ForeignKey("RolId")]
    public virtual Rol Rol { get; set; } = null!;


    public virtual ICollection<ProgresoCapacitacion> ProgresosCapacitacion { get; set; } = new List<ProgresoCapacitacion>();
    public virtual ICollection<MensajeChat> MensajesChat { get; set; } = new List<MensajeChat>();
}
