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
    public class DiscordController : ApiController
    {
        PokeEntities db = new PokeEntities();
       
        public HttpResponseMessage GetHour(int? hour = null)
        {
            // this needs to get called hourly at about 15 minutes past the hour; set pull time in config settings (admin login) and if it's a pull time, it'll post to discord

            // the local time conversion is in case your server has a different time zone than your local time - forecast times are all local time


            DateTime thisTime = DateTime.Now;
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(Resources.TimeZoneId);

            var now = DateTime.Now.ToUniversalTime();
            var localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, tst.Id);
            var date = localTime.Date;
            var localHour = localTime.Hour;
            int fch = int.Parse(db.ConfigSettings.Find(1).Value);
            WeatherEntry we = new WeatherEntry();

            if (hour != null)
            {
                we = db.WeatherEntries.Where(w => w.Date == date && w.Hour == hour).FirstOrDefault();
            }
            else
            {
                if (localHour == fch || localHour == (fch + 8) || localHour == (fch + 16))
                {
                    we = db.WeatherEntries.OrderByDescending(w => w.Id).FirstOrDefault();
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "not time yet");
                }
            }
            // get WeatherEntry (and all values) for today's date and the specified hour

            if (we != null && we.WeatherValues != null)
            {
                var wv = we.WeatherValues.ToArray();
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
                    
                    string fcTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(w.DateTime, tst.Id).ToString("h:mm tt");
                    string fc1 = fcTime + ": " + w.PgoWeather.Description; 
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
            return Request.CreateResponse(HttpStatusCode.OK, "no valid forecast for this date/time");
        }
    }
}
