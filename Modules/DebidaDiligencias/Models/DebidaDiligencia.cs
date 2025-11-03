using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Riesgos.Models;
using ComplianceGuardPro.Modules.Responsable.Models;
using ComplianceGuardPro.Modules.Documentos.Models;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Models
{
    public class DebidaDiligencia
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Titulo { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; } // En Progreso, Completada, Cancelada

        [StringLength(1000)]
        public string? Observaciones { get; set; }

        [StringLength(1000)]
        public string? Conclusion { get; set; }

        public long ClienteId { get; set; }

        public long? ResponsableId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        [ForeignKey("ResponsableId")]
        public virtual ComplianceGuardPro.Modules.Responsable.Models.Responsable? Responsable { get; set; }

        // Propiedad de navegación: Una debida diligencia puede tener muchos riesgos
        public virtual ICollection<Riesgo> Riesgos { get; set; } = new List<Riesgo>();

        // Propiedad de navegación: Una debida diligencia puede tener muchos documentos
        public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
    }
}