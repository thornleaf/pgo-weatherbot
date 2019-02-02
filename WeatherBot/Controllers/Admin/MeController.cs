using WeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WeatherBot.Controllers.Admin
{
    [Authorize]
    public class MeController : ApiController
    {
        PokeEntities db = new PokeEntities();

        public HttpResponseMessage GetMe()
        {
            PokeUser u = db.PokeUsers.Find(User.Identity.Name);

            return Request.CreateResponse(HttpStatusCode.OK, u);
        }
    }
}
