using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Vozilo
    {
        public string Id { get; set; }
        public string MarkaVozila { get; set; }
        public string ModelVozila { get; set; }
        public TipVozila TipVozila { get; set; }
        public int BrojMestaUVozilu { get; set; }
        public DateTime DatumKadJeSlobodnoVozilo { get; set; }
        public int CenaPoDanu { get; set; }
        public bool Status { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public int PostanskiBroj { get; set; }
        public string Poster { get; set; }
        public bool Obrisano { get; set; }
        public bool Aktivno { get; set; }

        public Vozilo()
        {
            Obrisano = false;
            Aktivno = false;
        }

        public Vozilo(string id, string markaVozila, string modelVozila, TipVozila tipVozila, int brojMestaUVozilu, DateTime datumKadJeSlobodnoVozilo, int cenaPoDanu, bool status, string ulica, string broj, string mesto, int postanskiBroj, string poster, bool obrisano, bool aktivno)
        {
            Id = id;
            MarkaVozila = markaVozila;
            ModelVozila = modelVozila;
            TipVozila = tipVozila;
            BrojMestaUVozilu = brojMestaUVozilu;
            DatumKadJeSlobodnoVozilo = datumKadJeSlobodnoVozilo;
            CenaPoDanu = cenaPoDanu;
            Status = status;
            Ulica = ulica;
            Broj = broj;
            Mesto = mesto;
            PostanskiBroj = postanskiBroj;
            Poster = poster;
            Obrisano = obrisano;
            Aktivno = aktivno;
        }

    }

}