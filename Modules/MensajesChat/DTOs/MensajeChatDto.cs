using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.MensajesChat.DTOs
{
    public class MensajeChatDto
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? UsuarioNombre { get; set; }
    }

    public class CreateMensajeChatDto
    {
        [Required]
        public long UsuarioId { get; set; }

        [Required]
        [StringLength(500)]
        public required string Mensaje { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; }
    }
}