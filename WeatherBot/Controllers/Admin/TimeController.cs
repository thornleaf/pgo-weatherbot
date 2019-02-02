using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WeatherBot.Controllers.Admin
{
    public class TimeController : ApiController
    {
        public HttpResponseMessage GetTime()
        {
            TimeResponse tr = new TimeResponse()
            {
                CurrentDateTime = DateTime.Now,
                UtcTime = DateTime.Now.ToUniversalTime(),
                TimeZoneName = TimeZone.CurrentTimeZone.StandardName
            };

            return Request.CreateResponse(HttpStatusCode.OK, tr);
        }
    }

    internal class TimeResponse
    {
        public DateTime CurrentDateTime { get; set; }
        public string TimeZoneName { get; set; }
        public DateTime UtcTime { get; set; }
    }
}
