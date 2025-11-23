using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    // ============================================
    // DATOS BÁSICOS
    // ============================================
    [StringLength(200)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? TipoPersona { get; set; } // Persona Natural / Jurídica

    [StringLength(50)]
    public string? Siglas { get; set; }

    [StringLength(50)]
    public string? DocumentoIdentidad { get; set; }

    public DateTime? FechaCreacion { get; set; }

    [StringLength(50)]
    public string? Rnc { get; set; }

    [StringLength(100)]
    public string? RegistroMercantil { get; set; }

    [StringLength(200)]
    public string? CasaMatriz { get; set; }

    // ============================================
    // PROPIEDADES DE NAVEGACIÓN
    // ============================================
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