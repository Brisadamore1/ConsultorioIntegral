using Microsoft.Reporting.WinForms;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class ProfesionalesViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<Profesional> profesionalService = new GenericService<Profesional>();

        // Modelo plano para coincidir con el DataSet del RDLC (DSProfesionales)
        private class ProfesionalReportItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Profesion { get; set; } = string.Empty;
            public string? Especialidad { get; set; } = string.Empty;
            public string Matricula { get; set; } = string.Empty;
            public string Telefono { get; set; } = string.Empty;
        }

        public ProfesionalesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();
            reporte.Dock = DockStyle.Fill;
            reporte.ProcessingMode = ProcessingMode.Local;
            Controls.Add(reporte);
        }

        private async void ProfesionalesViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                reporte.LocalReport.DataSources.Clear();
                using (var stream = typeof(ProfesionalesViewReport).Assembly.GetManifestResourceStream("Desktop.Reports.ProfesionalesReport.rdlc"))
                {
                    if (stream == null)
                        throw new InvalidOperationException("No se encontró el recurso embebido 'Desktop.Reports.ProfesionalesReport.rdlc'. Verifique Build Action = EmbeddedResource y el nombre correcto.");
                    reporte.LocalReport.LoadReportDefinition(stream);
                }

                var profesionales = await profesionalService.GetAllAsync(string.Empty);
                var items = profesionales?.Select(p => new ProfesionalReportItem
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Profesion = p.Profesion,
                    Especialidad = string.IsNullOrWhiteSpace(p.Especialidad) ? "Sin asignar" : p.Especialidad,
                    Matricula = p.Matricula,
                    Telefono = p.Telefono
                }).ToList();

                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSProfesionales", items));
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
