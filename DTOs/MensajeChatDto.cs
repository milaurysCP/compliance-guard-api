
using System.ComponentModel.DataAnnotations;

public class MensajeChatDto
{
    public long Id { get; set; }
    [Required]
    public long UsuarioId { get; set; }
    [Required]
    [StringLength(1000)]
    public string? Mensaje { get; set; }
    public DateTime FechaEnvio { get; set; }
    [StringLength(50)]
    public string? TipoMensaje { get; set; }
}

public class CreateMensajeChatDto
{
    [Required]
    public long UsuarioId { get; set; }
    [Required]
    [StringLength(1000)]
    public string? Mensaje { get; set; }
    [StringLength(50)]
    public string? TipoMensaje { get; set; }
}