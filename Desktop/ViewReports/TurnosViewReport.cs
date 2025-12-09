using Microsoft.Reporting.WinForms;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class TurnosViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<Turno> turnoService = new GenericService<Turno>();

        private class TurnoReportItem
        {
            public int Id { get; set; }
            public string Profesional { get; set; } = string.Empty;
            public string Paciente { get; set; } = string.Empty;
            public string FechaHora { get; set; } = string.Empty;
            public string Duracion { get; set; } = string.Empty;
            public string Estado { get; set; } = string.Empty;
        }

        public TurnosViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();
            reporte.Dock = DockStyle.Fill;
            reporte.ProcessingMode = ProcessingMode.Local;
            Controls.Add(reporte);
            this.Load += TurnosViewReport_Load;
        }

        private async void TurnosViewReport_Load(object? sender, EventArgs e)
        {
            try
            {
                reporte.LocalReport.DataSources.Clear();
                using (var stream = typeof(TurnosViewReport).Assembly.GetManifestResourceStream("Desktop.Reports.TurnosReport.rdlc"))
                {
                    if (stream == null)
                        throw new InvalidOperationException("No se encontró el recurso embebido 'Desktop.Reports.TurnosReport.rdlc'. Verifique Build Action = EmbeddedResource y el nombre correcto.");
                    reporte.LocalReport.LoadReportDefinition(stream);
                }

                var turnos = await turnoService.GetAllAsync(string.Empty);
                var items = (turnos ?? new List<Turno>()).Select(t => new TurnoReportItem
                {
                    Id = t.Id,
                    Profesional = t.Profesional != null && !string.IsNullOrWhiteSpace(t.Profesional.Nombre) ? t.Profesional.Nombre : "Sin asignar",
                    Paciente = t.Paciente != null && !string.IsNullOrWhiteSpace(t.Paciente.Nombre) ? t.Paciente.Nombre : "Sin asignar",
                    FechaHora = (t.FechaHora != DateTime.MinValue && t.FechaHora.Year > 1900) ? t.FechaHora.ToString("dd/MM/yyyy HH:mm") : "Sin asignar",
                    Duracion = t.DuracionMinutos.ToString(),
                    Estado = System.Enum.GetName(typeof(Service.Enums.EstadoTurnoEnum), t.EstadoTurno) ?? t.EstadoTurno.ToString()
                }).ToList();

                // Asegurar que la lista nunca sea nula para el reporte
                items = items ?? new List<TurnoReportItem>();

                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSTurnos", items));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
