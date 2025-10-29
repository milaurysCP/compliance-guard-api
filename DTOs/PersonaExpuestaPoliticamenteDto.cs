using System.ComponentModel.DataAnnotations;

public class PersonaExpuestaPoliticamenteDto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Cargo { get; set; }
    public string? Ordenanza { get; set; }
    public string? Institucion { get; set; }
    public long ClienteId { get; set; }
}

public class CreatePersonaExpuestaPoliticamenteDto
{
    [Required]
    [StringLength(200)]
    public string? Nombre { get; set; }

    [Required]
    [StringLength(100)]
    public string? Cargo { get; set; }

    [StringLength(100)]
    public string? Ordenanza { get; set; }

    [StringLength(200)]
    public string? Institucion { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
