using System.ComponentModel.DataAnnotations;

public class RolDto
{
    public long Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(500)]
    public string? Descripcion { get; set; }
}

public class CreateRolDto
{
    [Required]
    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(500)]
    public string? Descripcion { get; set; }
}
