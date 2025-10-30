using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Responsable.DTOs
{
    public class ResponsableDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public string? Correo { get; set; }
        public string? DocumentoIdentificacion { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateResponsableDto
    {
        [Required]
        public long ClienteId { get; set; }

        [StringLength(100)]
        public string? Nombre { get; set; }

        [StringLength(100)]
        public string? Apellido { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(50)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        public string? Cargo { get; set; }

        [StringLength(150)]
        public string? Correo { get; set; }

        [StringLength(100)]
        public string? DocumentoIdentificacion { get; set; }
    }
}