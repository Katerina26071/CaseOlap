﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcSmallScreen.Models;

namespace MvcSmallScreen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            System.Data.Entity.Database.SetInitializer(
        new MvcSmallScreen.Models.SampleData());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
