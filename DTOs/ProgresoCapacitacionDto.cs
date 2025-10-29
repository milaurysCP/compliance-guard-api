using System.ComponentModel.DataAnnotations;

public class ProgresoCapacitacionDto
{
    public long Id { get; set; }
    [Required]
    public long UsuarioId { get; set; }
    [Required]
    public long CapacitacionId { get; set; }
    [Required]
    [Range(0, 100)]
    public int Progreso { get; set; }
    public DateTime FechaCompletado { get; set; }
    [StringLength(50)]
    public string? Estado { get; set; }
}

public class CreateProgresoCapacitacionDto
{
    [Required]
    public long UsuarioId { get; set; }
    [Required]
    public long CapacitacionId { get; set; }
    [Required]
    [Range(0, 100)]
    public int Progreso { get; set; }
    public DateTime? FechaCompletado { get; set; }
}
