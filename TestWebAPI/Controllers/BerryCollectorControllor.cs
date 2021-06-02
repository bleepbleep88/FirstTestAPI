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
    public class BerryCollectorControllor : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BerryCollectorControllor> _logger;

        public BerryCollectorControllor(ILogger<BerryCollectorControllor> logger)
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
            HttpResponseMessage response = await httpClient.GetAsync($"/{berryID}");
            Berry result = JsonConvert.DeserializeObject<Berry>(await response.Content.ReadAsStringAsync());


            return result;
        }
    }
}
