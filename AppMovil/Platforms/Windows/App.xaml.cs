using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppMovil.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            // Manejador global de excepciones para evitar que la app se detenga
            Microsoft.UI.Xaml.Application.Current.UnhandledException += (sender, e) =>
            {
                // Puedes registrar el error si lo deseas: e.Message, e.Exception
                e.Handled = true; // Evita que la app se cierre o se detenga la depuración
            };
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
