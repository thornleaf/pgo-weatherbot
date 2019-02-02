using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Models
{
    public class TranslationObject
    {
        public IEnumerable<WeatherTranslation> Translations { get; set; }
        public IEnumerable<PgoWeather> PgoWeathers { get; set; }
    }
}