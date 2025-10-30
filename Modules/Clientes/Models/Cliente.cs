using System.ComponentModel.DataAnnotations;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Intermediarios.Models;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;
using ComplianceGuardPro.Modules.Operaciones.Models;
using ComplianceGuardPro.Modules.Transacciones.Models;
using ComplianceGuardPro.Modules.Evaluaciones.Models;

namespace ComplianceGuardPro.Modules.Clientes.Models;

public class Cliente
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string TipoCliente { get; set; } // Persona / Empresa

        [Required]
        [StringLength(200)]
        public required string Nombre { get; set; }

        [StringLength(255)]
        public string? Url { get; set; }

        [StringLength(50)]
        public string? DocumentoIdentidad { get; set; }

        [StringLength(100)]
        public string? RegistroComercial { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public bool EstaActivo { get; set; } = true;

        [StringLength(50)]
        public string? Estado { get; set; } = "Activo";

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Propiedades de navegación para todas las tablas relacionadas
        public virtual ICollection<BeneficiarioFinal> BeneficiariosFinales { get; set; } = new List<BeneficiarioFinal>();
        public virtual ICollection<Intermediario> Intermediarios { get; set; } = new List<Intermediario>();
        public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
        public virtual ICollection<ActividadEconomica> ActividadesEconomicas { get; set; } = new List<ActividadEconomica>();
        public virtual ICollection<PerfilFinanciero> PerfilesFinancieros { get; set; } = new List<PerfilFinanciero>();
        public virtual ICollection<Operacion> Operaciones { get; set; } = new List<Operacion>();
        public virtual ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
        public virtual ICollection<ComplianceGuardPro.Modules.Referencia.Models.Referencia> Referencias { get; set; } = new List<ComplianceGuardPro.Modules.Referencia.Models.Referencia>();
        public virtual ICollection<ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models.PersonaExpuestaPoliticamente> PersonasExpuestasPoliticamente { get; set; } = new List<ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models.PersonaExpuestaPoliticamente>();
        public virtual ICollection<ComplianceGuardPro.Modules.Responsable.Models.Responsable> Responsables { get; set; } = new List<ComplianceGuardPro.Modules.Responsable.Models.Responsable>();
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }