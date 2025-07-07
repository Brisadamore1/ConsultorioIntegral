using AppMovil.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.ViewModels
{
    public class IniciarSesionViewModel : ObjectNotification
    {
        public IniciarSesionViewModel()
        {
            IniciarSesionCommand = new Command(IniciarSesion, PermitirIniciarSesion);
        }

        private bool PermitirIniciarSesion(object arg)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void IniciarSesion(object obj)
        {
           App.Current.MainPage.DisplayAlert("Iniciar Sesión", "Iniciar sesión con " + Email + " y contraseña " + Password, "Aceptar"); 
        }

        private string email;
		public string Email
		{
			get { return email; }
			set { email = value;
				OnPropertyChanged();
			}
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value;
				OnPropertyChanged();
			}
		}

		private bool rememberpassword;
		public bool Rememberpassword
        {
			get { return rememberpassword; }
			set { rememberpassword = value;
				OnPropertyChanged();
			}
		}

		public Command IniciarSesionCommand { get; }
        public Command RegistrarseCommand { get; }
    }
}
