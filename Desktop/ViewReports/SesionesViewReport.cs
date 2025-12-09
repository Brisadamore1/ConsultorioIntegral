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
    public partial class SesionesViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<Sesion> sesionService = new GenericService<Sesion>();

        private class SesionReportItem
        {
            public int Id { get; set; }
            public string Profesional { get; set; } = string.Empty;
            public string Paciente { get; set; } = string.Empty;
            public string FechaHora { get; set; } = string.Empty;
            public string Honorarios { get; set; } = string.Empty;
            // Representación legible para el reporte (Sí / No)
            public string Pagado { get; set; } = string.Empty;
            // Campo booleano adicional por si el RDLC está configurado para un checkbox
            public bool PagadoBool { get; set; }
        }

        public SesionesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();
            reporte.Dock = DockStyle.Fill;
            reporte.ProcessingMode = ProcessingMode.Local;
            Controls.Add(reporte);
            this.Load += SesionesViewReport_Load;
        }

        private async void SesionesViewReport_Load(object? sender, EventArgs e)
        {
            try
            {
                reporte.LocalReport.DataSources.Clear();
                using (var stream = typeof(SesionesViewReport).Assembly.GetManifestResourceStream("Desktop.Reports.SesionesReport.rdlc"))
                {
                    if (stream == null)
                        throw new InvalidOperationException("No se encontró el recurso embebido 'Desktop.Reports.SesionesReport.rdlc'. Verifique Build Action = EmbeddedResource y el nombre correcto.");
                    reporte.LocalReport.LoadReportDefinition(stream);
                }

                var sesiones = await sesionService.GetAllAsync(string.Empty);
                var items = (sesiones ?? new List<Sesion>()).Select(s => new SesionReportItem
                {
                    Id = s.Id,
                    Profesional = !string.IsNullOrWhiteSpace(s.ProfesionalNombre) ? s.ProfesionalNombre! : "Sin asignar",
                    Paciente = !string.IsNullOrWhiteSpace(s.PacienteNombre) ? s.PacienteNombre! : "Sin asignar",
                    FechaHora = !string.IsNullOrWhiteSpace(s.FechaHoraTurno) ? s.FechaHoraTurno! : "Sin asignar",
                    // Formatear honorarios como número entero 
                    Honorarios = s.Honorarios.ToString("N0", new System.Globalization.CultureInfo("es-ES")),
                    Pagado = s.Pagado ? "Sí" : "No",
                    PagadoBool = s.Pagado
                }).ToList();

                // Asegurar que la lista nunca sea nula para el reporte
                items = items ?? new List<SesionReportItem>();

                // Nombre del DataSet en el .rdlc: "DSSesiones" (ajustar si tu .rdlc usa otro)
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSSesiones", items));
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
