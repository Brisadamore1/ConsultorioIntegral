using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppMovil.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.ViewModels
{
    public partial class ConsultorioShellViewModel : ObservableObject
    {
        public IRelayCommand LogoutCommand { get; }

        [ObservableProperty]
        private bool isUserLogout=true;

        public ConsultorioShellViewModel() 
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Logout()
        {
            IsUserLogout = true; // señalamos que el usuario pidió sesión
            (App.Current.MainPage as ConsultorioShell).DisableAppAfterLogin();
        }

        public void OnLoginScreenRequested()
        {
            // llamado desde navegación a Login para evitar autologin
            IsUserLogout = true;
        }

        public void OnLoggedIn()
        {
            IsUserLogout = false;
        }
    }
}
