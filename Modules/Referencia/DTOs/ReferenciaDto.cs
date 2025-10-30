using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Referencia.DTOs
{
    public class ReferenciaDto
    {
        public long Id { get; set; }
        public string? Recomendacion { get; set; }
        public string? Descripcion { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateReferenciaDto
    {
        [Required]
        public long ClienteId { get; set; }

        [StringLength(200)]
        public string? Recomendacion { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }
    }
}