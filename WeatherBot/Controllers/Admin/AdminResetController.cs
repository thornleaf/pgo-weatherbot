using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherBot.Helpers;
using WeatherBot.Models;

namespace WeatherBot.Controllers.Admin
{
    public class AdminResetController : ApiController
    {
        PokeEntities db = new PokeEntities();
        public HttpResponseMessage GetReset()
        {
            InitializeDb.Initialize();
            return Request.CreateResponse(HttpStatusCode.OK, "user created");
        }
    }
}
