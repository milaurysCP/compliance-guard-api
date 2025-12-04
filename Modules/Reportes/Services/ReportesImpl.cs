using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Reportes.DTOs;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ComplianceGuardPro.Modules.Reportes.Services
{
    public class ReportesImpl : IReportes
    {
        private readonly AppDbContext _context;

        public ReportesImpl(AppDbContext context)
        {
            _context = context;
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
                .Select(c => new ClienteReporteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    TipoPersona = c.TipoPersona,
                    FechaCreacion = c.FechaCreacion,
                    TotalOperaciones = c.Operaciones.Count,
                    MontoTotalOperaciones = c.Operaciones.SelectMany(o => o.Pagos).Sum(p => p.Monto),
                    NivelRiesgo = "Medio" // TODO: Calcular nivel de riesgo basado en evaluaciones
                })
                .ToListAsync();
        }

        public async Task<List<RiesgoReporteDto>> GetRiesgosDataAsync()
        {
            var riesgos = await _context.Riesgos
                .ToListAsync();

            return riesgos.Select(r => new RiesgoReporteDto
            {
                Id = r.Id,
                Descripcion = r.Nombre,
                Nivel = r.Nivel,
                Estado = "Activo",
                ClienteNombre = "N/A",
                Mitigacion = "Sin mitigación",
                FechaIdentificacion = DateTime.Now,
                FechaMitigacion = null
            }).ToList();
        }

        public async Task<DebidaDiligenciaReporteDto?> GetDebidaDiligenciaDataAsync(long id)
        {
            var dd = await _context.DebidaDiligencias
                .Include(dd => dd.Cliente)
                .Include(dd => dd.Riesgos)
                .Include(dd => dd.Documentos)
                .FirstOrDefaultAsync(dd => dd.Id == id);

            if (dd == null) return null;

            return new DebidaDiligenciaReporteDto
            {
                Id = dd.Id,
                ClienteNombre = dd.Cliente?.Nombre,
                Estado = dd.TipoDiligencia,
                FechaInicio = dd.FechaRegistro,
                FechaCompletado = null,
                Responsable = "N/A",
                Documentos = dd.Documentos.Select(d => new DocumentoDto
                {
                    Tipo = d.Tipo,
                    Nombre = d.Nombre,
                    Verificado = d.Verificado
                }).ToList(),
                Evaluaciones = new List<EvaluacionDto>(),
                Referencias = new List<ReferenciaDto>(),
                Conclusion = dd.Observaciones
            };
        }

        private byte[] GenerateClientesPdf(List<ClienteReporteDto> clientes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph("Reporte de Clientes", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Fecha de generación
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var date = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont);
                date.Alignment = Element.ALIGN_CENTER;
                document.Add(date);
                document.Add(new Paragraph("\n"));

                // Crear tabla
                var table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10, 25, 15, 15, 15, 15, 15, 15 });

                // Headers
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                table.AddCell(new PdfPCell(new Phrase("ID", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Nombre", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Tipo Persona", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Fecha Creación", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Total Operaciones", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Monto Total", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Nivel Riesgo", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                // Data
                var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (var cliente in clientes)
                {
                    table.AddCell(new Phrase(cliente.Id.ToString(), dataFont));
                    table.AddCell(new Phrase(cliente.Nombre ?? "", dataFont));
                    table.AddCell(new Phrase(cliente.TipoPersona ?? "", dataFont));
                    table.AddCell(new Phrase(cliente.FechaCreacion?.ToString("dd/MM/yyyy") ?? "", dataFont));
                    table.AddCell(new Phrase(cliente.TotalOperaciones.ToString(), dataFont));
                    table.AddCell(new Phrase($"${cliente.MontoTotalOperaciones:N2}", dataFont));
                    table.AddCell(new Phrase(cliente.NivelRiesgo ?? "", dataFont));
                }

                document.Add(table);
                document.Close();

                return memoryStream.ToArray();
            }
        }

        private byte[] GenerateRiesgosPdf(List<RiesgoReporteDto> riesgos)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph("Reporte de Riesgos", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Fecha de generación
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var date = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont);
                date.Alignment = Element.ALIGN_CENTER;
                document.Add(date);
                document.Add(new Paragraph("\n"));

                // Crear tabla
                var table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 8, 20, 10, 10, 15, 15, 12, 12 });

                // Headers
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                table.AddCell(new PdfPCell(new Phrase("ID", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Descripción", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Nivel", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Estado", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Cliente", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Mitigación", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Fecha Identificación", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Fecha Mitigación", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                // Data
                var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                foreach (var riesgo in riesgos)
                {
                    table.AddCell(new Phrase(riesgo.Id.ToString(), dataFont));
                    table.AddCell(new Phrase(riesgo.Descripcion, dataFont));
                    table.AddCell(new Phrase(riesgo.Nivel, dataFont));
                    table.AddCell(new Phrase(riesgo.Estado, dataFont));
                    table.AddCell(new Phrase(riesgo.ClienteNombre, dataFont));
                    table.AddCell(new Phrase(riesgo.Mitigacion, dataFont));
                    table.AddCell(new Phrase(riesgo.FechaIdentificacion.ToString("dd/MM/yyyy"), dataFont));
                    table.AddCell(new Phrase(riesgo.FechaMitigacion?.ToString("dd/MM/yyyy") ?? "N/A", dataFont));
                }

                document.Add(table);
                document.Close();

                return memoryStream.ToArray();
            }
        }

        private byte[] GenerateDebidaDiligenciaPdf(DebidaDiligenciaReporteDto dd)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                var title = new Paragraph("Informe de Debida Diligencia", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Información general
                var infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                document.Add(new Paragraph($"Cliente: {dd.ClienteNombre}", infoFont));
                document.Add(new Paragraph($"Estado: {dd.Estado}", infoFont));
                document.Add(new Paragraph($"Fecha Inicio: {dd.FechaInicio:dd/MM/yyyy}", infoFont));
                document.Add(new Paragraph($"Fecha Completado: {dd.FechaCompletado?.ToString("dd/MM/yyyy") ?? "En proceso"}", infoFont));
                document.Add(new Paragraph($"Responsable: {dd.Responsable}", infoFont));
                document.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", infoFont));
                document.Add(new Paragraph("\n"));

                // Documentos
                if (dd.Documentos.Any())
                {
                    var sectionTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    document.Add(new Paragraph("Documentos", sectionTitleFont));
                    document.Add(new Paragraph("\n"));

                    var docTable = new PdfPTable(3);
                    docTable.WidthPercentage = 100;
                    docTable.SetWidths(new float[] { 25, 50, 25 });

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    docTable.AddCell(new PdfPCell(new Phrase("Tipo", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    docTable.AddCell(new PdfPCell(new Phrase("Nombre", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    docTable.AddCell(new PdfPCell(new Phrase("Verificado", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    foreach (var doc in dd.Documentos)
                    {
                        docTable.AddCell(new Phrase(doc.Tipo, dataFont));
                        docTable.AddCell(new Phrase(doc.Nombre, dataFont));
                        docTable.AddCell(new Phrase(doc.Verificado ? "Sí" : "No", dataFont));
                    }

                    document.Add(docTable);
                    document.Add(new Paragraph("\n"));
                }

                // Evaluaciones
                if (dd.Evaluaciones.Any())
                {
                    var sectionTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    document.Add(new Paragraph("Evaluaciones Realizadas", sectionTitleFont));
                    document.Add(new Paragraph("\n"));

                    var evalTable = new PdfPTable(3);
                    evalTable.WidthPercentage = 100;
                    evalTable.SetWidths(new float[] { 30, 40, 30 });

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    evalTable.AddCell(new PdfPCell(new Phrase("Tipo", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    evalTable.AddCell(new PdfPCell(new Phrase("Resultado", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    evalTable.AddCell(new PdfPCell(new Phrase("Fecha", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    foreach (var eval in dd.Evaluaciones)
                    {
                        evalTable.AddCell(new Phrase(eval.Tipo, dataFont));
                        evalTable.AddCell(new Phrase(eval.Resultado, dataFont));
                        evalTable.AddCell(new Phrase(eval.FechaEvaluacion.ToString("dd/MM/yyyy"), dataFont));
                    }

                    document.Add(evalTable);
                    document.Add(new Paragraph("\n"));
                }

                // Referencias
                if (dd.Referencias.Any())
                {
                    var sectionTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    document.Add(new Paragraph("Referencias Verificadas", sectionTitleFont));
                    document.Add(new Paragraph("\n"));

                    var refTable = new PdfPTable(4);
                    refTable.WidthPercentage = 100;
                    refTable.SetWidths(new float[] { 20, 30, 30, 20 });

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    refTable.AddCell(new PdfPCell(new Phrase("Tipo", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    refTable.AddCell(new PdfPCell(new Phrase("Nombre", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    refTable.AddCell(new PdfPCell(new Phrase("Contacto", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    refTable.AddCell(new PdfPCell(new Phrase("Verificada", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    foreach (var refItem in dd.Referencias)
                    {
                        refTable.AddCell(new Phrase(refItem.Tipo, dataFont));
                        refTable.AddCell(new Phrase(refItem.Nombre, dataFont));
                        refTable.AddCell(new Phrase(refItem.Contacto, dataFont));
                        refTable.AddCell(new Phrase(refItem.Verificada ? "Sí" : "No", dataFont));
                    }

                    document.Add(refTable);
                    document.Add(new Paragraph("\n"));
                }

                // Conclusión
                var conclusionTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                document.Add(new Paragraph("Conclusión", conclusionTitleFont));
                document.Add(new Paragraph("\n"));
                var conclusionFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);
                document.Add(new Paragraph(dd.Conclusion ?? "Pendiente de conclusión", conclusionFont));

                document.Close();
                return memoryStream.ToArray();
            }
        }

        public Task<byte[]> GenerateDashboardPdfAsync(DashboardDto data)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                var title = new Paragraph("Dashboard - Compliance Guard Pro", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Fecha de generación
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var date = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont);
                date.Alignment = Element.ALIGN_CENTER;
                document.Add(date);
                document.Add(new Paragraph("\n\n"));

                // Crear tabla de métricas
                var table = new PdfPTable(2);
                table.WidthPercentage = 80;
                table.HorizontalAlignment = Element.ALIGN_CENTER;

                var metricFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var valueFont = FontFactory.GetFont(FontFactory.HELVETICA, 18);

                // Total de Clientes
                table.AddCell(new PdfPCell(new Phrase("Total de Clientes", metricFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(data.TotalClientes.ToString(), valueFont))
                {
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });

                // Total de Operaciones
                table.AddCell(new PdfPCell(new Phrase("Total de Operaciones", metricFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(data.TotalOperaciones.ToString(), valueFont))
                {
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });

                // Riesgos de Alto Nivel
                table.AddCell(new PdfPCell(new Phrase("Riesgos de Alto Nivel", metricFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(data.TotalRiesgosAltos.ToString(), valueFont))
                {
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });

                // Debida Diligencia Pendiente
                table.AddCell(new PdfPCell(new Phrase("Debida Diligencia Pendiente", metricFont))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(data.TotalDebidaDiligenciaPendiente.ToString(), valueFont))
                {
                    Padding = 10,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });

                document.Add(table);
                document.Close();

                return Task.FromResult(memoryStream.ToArray());
            }
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

        public async Task<byte[]> GenerateDashboardExcelAsync(DashboardDto data)
        {
            return await Task.FromResult(GenerateDashboardExcel(data));
        }

        public async Task<byte[]> GenerateClientesExcelAsync(List<ClienteReporteDto> data)
        {
            return await Task.FromResult(GenerateClientesExcel(data));
        }

        public async Task<byte[]> GenerateRiesgosExcelAsync(List<RiesgoReporteDto> data)
        {
            return await Task.FromResult(GenerateRiesgosExcel(data));
        }

        public async Task<byte[]> GenerateDebidaDiligenciaExcelAsync(DebidaDiligenciaReporteDto data)
        {
            return await Task.FromResult(GenerateDebidaDiligenciaExcel(data));
        }

        private byte[] GenerateDashboardExcel(DashboardDto data)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Dashboard");

            // Headers
            worksheet.Cell(1, 1).Value = "Métrica";
            worksheet.Cell(1, 2).Value = "Valor";
            worksheet.Cell(1, 3).Value = "Fecha de Generación";

            // Data
            worksheet.Cell(2, 1).Value = "Total de Clientes";
            worksheet.Cell(2, 2).Value = data.TotalClientes;
            worksheet.Cell(2, 3).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            worksheet.Cell(3, 1).Value = "Total de Operaciones";
            worksheet.Cell(3, 2).Value = data.TotalOperaciones;

            worksheet.Cell(4, 1).Value = "Riesgos de Alto Nivel";
            worksheet.Cell(4, 2).Value = data.TotalRiesgosAltos;

            worksheet.Cell(5, 1).Value = "Debida Diligencia Pendiente";
            worksheet.Cell(5, 2).Value = data.TotalDebidaDiligenciaPendiente;

            worksheet.Cell(6, 1).Value = "Monto Total de Operaciones";
            worksheet.Cell(6, 2).Value = data.MontoTotalOperaciones;

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private byte[] GenerateClientesExcel(List<ClienteReporteDto> clientes)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clientes");

            // Headers
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nombre";
            worksheet.Cell(1, 3).Value = "Tipo Persona";
            worksheet.Cell(1, 4).Value = "Fecha Creación";
            worksheet.Cell(1, 5).Value = "Total Operaciones";
            worksheet.Cell(1, 6).Value = "Monto Total";
            worksheet.Cell(1, 7).Value = "Nivel Riesgo";

            // Data
            for (int i = 0; i < clientes.Count; i++)
            {
                var cliente = clientes[i];
                worksheet.Cell(i + 2, 1).Value = cliente.Id;
                worksheet.Cell(i + 2, 2).Value = cliente.Nombre;
                worksheet.Cell(i + 2, 3).Value = cliente.TipoPersona;
                worksheet.Cell(i + 2, 4).Value = cliente.FechaCreacion?.ToString("dd/MM/yyyy") ?? "";
                worksheet.Cell(i + 2, 5).Value = cliente.TotalOperaciones;
                worksheet.Cell(i + 2, 6).Value = cliente.MontoTotalOperaciones;
                worksheet.Cell(i + 2, 7).Value = cliente.NivelRiesgo;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private byte[] GenerateRiesgosExcel(List<RiesgoReporteDto> riesgos)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Riesgos");

            // Headers
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Descripción";
            worksheet.Cell(1, 3).Value = "Nivel";
            worksheet.Cell(1, 4).Value = "Estado";
            worksheet.Cell(1, 5).Value = "Cliente";
            worksheet.Cell(1, 6).Value = "Mitigación";
            worksheet.Cell(1, 7).Value = "Fecha Identificación";
            worksheet.Cell(1, 8).Value = "Fecha Mitigación";

            // Data
            for (int i = 0; i < riesgos.Count; i++)
            {
                var riesgo = riesgos[i];
                worksheet.Cell(i + 2, 1).Value = riesgo.Id;
                worksheet.Cell(i + 2, 2).Value = riesgo.Descripcion;
                worksheet.Cell(i + 2, 3).Value = riesgo.Nivel;
                worksheet.Cell(i + 2, 4).Value = riesgo.Estado;
                worksheet.Cell(i + 2, 5).Value = riesgo.ClienteNombre;
                worksheet.Cell(i + 2, 6).Value = riesgo.Mitigacion;
                worksheet.Cell(i + 2, 7).Value = riesgo.FechaIdentificacion.ToString("dd/MM/yyyy");
                worksheet.Cell(i + 2, 8).Value = riesgo.FechaMitigacion?.ToString("dd/MM/yyyy") ?? "N/A";
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private byte[] GenerateDebidaDiligenciaExcel(DebidaDiligenciaReporteDto dd)
        {
            using var workbook = new XLWorkbook();

            // Información general
            var infoWorksheet = workbook.Worksheets.Add("Información General");
            infoWorksheet.Cell(1, 1).Value = "Campo";
            infoWorksheet.Cell(1, 2).Value = "Valor";

            infoWorksheet.Cell(2, 1).Value = "ID";
            infoWorksheet.Cell(2, 2).Value = dd.Id;
            infoWorksheet.Cell(3, 1).Value = "Cliente";
            infoWorksheet.Cell(3, 2).Value = dd.ClienteNombre;
            infoWorksheet.Cell(4, 1).Value = "Estado";
            infoWorksheet.Cell(4, 2).Value = dd.Estado;
            infoWorksheet.Cell(5, 1).Value = "Fecha Inicio";
            infoWorksheet.Cell(5, 2).Value = dd.FechaInicio.ToString("dd/MM/yyyy");
            infoWorksheet.Cell(6, 1).Value = "Fecha Completado";
            infoWorksheet.Cell(6, 2).Value = dd.FechaCompletado?.ToString("dd/MM/yyyy") ?? "En proceso";
            infoWorksheet.Cell(7, 1).Value = "Responsable";
            infoWorksheet.Cell(7, 2).Value = dd.Responsable;
            infoWorksheet.Cell(8, 1).Value = "Fecha de Generación";
            infoWorksheet.Cell(8, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Documentos
            var docsWorksheet = workbook.Worksheets.Add("Documentos");
            docsWorksheet.Cell(1, 1).Value = "Tipo";
            docsWorksheet.Cell(1, 2).Value = "Nombre";
            docsWorksheet.Cell(1, 3).Value = "Verificado";

            for (int i = 0; i < dd.Documentos.Count; i++)
            {
                var doc = dd.Documentos[i];
                docsWorksheet.Cell(i + 2, 1).Value = doc.Tipo;
                docsWorksheet.Cell(i + 2, 2).Value = doc.Nombre;
                docsWorksheet.Cell(i + 2, 3).Value = doc.Verificado ? "Sí" : "No";
            }

            // Evaluaciones
            var evalWorksheet = workbook.Worksheets.Add("Evaluaciones");
            evalWorksheet.Cell(1, 1).Value = "Tipo";
            evalWorksheet.Cell(1, 2).Value = "Resultado";
            evalWorksheet.Cell(1, 3).Value = "Fecha";

            for (int i = 0; i < dd.Evaluaciones.Count; i++)
            {
                var eval = dd.Evaluaciones[i];
                evalWorksheet.Cell(i + 2, 1).Value = eval.Tipo;
                evalWorksheet.Cell(i + 2, 2).Value = eval.Resultado;
                evalWorksheet.Cell(i + 2, 3).Value = eval.FechaEvaluacion.ToString("dd/MM/yyyy");
            }

            // Referencias
            var refWorksheet = workbook.Worksheets.Add("Referencias");
            refWorksheet.Cell(1, 1).Value = "Tipo";
            refWorksheet.Cell(1, 2).Value = "Nombre";
            refWorksheet.Cell(1, 3).Value = "Contacto";
            refWorksheet.Cell(1, 4).Value = "Verificada";

            for (int i = 0; i < dd.Referencias.Count; i++)
            {
                var refItem = dd.Referencias[i];
                refWorksheet.Cell(i + 2, 1).Value = refItem.Tipo;
                refWorksheet.Cell(i + 2, 2).Value = refItem.Nombre;
                refWorksheet.Cell(i + 2, 3).Value = refItem.Contacto;
                refWorksheet.Cell(i + 2, 4).Value = refItem.Verificada ? "Sí" : "No";
            }

            // Conclusión
            var conclusionWorksheet = workbook.Worksheets.Add("Conclusión");
            conclusionWorksheet.Cell(1, 1).Value = "Conclusión";
            conclusionWorksheet.Cell(2, 1).Value = dd.Conclusion ?? "Pendiente de conclusión";

            // Auto-fit columns for all worksheets
            foreach (var worksheet in workbook.Worksheets)
            {
                worksheet.Columns().AdjustToContents();
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}