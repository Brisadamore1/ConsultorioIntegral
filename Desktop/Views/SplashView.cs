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
            try
            {
                var conectarDbTask = ConectarConDb();
                var imprimirReporteTask = ImprimirReporte();
                await Task.WhenAll(conectarDbTask, imprimirReporteTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en SplashView: " + ex.Message);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (progressBar.Value < 97)
                progressBar.Value += 3;
            if (dataReady && printReady)
            {
                timer.Enabled = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async Task ImprimirReporte()
        {
            // Simula una tarea de carga, pero NO crees ReportViewer aquí
            await Task.Delay(500); // o el tiempo que quieras simular
            printReady = true;
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
