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

        public ActionResult RegisterVlasnika(Korisnik korisnik)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];

            foreach (Korisnik item in korisnici)
            {
                if (item.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    ViewBag.Message = $"Korisnik sa korisnickim imenom {korisnik.KorisnickoIme} vec postoji!";
                    return View("RegistracijaVlasnika");
                }

            }

            if (korisnik.KorisnickoIme == null || korisnik.Loznika == null || korisnik.Ime == null || korisnik.Prezime == null || korisnik.DatumRodjenja == null)
            {
                ViewBag.Message = "Molimo Vas popunite sva polja!";
                return View("RegistracijaVlasnika");
            }

            korisnici.Add(korisnik);
            Podaci.SaveUser(korisnik);
            Session["korisnik"] = korisnik;
            return RedirectToAction("ListaKupaca", "Registracija");
        }


        [HttpPost]
        public ActionResult Add(Korisnik korisnik)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];
            if (korisnici.Contains(korisnik))
            {
                ViewBag.Message = $"Korisnik sa korisnickim imenom {korisnik.KorisnickoIme} vec postoji!";
                return View();
            }

            korisnici.Add(korisnik);
            Podaci.SaveUser(korisnik);
            Session["korisnik"] = korisnik;
            return RedirectToAction("Index", "Vozilo");


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

        public ActionResult ListaKupaca()
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];
            List<Korisnik> kupci = new List<Korisnik>();

            foreach (Korisnik item in korisnici)
            {
                if (item.Uloga.Equals(UlogaKorisnika.KUPAC) || item.Uloga.Equals(UlogaKorisnika.VLASNIK))
                {
                    kupci.Add(item);
                }
            }
            return View("Kupci", kupci);
        }


        public ActionResult ObrisiKorisnika(string korisnickoIme)
        {
            //List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["Korisnici"];
            //List<Korisnik> kkorisnici = korisnici.ToList();

            foreach (Korisnik k in Podaci.korisnici)
            {
                if (k.KorisnickoIme.Equals(korisnickoIme))
                {
                    k.Obrisano = true;

                }

            }
            Korisnik korisnik = new Korisnik();
            //nadjem korisnika iz liste
            //ovde ga ponovo upisi fajl podaci.save
            Podaci.SaveUser(korisnik);
            return View("Kupci", Podaci.korisnici);
        }



        //SEARCH
        public ActionResult SearchByIme(string ime)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Korisnik> nazivFilter = new List<Korisnik>();

            if (ime.Equals(""))
            {
                ViewBag.korisnici = korisnici;
                nazivFilter = korisnici;
            }
            else
            {
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Ime.ToString().Contains(ime))
                    {
                        nazivFilter.Add(korisnik);
                    }
                }
                ViewBag.users = nazivFilter;
            }

            return View("~/Views/Registracija/Kupci.cshtml", nazivFilter);
        }

        public ActionResult SearchByPrezime(string prezime)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Korisnik> nazivFilter = new List<Korisnik>();

            if (prezime.Equals(""))
            {
                ViewBag.korisnici = korisnici;
                nazivFilter = korisnici;
            }
            else
            {
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Prezime.ToString().Contains(prezime))
                    {
                        nazivFilter.Add(korisnik);
                    }
                }
                ViewBag.users = nazivFilter;
            }

            return View("~/Views/Registracija/Kupci.cshtml", nazivFilter);
        }

        public ActionResult SearchByKorisnickoIme(string korisnickoime)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Korisnik> nazivFilter = new List<Korisnik>();

            if (korisnickoime.Equals(""))
            {
                ViewBag.korisnici = korisnici;
                nazivFilter = korisnici;
            }
            else
            {
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.KorisnickoIme.ToString().Contains(korisnickoime))
                    {
                        nazivFilter.Add(korisnik);
                    }
                }
                ViewBag.users = nazivFilter;
            }

            return View("~/Views/Registracija/Kupci.cshtml", nazivFilter);
        }


        public ActionResult Filtriranje(string uloga)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<Korisnik> nazivFilter = new List<Korisnik>();

            if (uloga.Equals(""))
            {
                ViewBag.korisnici = korisnici;
                nazivFilter = korisnici;
            }
            else
            {
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Uloga.ToString().Equals(uloga))
                    {
                        nazivFilter.Add(korisnik);
                    }
                }
                ViewBag.users = nazivFilter;
            }

            return View("~/Views/Registracija/Kupci.cshtml", nazivFilter);
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