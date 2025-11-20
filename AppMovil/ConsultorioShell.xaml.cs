using AppMovil.ViewModels;
using AppMovil.Views;

namespace AppMovil
{
    public partial class ConsultorioShell : Shell
    {
        public ConsultorioShell()
        {
            InitializeComponent();
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Registrarse", typeof(RegistrarseView));
        }


        public void EnableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Flyout; // Habilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = true; // Muestra el menú lateral
            Shell.Current.GoToAsync("//MainPage"); // Navega a la página principal
            var viewmodel = this.BindingContext as ConsultorioShellViewModel;
            viewmodel.IsUserLogout = false;
        }
        public void DisableAppAfterLogin()
        {
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            FlyoutBehavior = FlyoutBehavior.Disabled; // Deshabilita el FlyOut
            Shell.Current.GoToAsync("//Login"); // Navega a la página de login
        }
    }
}
