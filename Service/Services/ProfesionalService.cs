using Microsoft.Extensions.Caching.Memory;
using Service.DTOs;
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
    public class ProfesionalService : GenericService<Profesional>, IProfesionalService
    {
        public ProfesionalService(HttpClient? httpClient=null, IMemoryCache? memoryCache= null) : base(httpClient, memoryCache)
        {

        }

        public async Task<List<Profesional>?> GetWithFilterAsync(FilterProfesionalDTO filter)
        {
            //SetAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync($"{_endpoint}/withfilter",filter);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al obtener los datos: {response.StatusCode}");
            }
            return JsonSerializer.Deserialize<List<Profesional>>(content, _options);
        }

    }
}
