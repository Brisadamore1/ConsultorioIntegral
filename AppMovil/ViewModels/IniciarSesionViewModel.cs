using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels
{
    public partial class IniciarSesionViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string mail;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool rememberpassword;

        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }
        public IniciarSesionViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBej0cIsKLO_UgPNjp5UvJemxmuwNJhePY",
                AuthDomain = "consultoriointegral-22815.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("ConsultorioIntegral");

            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);

            // Try to auto-login if a user is stored
            ChequearSiHayUsuarioAlmacenado();
        }

        private async void Registrarse()
        {
            try
            {
                await Shell.Current.GoToAsync("Registrarse");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Registro", "No se pudo abrir la pantalla de registro. Intente nuevamente.", "Ok");
            }
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                var shellconsultorio = (ConsultorioShell)App.Current.MainPage;
                shellconsultorio.EnableAppAfterLogin();
            }
        }
        public bool PermitirIniciarSesion()
        {
            return !string.IsNullOrWhiteSpace(Mail) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void IniciarSesion()
        {
            try
            {
                // Basic validations to avoid exceptions and provide clear feedback
                var email = Mail?.Trim();
                var pass = Password;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe ingresar correo y contraseña.", "Ok");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "El correo no tiene un formato válido.", "Ok");
                    return;
                }

                // Validaciones de longitud de contraseña para evitar errores innecesarios
                if (pass.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "La contraseña debe tener al menos 6 caracteres.", "Ok");
                    return;
                }
                if (pass.Length > 128)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "La contraseña es demasiado larga.", "Ok");
                    return;
                }

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, pass);
                if (userCredential?.User?.Info?.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico.", "Ok");
                    return;
                }

                if (rememberpassword)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                var shellconsultorio = (ConsultorioShell)App.Current.MainPage;
                shellconsultorio.EnableAppAfterLogin();
            }
            catch (FirebaseAuthException)
            {
                // Simples: si credenciales son incorrectas u otro error de auth, mostrar una única advertencia
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Correo o contraseña incorrectos.", "Ok");
            }
            catch (System.Net.Http.HttpRequestException)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "No se pudo conectar. Verifique su conexión a Internet.", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un error inesperado. Intente nuevamente.", "Ok");
            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
