using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProgresoCapacitacion
    {
        [Key]
        public long Id { get; set; }

        public long CapacitacionId { get; set; }
        public long UsuarioId { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        [Range(0, 100)]
        public int Progreso { get; set; }

        public DateTime? FechaCompletado { get; set; }

        // Propiedades de navegación
        [ForeignKey("CapacitacionId")]
        public virtual Capacitacion Capacitacion { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }