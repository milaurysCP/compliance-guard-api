using System.ComponentModel.DataAnnotations;

public class PerfilFinancieroDto
{
    public long Id { get; set; }
    public string? NivelIngreso { get; set; }
    public string? Fuente { get; set; }
}

public class CreatePerfilFinancieroDto
{
    [Required]
    [StringLength(100)]
    public string? NivelIngreso { get; set; }

    [Required]
    [StringLength(200)]
    public string? Fuente { get; set; }
}
