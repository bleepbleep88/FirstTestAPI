using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class Berry
    {
        public String name { get; set; }
        public string url { get; set; }
    }

    public class BerryRoot
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Berry> results { get; set; }
    }
}
