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
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace WeatherBot.Controllers
{
    public class ForecastController : ApiController
    {
        PokeEntities db = new PokeEntities();
        public HttpResponseMessage GetWeather()
        {
            DateTime thisTime = DateTime.Now;
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Resources.TimeZoneId);

            var now = DateTime.Now.ToUniversalTime();
            var hourAgo = now.AddHours(-1);
            var wv = db.WeatherValues.Where(w => w.DateAdded > hourAgo).ToArray();
            // then, create forecast
            StringBuilder forecast = new StringBuilder();
            

            forecast.AppendLine("Forecast at " + TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, tst.Id).ToString("h:mm tt"));
            for (var i = 0; i < 8; i++)
            {
                var w = wv[i];
                var types = new List<string>();
                var tps = w.PgoWeather.PokemonTypes.ToArray();
                for (var j = 0; j < tps.Length; j++)
                {
                    types.Add(tps[j].Name);
                }
                var ts = types.ToArray();
                int forecastHour = w.DateTime.Hour;
                List<string> raidBosses = new List<string>();
                

                //string[] bs = bosses.Select(b => b.Name + (b."")).ToArray();
                string fcTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(w.DateTime, tst.Id).ToString("h:mm tt");
                string fc1 = fcTime + ": " + w.PgoWeather.Description; //TimeZoneInfo.ConvertTimeBySystemTimeZoneId(w.DateTime, tst.Id)
                string fc2 = "Boosted types: " + string.Join(", ", ts);
                string fc3 = "---";
                forecast.AppendLine(fc1);
                forecast.AppendLine(fc2);
                forecast.AppendLine(fc3);
            }
            forecast.AppendLine("=^..^=   =^..^=   =^..^=");
            // then, post to Discord
            DiscordJson js = new DiscordJson()
            {
                content = forecast.ToString()
            };

            
            string url = Resources.DiscordWebhook;
            int firstHour = wv[0].DateTime.Hour;
            string json = JsonConvert.SerializeObject(js);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var resp = client.UploadString(url, json);
            }

            // now clean up weather values table (remove old values)
            Task.Factory.StartNew(() => WeatherHelper.RemoveStale());
            //WeatherHelper.RemoveStale();

            // finally, return success
            return Request.CreateResponse(HttpStatusCode.OK, firstHour);
        }
    }
}
