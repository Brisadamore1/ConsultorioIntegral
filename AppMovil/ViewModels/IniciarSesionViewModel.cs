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
            //Cuando se inicializa el viewmodel, se inicializan los comandos. Se asigna a ese command y le pasas por parametros el metodo que se va a ejecutar cuando se llame al comando. El command esta conectado con un metodo. Cuando cumple las condiciones la interfaz grafica se va a encender el boton. Una interfaz reactiva.
            IniciarSesionCommand = new Command(IniciarSesion, PermitirIniciarSesion);
        }

        private bool PermitirIniciarSesion(object arg)
        {
            //Si email no esta nulo y password no esta nulo, devuelve true, si no false.
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private void IniciarSesion(object obj)
        {
           App.Current.MainPage.DisplayAlert("Iniciar Sesión", "Iniciando Sesión", "Aceptar"); 
        }

        private string email;
		public string Email
		{
			get { return email; }
			set { email = value;
				OnPropertyChanged();
				IniciarSesionCommand.ChangeCanExecute(); // Actualiza el estado del comando cuando cambia el email. Evalua si puede llegar a ejecutarse ese boton.
            }
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value;
				OnPropertyChanged();
				IniciarSesionCommand.ChangeCanExecute(); // Actualiza el estado del comando cuando cambia la contraseña. Evalua si puede llegar a ejecutarse ese boton.
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

        //Los command se usan para conectar la vista con el viewmodel en los botones.
        //Se definen propiedades del tipo Command (orden), tiene la particularidad de que solo se inicializan con get.
        //La parte grafica va a estar conectada con el command y cuando se pulse el boton se va a ejecutar el metodo que le pasamos por parametro.
        //Se conectan con la parte grafica haciendole binding en los botones.
        public Command IniciarSesionCommand { get; }
        public Command RegistrarseCommand { get; }
    }
}
