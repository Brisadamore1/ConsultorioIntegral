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
            ChequearSiHayUsuarioAlmacenado();

            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
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
            return !string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion()
        {
            try
            {

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(mail, password);
                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
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
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");

            }
        }
    }
}
