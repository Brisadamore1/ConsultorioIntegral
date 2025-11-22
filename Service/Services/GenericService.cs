using Microsoft.Extensions.Caching.Memory;
using Service.Interfaces;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;           

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _endpoint;
        protected readonly JsonSerializerOptions _options;
        public static string? jwtToken = string.Empty;
        private readonly IMemoryCache? _memoryCache;

        public GenericService(HttpClient? httpClient = null, IMemoryCache? memoryCache = null)
        {
            _memoryCache = memoryCache;
            _options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var urlApi = Properties.Resources.UrlApi;
            if (Properties.Resources.Remoto == "false")
                urlApi = Properties.Resources.UrlApiLocal;

#if NET8_0_OR_GREATER && (NET8_0_OR_GREATER_WINDOWS || NET8_0_OR_GREATER_ANDROID || NET8_0_OR_GREATER_IOS || NET8_0_OR_GREATER_MACCATALYST)
            // MAUI, Desktop, etc: usar handler personalizado
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            _httpClient = httpClient ?? new HttpClient(handler)
            {
                BaseAddress = new Uri(urlApi)
            };
#else
            // Blazor WebAssembly y otros: usar solo el HttpClient inyectado
            _httpClient = httpClient ?? new HttpClient()
            {
                BaseAddress = new Uri(urlApi)
            };
#endif
            //este endpoint hace referencia a la api controller que se va a consumir pero en minuscula
            _endpoint = ApiEndpoints.GetEndpoint(typeof(T).Name); // solo 'profesionales'


        }
        //protected void SetAuthorizationHeader()
        //{ 
        //    // Si ya está configurado (por un DelegatingHandler), no hacer nada
        //    if (_httpClient.DefaultRequestHeaders.Authorization is not null)
        //        return;
        //    // 1) Intentar leer desde IMemoryCache (configurado por FirebaseAuthService)
        //    if (_memoryCache is not null && _memoryCache.TryGetValue("jwt", out string? cachedToken) && !string.IsNullOrWhiteSpace(cachedToken))
        //    {
        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cachedToken);
        //        return;
        //    }
        //    // 2) Respaldo: variable estática (evitar uso si no es necesario)

        //    if (!string.IsNullOrWhiteSpace(GenericService<object>.jwtToken)) 
        //    { 
        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GenericService<object>.jwtToken);
        //    return;
        //    }
        //    // Si no se definió el token, se lanza una excepción
        //    throw new InvalidOperationException("El token JWT no está disponible para la autorización.");
        //}
        public async Task<T?> AddAsync(T? entity)
        {
            //SetAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync(_endpoint, entity);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al agregar el dato: {response.StatusCode} - {content}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            //SetAuthorizationHeader();
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public virtual async Task<List<T>?> GetAllAsync(string? filtro = "")
        {
            string url = string.IsNullOrEmpty(filtro) ? _endpoint : $"{_endpoint}?filtro={filtro}";
            Console.WriteLine($"[DEBUG] URL llamada: {url}");
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"[DEBUG] Status: {response.StatusCode}, Content: {content}");

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<T>>(content, _options);
            }
            else
            {
                throw new Exception($"Error al obtener los datos. Status: {response.StatusCode}, Content: {content}");
            }
           
        }
        public async Task<List<T>?> GetAllDeletedsAsync()
        {
           // SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/deleteds");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<T>>(content, _options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            //SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<T>(content, _options);
        }

        public async Task<bool> RestoreAsync(int id)
        {
            //SetAuthorizationHeader();
            var response = await _httpClient.PutAsync($"{_endpoint}/restore/{id}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al restaurar el dato: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdateAsync(T? entity)
        {
            //SetAuthorizationHeader();
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);

            var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{idValue}", entity);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hubo un problema al actualizar");
            }
            else
            {
                return response.IsSuccessStatusCode;
            }
        }
       
    }
}
