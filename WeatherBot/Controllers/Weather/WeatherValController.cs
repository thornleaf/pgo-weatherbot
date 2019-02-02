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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherValController : ApiController
    {
        PokeEntities db = new PokeEntities();

        public IEnumerable<PgoWeather> GetWeathers()
        {
            return db.PgoWeathers;
        }


        public HttpResponseMessage GetVal(long id, bool? isCorrect = null)
        {
            WeatherValue wv = db.WeatherValues.Find(id);

            wv.IsCorrect = isCorrect;
            if (isCorrect == true || isCorrect == null)
            {
                wv.ActualIcon = null;
            }

            var vals = db.WeatherValues.Where(v => v.DateTime == wv.DateTime);
            foreach (WeatherValue v in vals)
            {
                if (wv.PgoIconId == v.PgoIconId)
                {
                    if (isCorrect == true || isCorrect == null)
                    {
                        v.ActualIcon = null;
                        v.IsCorrect = isCorrect;
                    }
                    else
                    {
                        v.IsCorrect = isCorrect;
                    }
                }
            }
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        public HttpResponseMessage PostCorrect(WeatherValue val)
        {
            WeatherValue wv = db.WeatherValues.Find(val.Id);
            var values = db.WeatherValues.Where(w => w.DateTime == wv.DateTime && w.PgoIconId == wv.PgoIconId).ToArray();
            for (var i = 0; i < values.Length; i++)
            {
                long vId = values[i].Id;
                var v = db.WeatherValues.Find(val.Id);
                v.ActualIconid = val.ActualIconid;
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Authorize]
        public HttpResponseMessage PostVal(long id, bool del)
        {
            WeatherEntry we = db.WeatherEntries.Find(id);
            db.WeatherValues.RemoveRange(we.WeatherValues);
            db.SaveChanges();
            db.WeatherEntries.Remove(we);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "deleted");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
