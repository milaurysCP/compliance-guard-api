using Microsoft.AspNetCore.Mvc;
using ComplianceGuardPro.Modules.Reportes.DTOs;
using ComplianceGuardPro.Modules.Reportes.Services;
using ComplianceGuardPro.Shared.Authorization;

namespace ComplianceGuardPro.Modules.Reportes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly IReportes _reportesService;

        public ReportesController(IReportes reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpGet("dashboard")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetDashboardReport()
        {
            try
            {
                var reportData = await _reportesService.GetDashboardDataAsync();
                var pdfBytes = await _reportesService.GenerateDashboardPdfAsync(reportData);
                return File(pdfBytes, "application/pdf", "dashboard-report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte de dashboard: {ex.Message}");
            }
        }

        [HttpGet("clientes")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetClientesReport()
        {
            try
            {
                var reportData = await _reportesService.GetClientesDataAsync();
                var pdfBytes = await _reportesService.GenerateClientesPdfAsync(reportData);
                return File(pdfBytes, "application/pdf", "clientes-report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte de clientes: {ex.Message}");
            }
        }

        [HttpGet("riesgos")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetRiesgosReport()
        {
            try
            {
                var reportData = await _reportesService.GetRiesgosDataAsync();
                var pdfBytes = await _reportesService.GenerateRiesgosPdfAsync(reportData);
                return File(pdfBytes, "application/pdf", "riesgos-report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte de riesgos: {ex.Message}");
            }
        }

        [HttpGet("debida-diligencia/{id}")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetDebidaDiligenciaReport(long id)
        {
            try
            {
                var reportData = await _reportesService.GetDebidaDiligenciaDataAsync(id);
                if (reportData == null)
                {
                    return NotFound($"Debida diligencia con ID {id} no encontrada");
                }

                var pdfBytes = await _reportesService.GenerateDebidaDiligenciaPdfAsync(reportData);
                return File(pdfBytes, "application/pdf", $"debida-diligencia-{id}-report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte de debida diligencia: {ex.Message}");
            }
        }

        [HttpGet("dashboard/excel")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetDashboardReportExcel()
        {
            try
            {
                var reportData = await _reportesService.GetDashboardDataAsync();
                var excelBytes = await _reportesService.GenerateDashboardExcelAsync(reportData);
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dashboard-report.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte Excel de dashboard: {ex.Message}");
            }
        }

        [HttpGet("clientes/excel")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetClientesReportExcel()
        {
            try
            {
                var reportData = await _reportesService.GetClientesDataAsync();
                var excelBytes = await _reportesService.GenerateClientesExcelAsync(reportData);
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "clientes-report.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte Excel de clientes: {ex.Message}");
            }
        }

        [HttpGet("riesgos/excel")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetRiesgosReportExcel()
        {
            try
            {
                var reportData = await _reportesService.GetRiesgosDataAsync();
                var excelBytes = await _reportesService.GenerateRiesgosExcelAsync(reportData);
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "riesgos-report.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte Excel de riesgos: {ex.Message}");
            }
        }

        [HttpGet("debida-diligencia/{id}/excel")]
        [RoleAuthorize(Roles.OFICIAL_CUMPLIMIENTO, Roles.ANALISTA, Roles.TECNICO, Roles.OFICIAL_SUPLENTE)]
        public async Task<IActionResult> GetDebidaDiligenciaReportExcel(long id)
        {
            try
            {
                var reportData = await _reportesService.GetDebidaDiligenciaDataAsync(id);
                if (reportData == null)
                {
                    return NotFound($"Debida diligencia con ID {id} no encontrada");
                }

                var excelBytes = await _reportesService.GenerateDebidaDiligenciaExcelAsync(reportData);
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"debida-diligencia-{id}-report.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generando reporte Excel de debida diligencia: {ex.Message}");
            }
        }
    }
}
