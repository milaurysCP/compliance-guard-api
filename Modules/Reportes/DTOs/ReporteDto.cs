using System.ComponentModel.DataAnnotations;

namespace ComplianceGuardPro.Modules.Reportes.DTOs
{
    public class DashboardDto
    {
        public int TotalClientes { get; set; }
        public int TotalOperaciones { get; set; }
        public int TotalRiesgosAltos { get; set; }
        public int TotalDebidaDiligenciaPendiente { get; set; }
        public decimal MontoTotalOperaciones { get; set; }
        public List<EstadisticaMensualDto> EstadisticasMensuales { get; set; } = new();
    }

    public class EstadisticaMensualDto
    {
        public string Mes { get; set; } = string.Empty;
        public int ClientesNuevos { get; set; }
        public int OperacionesRealizadas { get; set; }
        public decimal MontoOperaciones { get; set; }
    }

    public class ClienteReporteDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoPersona { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int TotalOperaciones { get; set; }
        public decimal MontoTotalOperaciones { get; set; }
        public string? NivelRiesgo { get; set; }
    }

    public class RiesgoReporteDto
    {
        public long Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Nivel { get; set; }
        public string? Estado { get; set; }
        public string? ClienteNombre { get; set; }
        public string? Mitigacion { get; set; }
        public DateTime FechaIdentificacion { get; set; }
        public DateTime? FechaMitigacion { get; set; }
    }

    public class DebidaDiligenciaReporteDto
    {
        public long Id { get; set; }
        public string? ClienteNombre { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaCompletado { get; set; }
        public string? Responsable { get; set; }
        public List<DocumentoDto> Documentos { get; set; } = new();
        public List<EvaluacionDto> Evaluaciones { get; set; } = new();
        public List<ReferenciaDto> Referencias { get; set; } = new();
        public string? Conclusion { get; set; }
    }

    public class DocumentoDto
    {
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public bool Verificado { get; set; }
    }

    public class EvaluacionDto
    {
        public string? Tipo { get; set; }
        public string? Resultado { get; set; }
        public DateTime FechaEvaluacion { get; set; }
    }

    public class ReferenciaDto
    {
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        public bool Verificada { get; set; }
    }
}