using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonCollectorController : ControllerBase
    {

        //Should return a list of first 150 pokemon
        public async Task<List<Pokemon>> getPokemonList()
        {
            List<Pokemon> PokemonList = new List<Pokemon>();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon");
            PokemonRoot result = JsonConvert.DeserializeObject<PokemonRoot>(await response.Content.ReadAsStringAsync());
            PokemonList.AddRange(result.results);
            while(PokemonList.Count < 151)
            {
                response = await httpClient.GetAsync(new Uri(result.next));
                result = JsonConvert.DeserializeObject<PokemonRoot>(await response.Content.ReadAsStringAsync());
                PokemonList.AddRange(result.results);
            }
            PokemonList.RemoveRange(151, PokemonList.Count - 151);
            return PokemonList;
        }
    }
}
