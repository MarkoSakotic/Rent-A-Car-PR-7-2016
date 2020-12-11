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

        public ActionResult DodajNovoVozilo(Vozilo vozilo)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["Vozila"];

            foreach (Vozilo item in vozila)
            {
                if (item.MarkaVozila == vozilo.MarkaVozila)
                {
                    ViewBag.Message = $"Vozilo sa tom markom {vozilo.MarkaVozila} vec postoji!";
                    return View("DodajNovoVozilo");
                }

            }

            if (vozilo.MarkaVozila == null || vozilo.ModelVozila == null || vozilo.TipVozila.ToString() == null || vozilo.BrojMestaUVozilu.ToString() == null || vozilo.DatumKadJeSlobodnoVozilo == null || vozilo.CenaPoDanu.ToString() == null || vozilo.Status.ToString() == null || vozilo.Ulica == null || vozilo.Broj.ToString() == null || vozilo.Mesto == null || vozilo.PostanskiBroj.ToString() == null || vozilo.Poster == null)
            {
                ViewBag.Message = "Molimo Vas popunite sva polja!";
                return View("DodajNovoVozilo");
            }

            vozila.Add(vozilo);
            Podaci.SaveVozila(vozilo);
            Session["vozilo"] = vozilo;
            return RedirectToAction("Index", "Vozilo");

        }


        public ActionResult ProfilVozila(string markaVozila)
        {
            NapraviSesiju();
            foreach (Vozilo item in Podaci.vozila)
            {
                if (item.MarkaVozila == markaVozila)
                {
                    ViewBag.vozilo = item;
                    break;

                }
            }

            return View("ProfilVozila");
        }

        public ActionResult IzmeniVozilo(string markaVozila)
        {
            foreach (Vozilo k in Podaci.vozila)
            {
                if (k.MarkaVozila.Equals(markaVozila))
                {
                    ViewBag.vozilo = k;
                    return View("IzmeniVozilo");
                }

            }
            return View();
        }

        public ActionResult IzmeniProfilVozilo(Vozilo vozilo)
        {
            Vozilo vozilooo = new Vozilo();
            foreach (Vozilo k in Podaci.vozila)
            {
                if (k.MarkaVozila.Equals(vozilo.MarkaVozila))
                {
                    k.MarkaVozila = vozilo.MarkaVozila;
                    k.ModelVozila = vozilo.ModelVozila;
                    k.TipVozila = vozilo.TipVozila;
                    k.BrojMestaUVozilu = vozilo.BrojMestaUVozilu;
                    k.DatumKadJeSlobodnoVozilo = vozilo.DatumKadJeSlobodnoVozilo;
                    k.CenaPoDanu = vozilo.CenaPoDanu;
                    k.Ulica = vozilo.Ulica;
                    k.Broj = vozilo.Broj;
                    k.Mesto = vozilo.Mesto;
                    k.Poster = vozilo.Poster;
                    vozilooo = k;
                    break;
                }

            }

            Vozilo voziloo = new Vozilo();
            Podaci.SaveVozila(voziloo);
            NapraviSesiju();
            ViewBag.vozilo = vozilooo;
            return View("ProfilVozila", Podaci.vozila);
        }



        public ActionResult SearchByMarka(string marka)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["vozila"];
            List<Vozilo> markaFilter = new List<Vozilo>();

            if (marka.Equals(""))
            {
                ViewBag.vozila = vozila;
                markaFilter = vozila;
            }
            else
            {
                foreach (var vozilo in vozila)
                {
                    if (vozilo.MarkaVozila.ToString().Contains(marka))
                    {
                        markaFilter.Add(vozilo);
                    }
                }
                ViewBag.users = markaFilter;
            }

            return View("~/Views/Vozilo/Index.cshtml", markaFilter);
        }


        public ActionResult SearchByMesto(string mesto)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["vozila"];
            List<Vozilo> mestoFilter = new List<Vozilo>();

            if (mesto.Equals(""))
            {
                ViewBag.vozila = vozila;
                mestoFilter = vozila;
            }
            else
            {
                foreach (var vozilo in vozila)
                {
                    if (vozilo.Mesto.ToString().Contains(mesto))
                    {
                        mestoFilter.Add(vozilo);
                    }
                }
                ViewBag.users = mestoFilter;
            }

            return View("~/Views/Vozilo/Index.cshtml", mestoFilter);
        }


        public ActionResult SearchByCena(string cenaod, string cenado)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["vozila"];
            List<Vozilo> cenaFilter = new List<Vozilo>();

            if (cenaod.Equals(""))
            {
                ViewBag.vozila = vozila;
                cenaFilter = vozila;
            }
            else
            {
                int cenaood = Int32.Parse(cenaod);
                foreach (var vozilo in vozila)
                {
                    if (vozilo.CenaPoDanu >= cenaood)
                    {
                        cenaFilter.Add(vozilo);
                    }
                }
                ViewBag.users = cenaFilter;
            }

            return View("~/Views/Vozilo/Index.cshtml", cenaFilter);
        }

        public ActionResult SearchByCenaDo(string cenaod, string cenado)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["vozila"];
            List<Vozilo> cenaFilter = new List<Vozilo>();

            if (cenado.Equals(""))
            {
                ViewBag.vozila = vozila;
                cenaFilter = vozila;
            }
            else
            {
                int cenaodo = Int32.Parse(cenado);
                foreach (var vozilo in vozila)
                {
                    if (vozilo.CenaPoDanu <= cenaodo)
                    {
                        cenaFilter.Add(vozilo);
                    }
                }
                ViewBag.users = cenaFilter;
            }

            return View("~/Views/Vozilo/Index.cshtml", cenaFilter);
        }

        public ActionResult FiltriranjeTipa(string tip)
        {
            List<Vozilo> vozila = (List<Vozilo>)HttpContext.Application["vozila"];
            List<Vozilo> mestoFilter = new List<Vozilo>();

            if (tip.Equals(""))
            {
                ViewBag.vozila = vozila;
                mestoFilter = vozila;
            }
            else
            {
                foreach (var vozilo in vozila)
                {
                    if (vozilo.TipVozila.ToString().Equals(tip))
                    {
                        mestoFilter.Add(vozilo);
                    }
                }
                ViewBag.users = mestoFilter;
            }

            return View("~/Views/Vozilo/Index.cshtml", mestoFilter);
        }

        public ActionResult Sortiraj(string tipSortiranja)
        {
            if (tipSortiranja == "opadajuce")
            {
                List<Vozilo> sortirano = new List<Vozilo>();

                List<Vozilo> lista = Podaci.vozila;

                while (lista.Count != 0)
                {
                    Vozilo m = lista[0];

                    foreach (Vozilo item in lista)
                    {
                        if (item.CenaPoDanu > m.CenaPoDanu)
                        {
                            m = item;
                        }
                    }

                    sortirano.Add(m);
                    lista.Remove(m);
                }

                ViewBag.vozila = sortirano;
                Podaci.ReadProducts("~/App_Data/vozila.txt");
                return View("~/Views/Vozilo/Index.cshtml", sortirano);
            }
            else if (tipSortiranja == "rastuce")
            {
                List<Vozilo> sortirano = new List<Vozilo>();

                List<Vozilo> lista = Podaci.vozila;

                while (lista.Count != 0)
                {
                    Vozilo a = lista[0];

                    foreach (Vozilo item in lista)
                    {
                        if (item.CenaPoDanu < a.CenaPoDanu)
                        {
                            a = item;
                        }
                    }

                    sortirano.Add(a);
                    lista.Remove(a);
                }

                Podaci.ReadProducts("~/App_Data/vozila.txt");
                return View("~/Views/Vozilo/Index.cshtml", sortirano);

            }

            return View("~/Views/Vozilo/Index.cshtml");
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