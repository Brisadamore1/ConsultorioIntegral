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
                // Registra el error y evita cierre/JIT; en Windows algunas excepciones de inicio pueden emerger como Win32
                System.Diagnostics.Debug.WriteLine($"UnhandledException: {e.Message} - {e.Exception}");
                e.Handled = true; // forzar manejo para que no aparezca el cuadro de JIT
            };

            // Captura excepciones no observadas de tareas para evitar cierre/JIT
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                e.SetObserved();
            };
            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                // No interrumpir, solo dejar trazas si fuera necesario
            };
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
