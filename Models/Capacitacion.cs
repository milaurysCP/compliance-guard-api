using System.ComponentModel.DataAnnotations;

public class Capacitacion
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Titulo { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
        
        // Propiedad de navegación: Una capacitación puede tener muchos progresos de usuarios
        public virtual ICollection<ProgresoCapacitacion> Progresos { get; set; } = new List<ProgresoCapacitacion>();
    }