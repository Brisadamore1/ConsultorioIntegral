using Service.Interfaces;
using Service.Models;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PacienteService : GenericService<Paciente>, IPacienteService
    {

        public PacienteService(HttpClient? httpClient = null) : base(httpClient)
        {
        }
        public async Task<Paciente?> GetByEmailAsync(string email)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_endpoint}/byemail?email={email}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<Paciente>(content, _options);
        }
    }
}
