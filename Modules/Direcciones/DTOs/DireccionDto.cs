using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Direcciones.DTOs;

public class DireccionDto
    {
        public long Id { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Sector { get; set; }
        public string? Municipio { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
    }

    public class CreateDireccionDto
    {
        [Required]
        [StringLength(200)]
        public string? Calle { get; set; }
        [Required]
        [StringLength(20)]
        public string? Numero { get; set; }
        [StringLength(100)]
        public string? Sector { get; set; }
        [Required]
        [StringLength(100)]
        public string? Municipio { get; set; }
        [Required]
        [StringLength(100)]
        public string? Provincia { get; set; }
        [Required]
        [StringLength(100)]
        public string? Pais { get; set; }
    }
