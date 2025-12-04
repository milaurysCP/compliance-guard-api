using System.ComponentModel.DataAnnotations;
using ComplianceGuardPro.Modules.Clientes.DTOs;

namespace ComplianceGuardPro.Modules.DebidaDiligencia.DTOs
{
    public class DebidaDiligenciaDto
    {
        public long Id { get; set; }
        
        // Sujeto Obligado
        public string? SujetoNombre { get; set; }
        public string? SujetoIdentificacion { get; set; }
        public string? SujetoListas { get; set; }
        public string? SujetoOtraInformacion { get; set; }
        
        // Campos del Form
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
        public string? Observaciones { get; set; }
        
        // Riesgo calculado
        public int PuntajeRiesgo { get; set; }
        public string NivelRiesgo { get; set; } = "";
        public string TipoDiligencia { get; set; } = "";
        
        // Metadatos
        public DateTime FechaRegistro { get; set; }
        
        // Relaciones
        public long? ClienteId { get; set; }
        public ClienteDto? Cliente { get; set; }
    }

    public class CreateDebidaDiligenciaDto
    {
        // Sujeto Obligado
        public string? SujetoNombre { get; set; }
        public string? SujetoIdentificacion { get; set; }
        public string? SujetoListas { get; set; }
        public string? SujetoOtraInformacion { get; set; }
        
        // Campos del Form
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
        
        // Riesgo calculado por el front
        public int PuntajeRiesgo { get; set; }
        public string NivelRiesgo { get; set; } = "";
        public string TipoDiligencia { get; set; } = "";
        
        // Relaciones
        public long? ClienteId { get; set; }
    }
}