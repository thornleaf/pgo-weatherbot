using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Models
{
    public class Paginated
    {
        public IEnumerable<object> Items { get; set; }
        public int? Size { get; set; }
        public int Offset { get; set; }
        public int Total { get; set; }
        public bool First { get; set; }
        public bool Last { get; set; }
    }
}