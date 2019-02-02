using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WeatherBot.Models;

namespace WeatherBot.Helpers
{
    public class InitializeDb
    {
        public static void Initialize()
        {
            using (PokeEntities db = new PokeEntities())
            {
                var admin = db.PokeUsers.Where(u => u.Role == "admin").FirstOrDefault();
                if (admin == null)
                {
                    admin = new PokeUser()
                    {
                        Name = Resources.AdminUsername,
                        Id = Resources.AdminUsername,
                        Role = "admin",
                        PwdHash = Crypto.HashPassword(Resources.AdminPassword)
                    };
                }
            }
        }
    }
}