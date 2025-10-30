using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Reportes.DTOs;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace ComplianceGuardPro.Modules.Reportes.Services
{
    public class ReportesImpl : IReportes
    {
        private readonly AppDbContext _context;
        private readonly IConverter _pdfConverter;

        public ReportesImpl(AppDbContext context, IConverter pdfConverter)
        {
            _context = context;
            _pdfConverter = pdfConverter;
        }

        public async Task<DashboardDto> GetDashboardDataAsync()
        {
            var dashboard = new DashboardDto();

            // Totales básicos
            dashboard.TotalClientes = await _context.Clientes.CountAsync();
            dashboard.TotalOperaciones = await _context.Operaciones.CountAsync();
            dashboard.TotalRiesgosAltos = await _context.Riesgos.CountAsync();
            dashboard.TotalDebidaDiligenciaPendiente = await _context.DebidaDiligencias.CountAsync();

            // Monto total de operaciones (asumiendo que no hay propiedad Monto, usar 0 por ahora)
            dashboard.MontoTotalOperaciones = 0;

            // Estadísticas mensuales (últimos 6 meses) - simplificado
            dashboard.EstadisticasMensuales = new List<EstadisticaMensualDto>();

            return dashboard;
        }

        public async Task<byte[]> GenerateClientesReportAsync(string format = "pdf")
        {
            var clientes = await GetClientesDataAsync();

            if (format.ToLower() == "pdf")
            {
                return GenerateClientesPdf(clientes);
            }

            throw new NotSupportedException($"Formato {format} no soportado");
        }

        public async Task<byte[]> GenerateRiesgosReportAsync(string format = "pdf")
        {
            var riesgos = await GetRiesgosDataAsync();

            if (format.ToLower() == "pdf")
            {
                return GenerateRiesgosPdf(riesgos);
            }

            throw new NotSupportedException($"Formato {format} no soportado");
        }

        public async Task<byte[]> GenerateDebidaDiligenciaReportAsync(long id, string format = "pdf")
        {
            var debidaDiligencia = await GetDebidaDiligenciaDataAsync(id);

            if (debidaDiligencia == null)
            {
                throw new KeyNotFoundException($"Debida diligencia con ID {id} no encontrada");
            }

            if (format.ToLower() == "pdf")
            {
                return GenerateDebidaDiligenciaPdf(debidaDiligencia);
            }

            throw new NotSupportedException($"Formato {format} no soportado");
        }

        public async Task<List<ClienteReporteDto>> GetClientesDataAsync()
        {
            return await _context.Clientes
                .Include(c => c.Operaciones)
                .ThenInclude(o => o.Pagos)
                .Where(c => c.EstaActivo)
                .Select(c => new ClienteReporteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    TipoCliente = c.TipoCliente,
                    Estado = c.Estado,
                    FechaRegistro = c.FechaRegistro,
                    TotalOperaciones = c.Operaciones.Count,
                    MontoTotalOperaciones = c.Operaciones.SelectMany(o => o.Pagos).Sum(p => p.Monto.GetValueOrDefault()),
                    NivelRiesgo = "Medio" // TODO: Calcular nivel de riesgo basado en evaluaciones
                })
                .ToListAsync();
        }

        public async Task<List<RiesgoReporteDto>> GetRiesgosDataAsync()
        {
            var riesgos = await _context.Riesgos
                .Include(r => r.Cliente)
                .Include(r => r.Mitigaciones)
                .ToListAsync();

            return riesgos.Select(r => new RiesgoReporteDto
            {
                Id = r.Id,
                Descripcion = r.Descripcion,
                Nivel = r.Nivel,
                Estado = r.Estado,
                ClienteNombre = r.Cliente?.Nombre ?? "N/A",
                Mitigacion = r.Mitigaciones.FirstOrDefault()?.Accion ?? "Sin mitigación",
                FechaIdentificacion = r.FechaCreacion,
                FechaMitigacion = r.Mitigaciones.FirstOrDefault()?.FechaCierre
            }).ToList();
        }

        public async Task<DebidaDiligenciaReporteDto?> GetDebidaDiligenciaDataAsync(long id)
        {
            var dd = await _context.DebidaDiligencias
                .Include(dd => dd.Cliente)
                .Include(dd => dd.Responsable)
                .Include(dd => dd.Riesgos)
                .Include(dd => dd.Documentos)
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (dd == null) return null;

            return new DebidaDiligenciaReporteDto
            {
                Id = dd.Id,
                ClienteNombre = dd.Cliente?.Nombre,
                Estado = dd.Estado,
                FechaInicio = dd.FechaInicio,
                FechaCompletado = dd.FechaFin,
                Responsable = dd.Responsable?.Nombre,
                Documentos = dd.Documentos.Select(d => new DocumentoDto
                {
                    Tipo = d.Tipo,
                    Nombre = d.Nombre,
                    Verificado = d.Verificado
                }).ToList(),
                Evaluaciones = new List<EvaluacionDto>(), // TODO: Agregar relación con Evaluaciones
                Referencias = new List<ReferenciaDto>(), // TODO: Agregar relación con Referencias
                Conclusion = dd.Conclusion ?? dd.Observaciones
            };
        }

        private byte[] GenerateClientesPdf(List<ClienteReporteDto> clientes)
        {
            var html = GenerateClientesHtml(clientes);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _pdfConverter.Convert(doc);
        }

        private byte[] GenerateRiesgosPdf(List<RiesgoReporteDto> riesgos)
        {
            var html = GenerateRiesgosHtml(riesgos);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _pdfConverter.Convert(doc);
        }

        private byte[] GenerateDebidaDiligenciaPdf(DebidaDiligenciaReporteDto dd)
        {
            var html = GenerateDebidaDiligenciaHtml(dd);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _pdfConverter.Convert(doc);
        }

        private string GenerateClientesHtml(List<ClienteReporteDto> clientes)
        {
            var html = @"
            <html>
            <head>
                <style>
                    body { font-family: Arial, sans-serif; margin: 20px; }
                    h1 { color: #333; text-align: center; }
                    table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                    th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                    th { background-color: #f2f2f2; font-weight: bold; }
                    tr:nth-child(even) { background-color: #f9f9f9; }
                </style>
            </head>
            <body>
                <h1>Reporte de Clientes</h1>
                <p>Fecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + @"</p>
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nombre</th>
                            <th>Tipo</th>
                            <th>Estado</th>
                            <th>Fecha Registro</th>
                            <th>Total Operaciones</th>
                            <th>Monto Total</th>
                            <th>Nivel Riesgo</th>
                        </tr>
                    </thead>
                    <tbody>";

            foreach (var cliente in clientes)
            {
                html += $@"
                        <tr>
                            <td>{cliente.Id}</td>
                            <td>{cliente.Nombre}</td>
                            <td>{cliente.TipoCliente}</td>
                            <td>{cliente.Estado}</td>
                            <td>{cliente.FechaRegistro:dd/MM/yyyy}</td>
                            <td>{cliente.TotalOperaciones}</td>
                            <td>${cliente.MontoTotalOperaciones:N2}</td>
                            <td>{cliente.NivelRiesgo}</td>
                        </tr>";
            }

            html += @"
                    </tbody>
                </table>
            </body>
            </html>";

            return html;
        }

        private string GenerateRiesgosHtml(List<RiesgoReporteDto> riesgos)
        {
            var html = @"
            <html>
            <head>
                <style>
                    body { font-family: Arial, sans-serif; margin: 20px; }
                    h1 { color: #333; text-align: center; }
                    table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                    th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                    th { background-color: #f2f2f2; font-weight: bold; }
                    tr:nth-child(even) { background-color: #f9f9f9; }
                </style>
            </head>
            <body>
                <h1>Reporte de Riesgos</h1>
                <p>Fecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + @"</p>
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Descripción</th>
                            <th>Nivel</th>
                            <th>Estado</th>
                            <th>Cliente</th>
                            <th>Mitigación</th>
                            <th>Fecha Identificación</th>
                            <th>Fecha Mitigación</th>
                        </tr>
                    </thead>
                    <tbody>";

            foreach (var riesgo in riesgos)
            {
                html += $@"
                        <tr>
                            <td>{riesgo.Id}</td>
                            <td>{riesgo.Descripcion}</td>
                            <td>{riesgo.Nivel}</td>
                            <td>{riesgo.Estado}</td>
                            <td>{riesgo.ClienteNombre}</td>
                            <td>{riesgo.Mitigacion}</td>
                            <td>{riesgo.FechaIdentificacion:dd/MM/yyyy}</td>
                            <td>{riesgo.FechaMitigacion?.ToString("dd/MM/yyyy") ?? "N/A"}</td>
                        </tr>";
            }

            html += @"
                    </tbody>
                </table>
            </body>
            </html>";

            return html;
        }

        private string GenerateDebidaDiligenciaHtml(DebidaDiligenciaReporteDto dd)
        {
            var html = $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; margin: 20px; }}
                    h1 {{ color: #333; text-align: center; }}
                    h2 {{ color: #666; margin-top: 30px; }}
                    .section {{ margin-bottom: 20px; }}
                    table {{ width: 100%; border-collapse: collapse; margin-top: 10px; }}
                    th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
                    th {{ background-color: #f2f2f2; font-weight: bold; }}
                    tr:nth-child(even) {{ background-color: #f9f9f9; }}
                </style>
            </head>
            <body>
                <h1>Informe de Debida Diligencia</h1>
                <p><strong>Cliente:</strong> {dd.ClienteNombre}</p>
                <p><strong>Estado:</strong> {dd.Estado}</p>
                <p><strong>Fecha Inicio:</strong> {dd.FechaInicio:dd/MM/yyyy}</p>
                <p><strong>Fecha Completado:</strong> {dd.FechaCompletado?.ToString("dd/MM/yyyy") ?? "En proceso"}</p>
                <p><strong>Responsable:</strong> {dd.Responsable}</p>
                <p><strong>Fecha de generación:</strong> {DateTime.Now:dd/MM/yyyy HH:mm}</p>

                <div class='section'>
                    <h2>Evaluaciones Realizadas</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>Tipo</th>
                                <th>Resultado</th>
                                <th>Fecha</th>
                            </tr>
                        </thead>
                        <tbody>";

            foreach (var evaluacion in dd.Evaluaciones)
            {
                html += $@"
                            <tr>
                                <td>{evaluacion.Tipo}</td>
                                <td>{evaluacion.Resultado}</td>
                                <td>{evaluacion.FechaEvaluacion:dd/MM/yyyy}</td>
                            </tr>";
            }

            html += @"
                        </tbody>
                    </table>
                </div>

                <div class='section'>
                    <h2>Referencias Verificadas</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>Tipo</th>
                                <th>Nombre</th>
                                <th>Contacto</th>
                                <th>Verificada</th>
                            </tr>
                        </thead>
                        <tbody>";

            foreach (var referencia in dd.Referencias)
            {
                html += $@"
                            <tr>
                                <td>{referencia.Tipo}</td>
                                <td>{referencia.Nombre}</td>
                                <td>{referencia.Contacto}</td>
                                <td>{(referencia.Verificada ? "Sí" : "No")}</td>
                            </tr>";
            }

            html += $@"
                        </tbody>
                    </table>
                </div>

                <div class='section'>
                    <h2>Conclusión</h2>
                    <p>{dd.Conclusion ?? "Pendiente de conclusión"}</p>
                </div>
            </body>
            </html>";

            return html;
        }

        public async Task<byte[]> GenerateDashboardPdfAsync(DashboardDto data)
        {
            var html = $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; margin: 20px; }}
                    h1 {{ color: #333; text-align: center; }}
                    .metric {{ background: #f5f5f5; padding: 20px; margin: 15px 0; border-radius: 8px; text-align: center; }}
                    .metric h3 {{ margin: 0 0 10px 0; color: #007bff; }}
                    .metric p {{ margin: 0; font-size: 32px; font-weight: bold; color: #333; }}
                </style>
            </head>
            <body>
                <h1>Dashboard - Compliance Guard Pro</h1>
                <p style='text-align: center;'>Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}</p>

                <div class='metric'>
                    <h3>Total de Clientes</h3>
                    <p>{data.TotalClientes}</p>
                </div>

                <div class='metric'>
                    <h3>Total de Operaciones</h3>
                    <p>{data.TotalOperaciones}</p>
                </div>

                <div class='metric'>
                    <h3>Riesgos de Alto Nivel</h3>
                    <p>{data.TotalRiesgosAltos}</p>
                </div>

                <div class='metric'>
                    <h3>Debida Diligencia Pendiente</h3>
                    <p>{data.TotalDebidaDiligenciaPendiente}</p>
                </div>
            </body>
            </html>";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _pdfConverter.Convert(doc);
        }

        public async Task<byte[]> GenerateClientesPdfAsync(List<ClienteReporteDto> data)
        {
            return await Task.FromResult(GenerateClientesPdf(data));
        }

        public async Task<byte[]> GenerateRiesgosPdfAsync(List<RiesgoReporteDto> data)
        {
            return await Task.FromResult(GenerateRiesgosPdf(data));
        }

        public async Task<byte[]> GenerateDebidaDiligenciaPdfAsync(DebidaDiligenciaReporteDto data)
        {
            return await Task.FromResult(GenerateDebidaDiligenciaPdf(data));
        }
    }
}