using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Evaluacion
    {
        [Key]
        public long Id { get; set; }

        public long RiesgoId { get; set; }
        public long ClienteId { get; set; }

        public int? Puntaje { get; set; }
        public DateTime FechaEvaluacion { get; set; }

        // Propiedades de navegación
        [ForeignKey("RiesgoId")]
        public virtual Riesgo Riesgo { get; set; } = null!;

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;
    }