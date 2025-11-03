using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs
{
    public class PerfilFinancieroDto
{
    public long Id { get; set; }
    public decimal? NivelIngreso { get; set; }
    public string? Fuente { get; set; }
    public long ClienteId { get; set; }
}

public class CreatePerfilFinancieroDto
{
    [Required]
    public decimal? NivelIngreso { get; set; }

    [Required]
    [StringLength(200)]
    public string? Fuente { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
}
