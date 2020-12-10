using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Lokacija
    {
        public double GeoSirina { get; set; }
        public double GeoDuzina { get; set; }
        public MestoVozila MestoVozila { get; set; }

        public Lokacija()
        {

        }

        public Lokacija(double geoSirina, double geoDuzina, MestoVozila mesto)
        {
            GeoSirina = GeoSirina;
            GeoDuzina = geoDuzina;
            MestoVozila = mesto;
        }

    }
}