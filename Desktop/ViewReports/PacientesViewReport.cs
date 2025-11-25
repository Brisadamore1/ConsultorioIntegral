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
        public PacientesViewReport()
        {
            InitializeComponent();
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;
            
            Controls.Add(reporte);
        }

        private async void PacientesViewReport_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "Desktop.Reports.PacientesReport.rdlc";
            var pacientes = await pacienteService.GetAllAsync(string.Empty);
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSPacientes", pacientes));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.RefreshReport();
        }
    }
}
