using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels
{
    public partial class RegistrarseViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private const string FirebaseApiKey = "AIzaSyBej0cIsKLO_UgPNjp5UvJemxmuwNJhePY";
        private const string RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

        public IRelayCommand RegistrarseCommand { get; }
        public IRelayCommand CancelarCommand { get; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string nombre;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string mail;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string password;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RegistrarseCommand))]
        private string verifyPassword;

        public RegistrarseViewModel()
        {
            RegistrarseCommand = new RelayCommand(Registrarse, PermitirRegistrarse);
            CancelarCommand = new RelayCommand(Cancelar);
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBej0cIsKLO_UgPNjp5UvJemxmuwNJhePY",
                AuthDomain = "consultoriointegral-22815.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                        new EmailProvider()
                }
            });
        }

        public bool PermitirRegistrarse()
        {
            return !string.IsNullOrWhiteSpace(Nombre)
                   && !string.IsNullOrWhiteSpace(Mail)
                   && !string.IsNullOrWhiteSpace(Password)
                   && !string.IsNullOrWhiteSpace(VerifyPassword)
                   && Password == VerifyPassword;
        }

        private async void Registrarse()
        {
            try
            {
                var email = Mail?.Trim();
                var pass = Password;
                var confirm = VerifyPassword;
                var name = Nombre?.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Complete todos los campos.", "Ok");
                    return;
                }
                if (!IsValidEmail(email))
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "El correo no tiene un formato válido.", "Ok");
                    return;
                }
                if (pass.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "La contraseña debe tener al menos 6 caracteres.", "Ok");
                    return;
                }
                if (pass.Length > 128)
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "La contraseña es demasiado larga.", "Ok");
                    return;
                }
                if (pass != confirm)
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden.", "Ok");
                    return;
                }

                var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(email, pass, name);
                var idToken = await user.User.GetIdTokenAsync();
                await SendVerificationEmailAsync(idToken);
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada. Debe verificar su correo electrónico.", "Ok");
                await Shell.Current.GoToAsync("//Login");
            }
            catch (FirebaseAuthException error)
            {
                var reason = error.Reason.ToString();
                var message = reason switch
                {
                    var r when r.Contains("EmailExists", StringComparison.OrdinalIgnoreCase) => "El correo ya está registrado.",
                    var r when r.Contains("InvalidEmail", StringComparison.OrdinalIgnoreCase) => "El correo no es válido.",
                    var r when r.Contains("WeakPassword", StringComparison.OrdinalIgnoreCase) => "La contraseña es demasiado débil.",
                    _ => "No se pudo crear la cuenta. Verifique los datos e intente nuevamente."
                };
                await Application.Current.MainPage.DisplayAlert("Registrarse", message, "Ok");
            }
            catch (HttpRequestException)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "No se pudo conectar. Intente nuevamente más tarde.", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un error inesperado. Intente nuevamente.", "Ok");
            }
        }

        public static async Task SendVerificationEmailAsync(string idToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
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

        private async void Cancelar()
        {
            try
            {
                await Shell.Current.GoToAsync("//Login");
            }
            catch
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
