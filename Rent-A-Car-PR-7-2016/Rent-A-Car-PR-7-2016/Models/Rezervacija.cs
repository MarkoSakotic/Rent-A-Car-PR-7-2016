using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Rezervacija
    {
        public int IdKarte { get; set; }
        public Vozilo Vozilo { get; set; }
        public DateTime DatumKadJeSlobodnoVozilo { get; set; }
        public int CenaPoDanu { get; set; }
        public Korisnik Kupac { get; set; }
        public StatusRezervacije Status { get; set; }

        public Rezervacija()
        {

        }

        public Rezervacija(int idKarte, Vozilo vozilo, DateTime datumKadJeSlobodnoVozilo, int cenaPoDanu, Korisnik kupac, StatusRezervacije status)
        {
            IdKarte = IdKarte;
            Vozilo = vozilo;
            DatumKadJeSlobodnoVozilo = datumKadJeSlobodnoVozilo;
            CenaPoDanu = cenaPoDanu;
            Kupac = kupac;
            Status = status;
        }

    }
}