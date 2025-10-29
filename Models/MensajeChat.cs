using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MensajeChat
    {
        [Key]
        public long Id { get; set; }

        public long UsuarioId { get; set; }

        [StringLength(500)]
        public string? Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }