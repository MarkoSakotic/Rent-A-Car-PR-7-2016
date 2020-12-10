using Rent_A_Car_PR_7_2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_A_Car_PR_7_2016.Controllers
{
    public class RegistracijaController : Controller
    {
        Podaci podaci;
        // GET: Registracija
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prijava()
        {
            return View();
        }

        public ActionResult Registracija()
        {
            return View("Registracija");
        }

        public ActionResult Register(Korisnik korisnik)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];

            foreach (Korisnik item in korisnici)
            {
                if (item.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    ViewBag.Message = $"Korisnik sa korisnickim imenom {korisnik.KorisnickoIme} vec postoji!";
                    return View("Registracija");
                }

            }

            if (korisnik.KorisnickoIme == null || korisnik.Loznika == null || korisnik.Ime == null || korisnik.Prezime == null || korisnik.DatumRodjenja == null)
            {
                ViewBag.Message = "Molimo Vas popunite sva polja!";
                return View("Registracija");
            }

            korisnici.Add(korisnik);
            Podaci.SaveUser(korisnik);
            Session["korisnik"] = korisnik;
            return RedirectToAction("Prijava", "Registracija");
        }


        [HttpPost]
        public ActionResult Login(string korisnickoIme, string lozinka)
        {
            NapraviSesiju();

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];
            Korisnik korisnik = korisnici.Find(u => u.KorisnickoIme.Equals(korisnickoIme) && u.Loznika.Equals(lozinka));

            if (korisnik == null)
            {
                ViewBag.Message = $"Korisnik sa navedenim kredencijalima ne postoji!";
                return View("Prijava");
            }

            if (korisnik.Obrisano == true)
            {
                ViewBag.Message = $"Korisnik sa navedenim kredencijalima ne postoji!";
                return View("Prijava");
            }

            Session["korisnik"] = korisnik;
            podaci.TrenutniKorisnik = korisnik;
            return RedirectToAction("Index", "Vozilo");
        }

        public ActionResult Logout()
        {
            Session["korisnik"] = null;
            //Session["cart"] = null;

            return View("Prijava");

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