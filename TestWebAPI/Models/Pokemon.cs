using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonRoot
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Pokemon> results { get; set; }
    }
}
