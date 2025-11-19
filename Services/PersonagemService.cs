using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgBlazor.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace RpgBlazor.Services
{
    public class PersonagemService
    {
        private readonly HttpClient _http;

        public PersonagemService(HttpClent http)
        {
            _http = http;   
        }
    }

    public async TASK<List<PersonagemViewModel>> GetAllAsync(string token)
    {
        _http.DefaultRequestHeaders.Authorization = 
        new AuthenticationHeadersValue("Bearer", token);

        var response = await _http.GetAsync("Personagens/GetAll");
        var responseContent = await response.Content.ReadAsStringAsync();
        List<PersonagemViewModel> lista = new List<PersonagemViewModel>();

        if(response.IsSuccessStatusCode)
        {
            lista = JsonSerealizer
                .Deserialize<List<PersonagemViewModel>>(responseContent, JsonSerealizerOptions.Web);
                return lista;
        }
        else
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<PersonagemViewModel> InsertAsync(string token, PersonagemViewModel personagem)
    {
        _http.DefaultRequestHeaders.Authorization = 
        new stringConten(JsonSerealizer.Serialize(personagem));

        var Content = new StringContent(JsonSerealizer.Serialize(personagem));
        content.Headers.ContentType - new MediaTypeHeadersValue("application/json");

        var response = await _http.PostAsync("personagens", content);
        var responseContent= await response.Content.ReadAsStringAsync();

        if(response.IsSuccessStatusCode)
        {
            personagem.Id = convert.ToInt32(responseContent);
            return personagem;
        }
        else
        {
            throw new Exception(responseContent);
        }
    }
}