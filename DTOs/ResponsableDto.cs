using System.ComponentModel.DataAnnotations;

public class ResponsableDto
{
    public long Id { get; set; }
    [Required]
    [StringLength(200)]
    public string? Nombre { get; set; }
    [Required]
    [StringLength(200)]
    public string? Apellido { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [StringLength(20)]
    public string? Telefono { get; set; }
    [Required]
    public long ClienteId { get; set; }
}

public class CreateResponsableDto
{
    [Required]
    [StringLength(200)]
    public string? Nombre { get; set; }
    [Required]
    [StringLength(200)]
    public string? Apellido { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [StringLength(20)]
    public string? Telefono { get; set; }
    [Required]
    public long ClienteId { get; set; }
}
