using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Riesgos.DTOs
{
    public class RiesgoDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public int? Frecuencia { get; set; }
        public string? Nivel { get; set; }
        public int? Impacto { get; set; }
    }

    public class CreateRiesgoDto
    {
        [StringLength(200)]
        public string? Nombre { get; set; }

        public int? Frecuencia { get; set; }

        [StringLength(50)]
        public string? Nivel { get; set; }

        public int? Impacto { get; set; }
    }
}
