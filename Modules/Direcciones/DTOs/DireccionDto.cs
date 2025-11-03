using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Direcciones.DTOs;

public class DireccionDto
    {
        public long Id { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Sector { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? CodigoPostal { get; set; }
        public long ClienteId { get; set; }
    }

    public class CreateDireccionDto
    {
        [Required]
        [StringLength(200)]
        public string? Calle { get; set; }
        [StringLength(20)]
        public string? Numero { get; set; }
        [StringLength(100)]
        public string? Sector { get; set; }
        [Required]
        [StringLength(100)]
        public string? Ciudad { get; set; }
        [Required]
        [StringLength(100)]
        public string? Estado { get; set; }
        [Required]
        [StringLength(100)]
        public string? Pais { get; set; }
        [StringLength(20)]
        public string? CodigoPostal { get; set; }
        [Required]
        public long ClienteId { get; set; }
    }
