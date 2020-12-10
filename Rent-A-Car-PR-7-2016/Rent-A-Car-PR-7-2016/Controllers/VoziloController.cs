using Rent_A_Car_PR_7_2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_A_Car_PR_7_2016.Controllers
{
    public class VoziloController : Controller
    {
        Podaci podaci;
        // GET: Vozilo
        public ActionResult Index()
        {
            //return View();
            NapraviSesiju();

            //List<Manifestacija> manifestacije = (List<Manifestacija>)HttpContext.Application["manifestacije"];
            List<Vozilo> vozila = Podaci.vozila;
            return View(vozila);
        }


        private void NapraviSesiju()
        {
            podaci = (Podaci)Session["Podaci"];
            if (podaci == null)
            {
                podaci = new Podaci();
                Session["Podaci"] = podaci;
            }

        }

    }
}