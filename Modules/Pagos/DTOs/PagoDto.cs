using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Pagos.DTOs
{
    public class PagoDto
    {
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public string? Moneda { get; set; }
        public decimal? Monto { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreatePagoDto
    {
        [Required]
        [StringLength(50)]
        public string? Tipo { get; set; }

        [Required]
        [StringLength(10)]
        public string? Moneda { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required]
        public long OperacionId { get; set; }

        [Required]
        public long ClienteId { get; set; }
    }
}