using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Riesgos.Models;
using ComplianceGuardPro.Modules.Documentos.Models;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.Models
{
    public class DebidaDiligencia
    {

        [Key]
        public long Id { get; set; }

        // --- SUJETO OBLIGADO ---
        public string? SujetoNombre { get; set; }
        public string? SujetoIdentificacion { get; set; }
        public string? SujetoListas { get; set; }
        public string? SujetoOtraInformacion { get; set; }

        // --- CAMPOS DEL FORM ---
        public string? TipoPersona { get; set; }
        public string? Jurisdiccion { get; set; }
        public string? RiesgoProducto { get; set; }
        public string? SectorEconomico { get; set; }
        public string? CampoLaboral { get; set; }
        public string? OrigenesRecurso { get; set; }
        public string? NivelIngreso { get; set; }
        public string? Fuente { get; set; }
        public string? TipoPago { get; set; }
        public string? TipoMoneda { get; set; }
        public string? TipoPeps { get; set; }
        public string? CargoPeps { get; set; }
        public string? InstitucionPeps { get; set; }
        public string? Consulta { get; set; }
        public string? RelacionTerceros { get; set; }
        public string? Actividad { get; set; }
        public string? Pais { get; set; }
        public string? Canal { get; set; }

        [StringLength(1000)]
        public string? Observaciones { get; set; }

        // --- RIESGO CALCULADO POR EL FRONT ---
        public int PuntajeRiesgo { get; set; }        // nivelRiesgo.porcentaje
        public string NivelRiesgo { get; set; } = ""; // nivelRiesgo.nivel

        public string TipoDiligencia { get; set; } = ""; // Simplificada/Ampliada/Reforzada

        // --- METADATOS ---
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // --- Relaciones ---
        public long? ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }

        public virtual ICollection<Riesgo> Riesgos { get; set; } = new List<Riesgo>();
        public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
    }
}
