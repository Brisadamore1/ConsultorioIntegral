using Desktop.Views;

namespace Desktop
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void menuSalirDelSistema_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
