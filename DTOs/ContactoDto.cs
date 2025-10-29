using System.ComponentModel.DataAnnotations;

public class ContactoDto
{
    public long Id { get; set; }
    public string? Tipo { get; set; } // Teléfono / Móvil / Correo
    public string? Valor { get; set; }
}

public class CreateContactoDto
{
    [Required]
    [StringLength(50)]
    public string? Tipo { get; set; } // Teléfono / Móvil / Correo

    [Required]
    [StringLength(200)]
    public string? Valor { get; set; }
}
