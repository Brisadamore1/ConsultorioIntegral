using System.Runtime.Versioning;
using Desktop.Views;

namespace Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [SupportedOSPlatform("windows6.1")]
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Mostrar SplashView primero
            using (var splash = new SplashView())
            {
                if (splash.ShowDialog() != DialogResult.OK)
                {
                    // Si el splash no termina correctamente, salir de la app
                    return;
                }
            }

            // Luego mostrar IniciarSesionView
            bool loginExitoso = false;
            using (var login = new IniciarSesionView())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    loginExitoso = true;
                }
            }

            // Si el login fue exitoso, mostrar MenuPrincipalView
            if (loginExitoso)
            {
                Application.Run(new MenuPrincipalView());
            }
        }
    }
}