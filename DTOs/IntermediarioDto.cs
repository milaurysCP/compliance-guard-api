using System.ComponentModel.DataAnnotations;

public class IntermediarioDto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public long ClienteId { get; set; }
}

public class CreateIntermediarioDto
{
    [Required]
    [StringLength(200)]
    public string? Nombre { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
