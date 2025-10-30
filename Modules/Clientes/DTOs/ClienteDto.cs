using System.ComponentModel.DataAnnotations;
using ComplianceGuardPro.Modules.Direcciones.DTOs;
using ComplianceGuardPro.Modules.Contactos.DTOs;
using ComplianceGuardPro.Modules.Beneficiarios.DTOs;
using ComplianceGuardPro.Modules.Intermediarios.DTOs;
using ComplianceGuardPro.Modules.ActividadesEconomicas.DTOs;
using ComplianceGuardPro.Modules.PerfilesFinancieros.DTOs;

namespace ComplianceGuardPro.Modules.Clientes.DTOs;

// DTO para mostrar en una lista (ligero)
    public class ClienteSummaryDto
    {
        public long Id { get; set; }
        public required string TipoCliente { get; set; }
        public required string Nombre { get; set; }
        public string? DocumentoIdentidad { get; set; }
    }

    // DTO para mostrar el detalle completo de un cliente
    public class ClienteDetailDto
    {
        public long Id { get; set; }
        public required string TipoCliente { get; set; }
        public required string Nombre { get; set; }
        public string? Url { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? RegistroComercial { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        // Incluimos listas de DTOs relacionados
        public ICollection<DireccionDto> Direcciones { get; set; } = new List<DireccionDto>();
        public ICollection<ContactoDto> Contactos { get; set; } = new List<ContactoDto>();
    }
    
    // DTO para crear un cliente
    public class CreateClienteDto
    {
        [Required]
        [StringLength(50)]
        public required string TipoCliente { get; set; }

        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(50)]
        public string? DocumentoIdentidad { get; set; }

        // Se pueden añadir DTOs anidados para crear entidades relacionadas al mismo tiempo
        public List<CreateDireccionDto>? Direcciones { get; set; }
        public List<CreateContactoDto>? Contactos { get; set; }
    }

    // DTO para actualizar un cliente
    public class UpdateClienteDto
    {
        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(255)]
        public string? Url { get; set; }
    }