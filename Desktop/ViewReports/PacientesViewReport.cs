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
    public partial class PacientesViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<Paciente> pacienteService = new GenericService<Paciente>();
        IGenericService<Profesional> profesionalService = new GenericService<Profesional>();
        // Modelo plano para coincidir con el DataSet del RDLC (DSPacientes)
        private class PacienteReportItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Dni { get; set; } = string.Empty;
            public DateTime FechaNacimiento { get; set; }
            public string? Email { get; set; }
            public string Telefono { get; set; } = string.Empty;
            public string? Profesional { get; set; }
        }
        public PacientesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;
            reporte.ProcessingMode = ProcessingMode.Local;
            
            Controls.Add(reporte);
        }

        private async void PacientesViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                reporte.LocalReport.DataSources.Clear();
                using (var stream = typeof(PacientesViewReport).Assembly.GetManifestResourceStream("Desktop.Reports.PacientesReport.rdlc"))
                {
                    if (stream == null)
                        throw new InvalidOperationException("No se encontró el recurso embebido 'Desktop.Reports.PacientesReport.rdlc'. Verifique Build Action = EmbeddedResource y el nombre correcto.");
                    reporte.LocalReport.LoadReportDefinition(stream);
                }
                var pacientes = await pacienteService.GetAllAsync(string.Empty);
                var pacientesForReport = pacientes?.Select(p => new PacienteReportItem
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Dni = p.Dni,
                    FechaNacimiento = p.FechaNacimiento,
                    Email = p.Email,
                    Telefono = p.Telefono,
                    Profesional = p.Profesional != null ? p.Profesional.Nombre : null
                }).ToList();

                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSPacientes", pacientesForReport));
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
