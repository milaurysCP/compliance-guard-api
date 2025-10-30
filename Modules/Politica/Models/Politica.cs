using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Politica.Models
{
    public class Politica
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public string? Nombre { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}