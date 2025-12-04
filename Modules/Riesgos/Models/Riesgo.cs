using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Riesgos.Models
{
    public class Riesgo
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }
        
        public int? Frecuencia { get; set; }
        
        [StringLength(50)]
        public string? Nivel { get; set; }
        
        public int? Impacto { get; set; }
    }
}