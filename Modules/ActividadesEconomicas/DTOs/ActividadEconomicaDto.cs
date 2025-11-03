using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs
{
    public class ActividadEconomicaDto
{
    public long Id { get; set; }
    public string? Proveedor { get; set; }
    public string? PrincipalCliente { get; set; }
    public string? CampoLaboral { get; set; }
    public string? Proyecto { get; set; }
    public string? Inscripciones { get; set; }
    public string? OrigenFondos { get; set; }
    public long ClienteId { get; set; }
}

public class CreateActividadEconomicaDto
{
    [StringLength(50)]
    public string? Proveedor { get; set; }

    [StringLength(50)]
    public string? PrincipalCliente { get; set; }

    [StringLength(50)]
    public string? CampoLaboral { get; set; }

    [StringLength(50)]
    public string? Proyecto { get; set; }

    [StringLength(50)]
    public string? Inscripciones { get; set; }

    [StringLength(100)]
    public string? OrigenFondos { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
}
