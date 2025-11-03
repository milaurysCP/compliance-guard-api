using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Documentos.DTOs
{
    public class DocumentoDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? RutaArchivo { get; set; }
        public string? Descripcion { get; set; }
        public bool Verificado { get; set; }
        public DateTime FechaSubida { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateDocumentoDto
    {
        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; }

        [StringLength(500)]
        public string? RutaArchivo { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        public bool Verificado { get; set; } = false;

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        [Required]
        public long DebidaDiligenciaId { get; set; }

        [Required]
        public long ClienteId { get; set; }
    }
}