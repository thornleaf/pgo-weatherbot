using WeatherBot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace WeatherBot.Controllers.Admin
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        PokeEntities db = new PokeEntities();
        public HttpResponseMessage PostLogin(LoginCreds creds)
        {
            PokeUser usr = db.PokeUsers.Find(creds.Username);

            if (usr == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            if (Crypto.VerifyHashedPassword(usr.PwdHash, creds.Password) == false)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            FormsAuthentication.SetAuthCookie(creds.Username.ToLower(), false);
            return Request.CreateResponse(HttpStatusCode.OK, usr);
        }

        public HttpResponseMessage GetLogout()
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
