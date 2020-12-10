using Rent_A_Car_PR_7_2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Rent_A_Car_PR_7_2016
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            List<Korisnik> korisnici = Podaci.ReadUsers("~/App_Data/korisnici.txt");
            HttpContext.Current.Application["korisnici"] = korisnici;

            List<Vozilo> vozila = Podaci.ReadProducts("~/App_Data/vozila.txt");
            HttpContext.Current.Application["vozila"] = vozila;

        }
    }
}
