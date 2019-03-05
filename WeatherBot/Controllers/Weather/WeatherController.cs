using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherBot.Models;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;
using WeatherBot.Helpers;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace WeatherBot.Controllers
{
    public class WeatherController : ApiController
    {
        PokeEntities db = new PokeEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetWeather()
        {
            // get forecast from AccuWeather and save in DB
            // this needs to get called hourly at about 5 past the hour (or 35 past if your time zone is a half hour off)

            using (WebClient client = new WebClient())
            {
                var resp = client.DownloadString("http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/"+Resources.LocationId+"?apikey="+Resources.ApiKey+"&metric=true&details=true");
                var now = DateTime.UtcNow;
                DateTime thisTime = DateTime.Now;
                string tzId = Resources.TimeZoneId;
                TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(tzId);
                bool isDaylight = tst.IsDaylightSavingTime(thisTime);
                WeatherObject[] response = null;
                try
                {
                    response = JsonConvert.DeserializeObject<WeatherObject[]>(resp);
                }
                catch (Exception ex)
                {
                    Trace.Write(ex);
                }
                var LindsayTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, tst.Id);

                List<WeatherValue> wvs = new List<WeatherValue>();
                for (var i = 0; i < response.Length; i++)
                {
                    var w = response[i];
                    //w.PokeWeather = new PgoWeather();
                    WeatherTranslation wt = db.WeatherTranslations.Find(w.WeatherIcon);
                    int weatherId;
                    if (wt.CanWindy == true && (w.Wind.Speed.Value > 29 || w.WindGust.Speed.Value > 31)) // (OR IS IT SUM OF THESE ? 55? This works for me, anyway)
                    {
                        w.PokeWeather = db.PgoWeathers.Find(6);
                        weatherId = 6;
                    }
                    else
                    {
                        weatherId = wt.PgoWeather.Id;
                    }

                    WeatherValue wv = new WeatherValue()
                    {
                        DateTime = w.DateTime,
                        WeatherIcon = w.WeatherIcon,
                        IconPhrase = w.IconPhrase,
                        IsDaylight = w.IsDaylight,
                        TempUnit = w.Temperature.Unit,
                        TempValue = w.Temperature.Value,
                        WindSpeed = w.Wind.Speed.Value,
                        WindUnit = w.Wind.Speed.Unit,
                        GustSpeed = w.WindGust.Speed.Value,
                        GustUnit = w.WindGust.Speed.Unit,
                        PrecipitationProbability = w.PrecipitationProbability,
                        RainProbability = w.RainProbability,
                        RainAmt = w.Rain.Value,
                        RainUnit = w.Rain.Unit,
                        SnowProbability = w.SnowProbability,
                        SnowAmt = w.Snow.Value,
                        SnowUnit = w.Snow.Unit,
                        IceProbability = w.IceProbability,
                        IceAmt = w.Ice.Value,
                        IceUnit = w.Ice.Unit,
                        CloudCover = w.CloudCover,
                        PgoIconId = weatherId,
                        DateAdded = now
                    };
                    wvs.Add(wv);
                }
                WeatherEntry entry = new WeatherEntry()
                {
                    DateCreated = LindsayTime,
                    Date = LindsayTime,
                    Hour = LindsayTime.Hour,
                    WeatherValues = wvs
                };
                db.WeatherEntries.Add(entry);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "got it");
            }
        }
        
        public async Task<IEnumerable<WeatherEntry>> GetWeatherByDate(DateTime date)
        //public IEnumerable<WeatherEntry> GetWeatherByDate(DateTime date)
        {
            var d1 = date.Date;
            var d2 = d1.AddDays(1);
            var weathers = db.WeatherEntries.Where(d => d.Date == d1).ToArray();
            //foreach (WeatherEntry we in weathers)
            for (var i = 0; i < weathers.Length; i++)
            {
                var we = weathers[i];
                var wv = we.WeatherValues.ToArray();
                for (var j = 0; j < wv.Length; j++)
                {
                    var w = wv[j];
                    await Task.Run(() => FixTime(w, date));
                }
            }
            return weathers;
        }

        public static void FixTime(WeatherValue w, DateTime date)
        {
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Resources.TimeZoneId);
            w.DateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(w.DateTime, tst.Id);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
