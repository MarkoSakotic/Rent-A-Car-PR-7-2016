using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Loznika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public PolOsobe Pol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public UlogaKorisnika Uloga { get; set; }
        public bool Obrisano { get; set; }

        public bool Ulogovan { get; set; }

        public Korisnik()
        {
            KorisnickoIme = "";
            Loznika = "";
            Ulogovan = false;
            Obrisano = false;
        }

        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, PolOsobe pol, DateTime datumRodjenja, UlogaKorisnika uloga, bool obrisan)
        {
            KorisnickoIme = korisnickoIme;
            Loznika = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            Ulogovan = false;
            Obrisano = obrisan;
        }

        public bool Validacija()
        {
            bool result = false;



            return result;


        }

    }
}