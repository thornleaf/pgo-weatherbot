using WeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WeatherBot.Controllers
{
    public class ConfigController : ApiController
    {
        PokeEntities db = new PokeEntities();

        public ConfigSetting GetConfig(int id)
        {
            return db.ConfigSettings.Find(id);
        }

        [Authorize]
        public ConfigSetting PostConfig(ConfigSetting c)
        {
            var cfg = db.ConfigSettings.Find(c.Id);
            if (cfg != null)
            {
                db.Entry(cfg).CurrentValues.SetValues(c);
                db.SaveChanges();
                return cfg;
            }
            return c;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
