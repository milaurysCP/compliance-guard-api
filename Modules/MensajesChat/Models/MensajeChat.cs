using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Usuarios.Models;

namespace ComplianceGuardPro.Modules.MensajesChat.Models
{
    public class MensajeChat
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UsuarioId { get; set; }

        [Required]
        [StringLength(500)]
        public required string Mensaje { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; }

        // Propiedad de navegación: Un mensaje pertenece a un usuario
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }
}