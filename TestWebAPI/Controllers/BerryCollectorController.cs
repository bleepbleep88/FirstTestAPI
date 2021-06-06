using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class BerryCollectorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BerryCollectorController> _logger;

        public BerryCollectorController(ILogger<BerryCollectorController> logger)
        {
            _logger = logger;
        }

        [Route("{berry}")]
        [HttpGet]
        public async Task<Berry> Get([FromRoute]int berry)
        {
            int berryID = berry;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/berry");
            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress+$"/{berryID}");
            if (response.IsSuccessStatusCode) {
                Berry result = JsonConvert.DeserializeObject<Berry>(await response.Content.ReadAsStringAsync());
                result.url = httpClient.BaseAddress + $"/{berryID}";
                return result;
            }

            Berry BlankBerry = new Berry();
            return BlankBerry;

        }
        public async Task<List<Berry>> getBerryList()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/berry");
            HttpResponseMessage response = await httpClient.GetAsync(httpClient.BaseAddress);
            BerryRoot result = JsonConvert.DeserializeObject<BerryRoot>(await response.Content.ReadAsStringAsync());
            
            return result.results;
        }
    }
}
