using System.ComponentModel.DataAnnotations;

public class Riesgo
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [StringLength(255)]
        public string? Mitigacion { get; set; }

        public DateTime FechaCreacion { get; set; }
        
        // Propiedad de navegación: Un riesgo puede estar en muchas evaluaciones
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }