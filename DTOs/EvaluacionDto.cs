using System.ComponentModel.DataAnnotations;

public class EvaluacionDto
{
    public long Id { get; set; }
    public long RiesgoId { get; set; }
    public long ClienteId { get; set; }
    public int? Puntaje { get; set; }
    public DateTime FechaEvaluacion { get; set; }
    public string? NivelRiesgo { get; set; }
}

public class CreateEvaluacionDto
{
    [Required]
    public long RiesgoId { get; set; }

    [Required]
    public long ClienteId { get; set; }

    [Range(0, 100)]
    public int? Puntaje { get; set; }

    [Required]
    public DateTime FechaEvaluacion { get; set; }
}
