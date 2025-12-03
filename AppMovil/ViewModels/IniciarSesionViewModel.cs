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
            // Si hay un usuario guardado, precargar los campos de login pero NO iniciar sesión automáticamente.
            // De esta forma solo se guarda/recupera cuando el usuario marcó "Recordar contraseña".
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                // Precargar email si está disponible
                if (_userInfo != null && !string.IsNullOrWhiteSpace(_userInfo.Email))
                {
                    Mail = _userInfo.Email;
                }

                // No siempre es posible recuperar la contraseña en texto plano desde el repo.
                // Si el repositorio guarda la credencial con la contraseña en claro, intentar asignarla.
                try
                {
                    var cred = _firebaseCredential;
                    if (cred != null)
                    {
                        // algunos repositorios pueden exponer un campo con la contraseña; comprobamos dinámicamente
                        var pwdProp = cred.GetType().GetProperty("Password");
                        if (pwdProp != null)
                        {
                            var pwdVal = pwdProp.GetValue(cred) as string;
                            if (!string.IsNullOrWhiteSpace(pwdVal))
                                Password = pwdVal;
                        }
                    }
                }
                catch { /* ignore if not available */ }

                // Indicar que los campos están precargados por un guardado anterior
                Rememberpassword = true;
                // No hacer auto-login: el usuario debe presionar "Iniciar sesión".
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

                // Guardar o eliminar credenciales solo si el usuario activó la casilla
                if (Rememberpassword)
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
