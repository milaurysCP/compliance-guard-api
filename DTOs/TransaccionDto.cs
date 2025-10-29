using System.ComponentModel.DataAnnotations;

public class TransaccionDto
{
    public long Id { get; set; }
    public string? Tipo { get; set; }
    public string? InstitucionFinanciera { get; set; }
    public string? Descripcion { get; set; }
    public string? PropositoProducto { get; set; }
    public string? FormaDeposito { get; set; }
    public string? FormaExpectativa { get; set; }
    public long ClienteId { get; set; }
}

public class CreateTransaccionDto
{
    [Required]
    [StringLength(100)]
    public string? Tipo { get; set; }

    [StringLength(200)]
    public string? InstitucionFinanciera { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [StringLength(200)]
    public string? PropositoProducto { get; set; }

    [StringLength(100)]
    public string? FormaDeposito { get; set; }

    [StringLength(100)]
    public string? FormaExpectativa { get; set; }

    [Required]
    public long ClienteId { get; set; }
}
