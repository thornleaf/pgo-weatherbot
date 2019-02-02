using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
using WeatherBot.Models;
using System.Web.Helpers;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;

namespace WeatherBot.Filters
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if value passed in header
            if (actionContext.Request.Headers.Authorization == null)
            {
                Trace.WriteLine("no authorization header found");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // get header values
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                Trace.WriteLine("auth token: " + authToken);
                // decode values
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string[] credsArray = decoded.Split(':');
                string username = credsArray[0];
                string password = credsArray[1];

                // validate user
                using (PokeEntities db = new PokeEntities())
                {
                    PokeUser usr = db.PokeUsers.Find(username);
                    Trace.WriteLine("User found: " + usr.Name);
                    bool valid = false;
                    if (usr != null)
                    {
                        valid = Crypto.VerifyHashedPassword(usr.PwdHash, password);
                    }
                    if (valid == false)
                    {
                        // not validated
                        Trace.WriteLine("User not validated");
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        Trace.WriteLine("User Validated");
                        Thread.CurrentPrincipal = new GenericPrincipal((IIdentity)new GenericIdentity(username), new string[] { usr.Role });
                    }
                }
            }

        }
    }
}