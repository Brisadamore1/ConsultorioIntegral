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
    public partial class ContactosEmergenciaViewReport : Form
    {
        ReportViewer reporte;
        IGenericService<ContactoEmergencia> contactoService = new GenericService<ContactoEmergencia>();

        // Modelo plano para coincidir con el DataSet del RDLC (DSContactosEmergencia)
        private class ContactoEmergenciaReportItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Relacion { get; set; } = string.Empty;
            public string Paciente { get; set; } = string.Empty;
            public string Telefono { get; set; } = string.Empty;
        }

        public ContactosEmergenciaViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();
            reporte.Dock = DockStyle.Fill;
            reporte.ProcessingMode = ProcessingMode.Local;
            Controls.Add(reporte);
            this.Load += ContactosEmergenciaViewReportcs_Load;
        }

        private async void ContactosEmergenciaViewReportcs_Load(object? sender, EventArgs e)
        {
            try
            {
                reporte.LocalReport.DataSources.Clear();
                using (var stream = typeof(ContactosEmergenciaViewReport).Assembly.GetManifestResourceStream("Desktop.Reports.ContactosEmergenciaReport.rdlc"))
                {
                    if (stream == null)
                        throw new InvalidOperationException("No se encontró el recurso embebido 'Desktop.Reports.ContactosEmergenciaReport.rdlc'. Verifique Build Action = EmbeddedResource y el nombre correcto.");
                    reporte.LocalReport.LoadReportDefinition(stream);
                }

                var contactos = await contactoService.GetAllAsync(string.Empty);
                var items = contactos?.Select(c => new ContactoEmergenciaReportItem
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Relacion = c.Relacion,
                    Paciente = c.Paciente != null && !string.IsNullOrWhiteSpace(c.Paciente.Nombre) ? c.Paciente.Nombre : "Sin asignar",
                    Telefono = c.Telefono
                }).ToList();

                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSContactosEmergencia", items));
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
