using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Rezervacija
    {
        public int IdRezervacije { get; set; }
        public int IdVozilo { get; set; }
        public DateTime DatumKadJeSlobodnoVozilo { get; set; }
        public int BrojDana { get; set; }
        public float CenaPoDanu { get; set; }
        public string  IdKupac { get; set; }
        public StatusRezervacije StatusRezervacija { get; set; }


        public Rezervacija()
        {
            this.BrojDana = 1;
            this.StatusRezervacija = StatusRezervacije.REZERVISANA;
        }
        public Rezervacija(int idRezervacije, int idvozilo)
        {
            IdRezervacije = idRezervacije;
            IdVozilo = idvozilo;
        }

        public Rezervacija(int idRezervacije, int idvozilo, string idkupac, DateTime datumKadJeSlobodnoVozilo, float cenaPoDanu)
        {
            IdRezervacije = idRezervacije;
            IdVozilo = idvozilo;
            IdKupac = idkupac;
            DatumKadJeSlobodnoVozilo = datumKadJeSlobodnoVozilo;
            CenaPoDanu = cenaPoDanu;
        }

        public Rezervacija(int idRezervacije, int idvozilo, DateTime datumKadJeSlobodnoVozilo, int cenaPoDanu, string idkupac, StatusRezervacije status)
        {
            IdRezervacije = idRezervacije;
            IdVozilo = idvozilo;
            DatumKadJeSlobodnoVozilo = datumKadJeSlobodnoVozilo;
            CenaPoDanu = cenaPoDanu;
            IdKupac = idkupac;
            StatusRezervacija = status;
        }

    }
}