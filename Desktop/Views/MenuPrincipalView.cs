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
    }
}
