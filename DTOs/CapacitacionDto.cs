using System.ComponentModel.DataAnnotations;

public class CapacitacionDto
{
    public long Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int CantidadProgresos { get; set; }
}

public class CreateCapacitacionDto
{
    [Required]
    [StringLength(200)]
    public string? Titulo { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Required]
    public DateTime FechaCreacion { get; set; }
}
