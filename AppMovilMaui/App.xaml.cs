using Microsoft.Maui.Controls;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ConsultorioShell();
        }
    }
}
