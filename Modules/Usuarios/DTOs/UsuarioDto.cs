using System.ComponentModel.DataAnnotations;
using ComplianceGuardPro.Modules.MensajesChat.DTOs;

namespace ComplianceGuardPro.Modules.Usuarios.DTOs;

public class UsuarioDto
{
    public long Id { get; set; }
    public required string UsuarioLogin { get; set; }
    public long RolId { get; set; }
    public string? NombreRol { get; set; } 
    public bool EstaActivo { get; set; }
    // Propiedad aplanada para conveniencia del cliente
}

public class CreateUsuarioDto
{
    [Required]
    [StringLength(100)]
    public required string UsuarioLogin { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La clave debe tener al menos 8 caracteres.")]
    public required string Clave { get; set; } // Recibimos la clave en texto plano, el hash se hace en el backend.

    [Required]
    public long RolId { get; set; }
}

public class UpdateUsuarioDto
{

    [Required]
    public long RolId { get; set; }
}

public class UpdatePasswordDto
{
    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La clave debe tener al menos 8 caracteres.")]
    public required string NuevaClave { get; set; } // Recibimos la clave en texto plano, el hash se hace en el backend.
}

public class CambiarEstadoDto
{
    [Required]
    public bool EstaActivo { get; set; }
}

public class LoginDto
{
    [Required]
    public required string UsuarioLogin { get; set; }

    [Required]
    public required string Clave { get; set; } // Recibimos la clave en texto plano, el hash se hace en el backend.
}


public class LoginResponseDto
{
    public string Token { get; set; } = null!;
    public UsuarioDto Usuario { get; set; } = null!;
}

public class DetalleUsuarioDto
{
    public long Id { get; set; }
    public required string UsuarioLogin { get; set; }
    public long RolId { get; set; }
    public string? NombreRol { get; set; }
    public bool EstaActivo { get; set; }

    public virtual ICollection<MensajeChatDto> MensajeChat { get; set; } = new List<MensajeChatDto>();

}