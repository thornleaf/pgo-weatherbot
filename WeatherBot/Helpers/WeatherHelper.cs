using WeatherBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WeatherBot.Helpers
{
    public class WeatherHelper
    {
        public static void RemoveStale()
        {
            using (PokeEntities db = new PokeEntities())
            {
                var oldDate = DateTime.Now.AddDays(-3).Date;
                var oldValues = db.WeatherValues.Where(v => v.DateAdded < oldDate);
                var oldEntries = db.WeatherEntries.Where(e => e.DateCreated < oldDate);
                db.WeatherValues.RemoveRange(oldValues);
                db.WeatherEntries.RemoveRange(oldEntries);
                db.SaveChanges();
            }
        }

        public static void SaveWeather(WeatherObject wo, WeatherTranslation wt)
        {
            using (PokeEntities db = new PokeEntities())
            {
                WeatherValue wv = new WeatherValue()
                {
                    DateTime = wo.DateTime.ToUniversalTime(),
                    WeatherIcon = wo.WeatherIcon,
                    IconPhrase = wo.IconPhrase,
                    IsDaylight = wo.IsDaylight,
                    TempValue = wo.Temperature.Value,
                    TempUnit = wo.Temperature.Unit,
                    WindSpeed = wo.Wind.Speed.Value,
                    WindUnit = wo.Wind.Speed.Unit,
                    GustSpeed = wo.WindGust.Speed.Value,
                    GustUnit = wo.WindGust.Speed.Unit,
                    PrecipitationProbability = wo.PrecipitationProbability,
                    RainProbability = wo.RainProbability,
                    SnowProbability = wo.SnowProbability,
                    IceProbability = wo.IceProbability,
                    CloudCover = wo.CloudCover,
                    RainAmt = wo.Rain.Value,
                    SnowAmt = wo.Snow.Value,
                    IceAmt = wo.Ice.Value,
                    PgoIconId = wt.PgoWeather.Id,
                    DateAdded = DateTime.Now.ToUniversalTime()
                };
                db.WeatherValues.Add(wv);
                db.SaveChanges();
            }
        }
    }
}