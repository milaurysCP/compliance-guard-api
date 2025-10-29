using System.ComponentModel.DataAnnotations;

public class ReferenciaDto
{
    public long Id { get; set; }
    public string? Recomendacion { get; set; }
    public string? Descripcion { get; set; }
    public long ClienteId { get; set; }
}

public class CreateReferenciaDto
{
    [Required]
    [StringLength(200)]
    public string? Recomendacion { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
