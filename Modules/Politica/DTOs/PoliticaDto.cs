using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Politica.DTOs
{
    public class PoliticaDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CreatePoliticaDto
    {
        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}