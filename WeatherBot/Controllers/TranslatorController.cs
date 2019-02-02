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
    public class TranslatorController : ApiController
    {
        PokeEntities db = new PokeEntities();
        
        public HttpResponseMessage GetTranslations()
        {
            TranslationObject to = new TranslationObject()
            {
                Translations = db.WeatherTranslations,
                PgoWeathers = db.PgoWeathers
            };
            return Request.CreateResponse(HttpStatusCode.OK, to);
        }

        // update translation
        [Authorize]
        public HttpResponseMessage PostTranslation(WeatherTranslation w)
        {
            var wt = db.WeatherTranslations.Find(w.Id);
            if (wt == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "not found");
            }
            db.Entry(wt).CurrentValues.SetValues(w);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "updated");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
