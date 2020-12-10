using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class MestoVozila
    {
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public int PostanskiBroj { get; set; }

        public MestoVozila() { }

        public MestoVozila(string ulica, string broj, string naseljenoMesto, int postanskiBroj)
        {
            this.Ulica = ulica;
            this.Broj = broj;
            this.Mesto = naseljenoMesto;
            this.PostanskiBroj = postanskiBroj;
        }

    }
}