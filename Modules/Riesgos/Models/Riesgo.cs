using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ComplianceGuardPro.Modules.Mitigacion.Models;
using ComplianceGuardPro.Modules.Evaluaciones.Models;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;

namespace ComplianceGuardPro.Modules.Riesgos.Models
{
    public class Riesgo
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Identificador { get; set; }

        [StringLength(50)]
        public string? Tipo { get; set; }

        [StringLength(50)]
        public string? Categoria { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        [StringLength(255)]
        public string? DescripcionRiesgo { get; set; }

        [StringLength(50)]
        public string? Objetivo { get; set; }

        [StringLength(50)]
        public string? Fase { get; set; }

        [StringLength(200)]
        public string? Causa { get; set; }

        [StringLength(200)]
        public string? Efecto { get; set; }

        [StringLength(100)]
        public string? Disparador { get; set; }

        [StringLength(100)]
        public string? DisparadorDescripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public long DebidaDiligenciaId { get; set; }

        [ForeignKey("DebidaDiligenciaId")]
        public virtual ComplianceGuardPro.Modules.DebidaDiligencia.Models.DebidaDiligencia DebidaDiligencia { get; set; } = null!;
        
        // Propiedad de navegación: Un riesgo puede estar en muchas evaluaciones
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

        // Propiedad de navegación: Un riesgo puede tener muchas mitigaciones
        public virtual ICollection<ComplianceGuardPro.Modules.Mitigacion.Models.Mitigacion> Mitigaciones { get; set; } = new List<ComplianceGuardPro.Modules.Mitigacion.Models.Mitigacion>();
    }
}