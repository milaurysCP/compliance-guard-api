using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs
{
    public class ActividadEconomicaDto
{
    public long Id { get; set; }
    public string? Tipo { get; set; }
    public string? Descripcion { get; set; }
}

public class CreateActividadEconomicaDto
{
    [Required]
    [StringLength(100)]
    public string? Tipo { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }
}
}
