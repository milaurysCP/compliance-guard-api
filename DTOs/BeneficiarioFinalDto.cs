using System.ComponentModel.DataAnnotations;

public class BeneficiarioFinalDto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public long ClienteId { get; set; }
}

public class CreateBeneficiarioFinalDto
{
    [Required]
    [StringLength(200)]
    public string? Nombre { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
