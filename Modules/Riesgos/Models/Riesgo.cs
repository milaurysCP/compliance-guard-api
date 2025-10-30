using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ComplianceGuardPro.Modules.Mitigacion.Models;
using ComplianceGuardPro.Modules.Evaluaciones.Models;

namespace ComplianceGuardPro.Modules.Riesgos.Models
{
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

        // Propiedad de navegación: Un riesgo puede tener muchas mitigaciones
        public virtual ICollection<ComplianceGuardPro.Modules.Mitigacion.Models.Mitigacion> Mitigaciones { get; set; } = new List<ComplianceGuardPro.Modules.Mitigacion.Models.Mitigacion>();
    }
}