using Microsoft.JSInterop;
using System.Diagnostics;

namespace WebAssembly.Services
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "firebaseUserId";
        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        //Este metodo intenta loguear al usuario con email y password. Si lo consigue, guarda el id del usuario en localStorage. Es como el inicio de sesion
        public async Task<string> SignInWithEmailPassword(string email, string password)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailPassword", email, password);
            //Si usuario es distinto de null, guardarlo en localStorage. Se diferencia del createuserwithemailandpassword porque este devuelve el id directamente
            if (userId != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                OnChangeLogin?.Invoke();
            }
            return userId;
        }

        //Este metodo crea un usuario con email y password. Si lo consigue, guarda el id del usuario en localStorage. Es como el registro
        public async Task<string> createUserWithEmailAndPassword(string email, string password, string displayName)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            //Si usuario es distinto de null, guardamos en localStorage al usuario logueado. 
            if (userId != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                OnChangeLogin?.Invoke();
            }
            return userId;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            return !string.IsNullOrEmpty(userId);
        }
    }
}
