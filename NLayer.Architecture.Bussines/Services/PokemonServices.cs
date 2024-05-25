using Newtonsoft.Json.Linq;
using NLayer.Architecture.Bussines.Models.Models;

namespace NLayer.Architecture.Bussines.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            if (!response.IsSuccessStatusCode) return null;

            var json = JObject.Parse(await response.Content.ReadAsStringAsync());

            var pokemon = new Pokemon
            {
                Nombre = json["name"].ToString(),
                Tipo = json["types"][0]["type"]["name"].ToString(),
                Imagen = json["sprites"]["front_default"].ToString(),
                Movimientos = json["moves"].Select(m => m["move"]["name"].ToString()).ToList()
            };

            return pokemon;
        }
    }
}
//