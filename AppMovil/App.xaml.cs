using AppMovil.Views;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            int pacienteId = 1; // Aquí puedes establecer el ID del paciente que deseas cargar
            MainPage = new PerfilView(pacienteId); 
        }
    }
}
