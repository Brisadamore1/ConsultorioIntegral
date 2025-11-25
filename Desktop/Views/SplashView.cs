using Microsoft.Reporting.WinForms;
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

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;

        public SplashView()
        {
            InitializeComponent();
        }

        private async void SplashView_Activated(object sender, EventArgs e)
        {
            var conectarDbTask = ConectarConDb();
            var imprimirReporteTask = ImprimirReporte();
            await Task.WhenAll(conectarDbTask, imprimirReporteTask);
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (progressBar.Value < 97)
                progressBar.Value += 3;
            if (dataReady && printReady)
            {
                timer.Enabled = false;
                this.Visible = false;
                var menuPrincipalView = new MenuPrincipalView();
                menuPrincipalView.ShowDialog();
                this.Close();
            }
        }

        private async Task ImprimirReporte()
        {
            await Task.Run(() =>
            {

                ReportViewer reporte = new ReportViewer();
                reporte.LocalReport.ReportEmbeddedResource = "Desktop.Reports.PacientesReport.rdlc";
                var pacientes = new List<Paciente> { new Paciente() { Id = 1, Nombre = "Natalia Sosa", Dni = "44785214", FechaNacimiento= DateTime.Now, Email= "sosanatalia@gmail.com", Telefono= "3498484865" } };
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSPacientes", pacientes));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
                printReady = true;

            });

        }

        private async Task ConectarConDb()
        {
            await Task.Run(async () =>
            {

                GenericService<Profesional> profesionalService = new GenericService<Profesional>();
                var profesionales = await profesionalService.GetAllAsync(string.Empty);
                dataReady = true;
            });
        } 
    }
}
