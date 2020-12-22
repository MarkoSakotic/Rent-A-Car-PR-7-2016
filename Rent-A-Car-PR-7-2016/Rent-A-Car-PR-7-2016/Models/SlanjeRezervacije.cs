using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class SlanjeRezervacije
    {
        public int IdVozila { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public SlanjeRezervacije()
        {

        }

        public SlanjeRezervacije(int idVozila, DateTime datumRezervacije)
        {
            IdVozila = idVozila;
            DatumRezervacije = datumRezervacije;
        }
    }
}