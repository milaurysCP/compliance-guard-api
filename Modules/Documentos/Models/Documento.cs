using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.DebidaDiligencia.Models;

namespace ComplianceGuardPro.Modules.Documentos.Models
{
    public class Documento
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; } // PDF, DOC, XLS, etc.

        [StringLength(500)]
        public string? RutaArchivo { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        public bool Verificado { get; set; } = false;

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        public long DebidaDiligenciaId { get; set; }

        [ForeignKey("DebidaDiligenciaId")]
        public virtual ComplianceGuardPro.Modules.DebidaDiligencia.Models.DebidaDiligencia DebidaDiligencia { get; set; } = null!;
    }
}