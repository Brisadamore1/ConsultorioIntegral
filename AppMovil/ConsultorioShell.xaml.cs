using AppMovil.ViewModels;
using AppMovil.Views;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace AppMovil
{
    public partial class ConsultorioShell : Shell
    {
        public ConsultorioShell()
        {
            InitializeComponent();
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            RegisterRoutes();

            // Si el shell fue inicializado y el viewmodel indica que el usuario está logout,
            // forzamos la navegación inicial a la página de Login para que el usuario vea
            // la pantalla de inicio de sesión en lugar de ir al primer FlyoutItem.
            if (BindingContext is ConsultorioShellViewModel vm && vm.IsUserLogout)
            {
                Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        await Shell.Current.GoToAsync("//Login");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[Shell] Initial navigation to Login failed: {ex}");
                    }
                });
            }

            Navigating += (s, e) =>
            {
                Debug.WriteLine($"[Shell] Navigating: From='{e.Current?.Location}' To='{e.Target.Location}' Source='{e.Source}'");
                if (e.Target.Location.OriginalString.EndsWith("/Login") || e.Target.Location.OriginalString == "//Login")
                {
                    if (BindingContext is ConsultorioShellViewModel vm)
                        vm.OnLoginScreenRequested();
                }
            };
            Navigated += (s, e) =>
            {
                Debug.WriteLine($"[Shell] Navigated: Current='{e.Current?.Location}' Previous='{e.Previous?.Location}'");
            };
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Registrarse", typeof(RegistrarseView));
        }


        public void EnableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Flyout; // Habilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = true; // Muestra el menú lateral

            try
            {
                _ = Shell.Current.GoToAsync("//nuestra_app/MainPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Shell] Navigation error (EnableAppAfterLogin): {ex}");
            }

            if (BindingContext is ConsultorioShellViewModel viewmodel)
                viewmodel.OnLoggedIn();
        }

        public void DisableAppAfterLogin()
        {
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            FlyoutBehavior = FlyoutBehavior.Disabled; // Deshabilita el FlyOut

            try
            {
                _ = Shell.Current.GoToAsync("//Login");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Shell] Navigation error (DisableAppAfterLogin): {ex}");
            }
        }
    }
}
