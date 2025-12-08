using Desktop.ViewReports;
using Desktop.Views;
using Service.Models;
using Desktop.Helpers;

namespace Desktop
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();

            // Aplica la tabla de colores personalizada para cambiar el color de hover del menú
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomMenuColorTable());
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfesionalesView profesionalesView = new ProfesionalesView();
            profesionalesView.ShowDialog();
        }

        private void itemMenuPacientes_Click(object sender, EventArgs e)
        {
            PacientesView pacientesView = new PacientesView();
            pacientesView.ShowDialog();
        }

        private void contactosDeEmergenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactosEmergenciaView contactosEmergenciaView = new ContactosEmergenciaView();
            contactosEmergenciaView.ShowDialog();
        }

        private void itemMenuTurnos_Click(object sender, EventArgs e)
        {
            TurnosView turnosView = new TurnosView();
            turnosView.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PacientesViewReport pacientesViewReport = new PacientesViewReport();
            pacientesViewReport.ShowDialog();
        }

        private void sesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SesionesView sesionesView = new SesionesView();
            sesionesView.ShowDialog();
        }

        private void itemMenuSalirDelSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
