using System.Collections.Generic;
using System.Threading.Tasks;
using ComplianceGuardPro.Modules.Reportes.DTOs;

namespace ComplianceGuardPro.Modules.Reportes.Services
{
    public interface IReportes
    {
        Task<DashboardDto> GetDashboardDataAsync();
        Task<List<ClienteReporteDto>> GetClientesDataAsync();
        Task<List<RiesgoReporteDto>> GetRiesgosDataAsync();
        Task<DebidaDiligenciaReporteDto?> GetDebidaDiligenciaDataAsync(long id);

        Task<byte[]> GenerateDashboardPdfAsync(DashboardDto data);
        Task<byte[]> GenerateClientesPdfAsync(List<ClienteReporteDto> data);
        Task<byte[]> GenerateRiesgosPdfAsync(List<RiesgoReporteDto> data);
        Task<byte[]> GenerateDebidaDiligenciaPdfAsync(DebidaDiligenciaReporteDto data);

        Task<byte[]> GenerateDashboardExcelAsync(DashboardDto data);
        Task<byte[]> GenerateClientesExcelAsync(List<ClienteReporteDto> data);
        Task<byte[]> GenerateRiesgosExcelAsync(List<RiesgoReporteDto> data);
        Task<byte[]> GenerateDebidaDiligenciaExcelAsync(DebidaDiligenciaReporteDto data);
    }
}