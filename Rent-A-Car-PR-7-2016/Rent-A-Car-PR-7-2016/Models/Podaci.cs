﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Rent_A_Car_PR_7_2016.Models
{
    public class Podaci
    {
        public static List<Korisnik> korisnici;
        public static List<Vozilo> vozila;
        public Korisnik TrenutniKorisnik { get; set; }
        public Vozilo TrenutnaVozilo { get; set; }

        public static List<Korisnik> ReadUsers(string path)
        {
            //List<Korisnik> korisnici = new List<Korisnik>();
            korisnici = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(tokens[0], tokens[1], tokens[2], tokens[3], (PolOsobe)Enum.Parse(typeof(PolOsobe), tokens[4]), DateTime.Parse(tokens[5]), (UlogaKorisnika)Enum.Parse(typeof(UlogaKorisnika), tokens[6]), bool.Parse(tokens[7]));
                korisnici.Add(p);
            }
            sr.Close();
            stream.Close();

            return korisnici;
        }


        public static void SaveUser(Korisnik korisnik)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/korisnici.txt");
            FileStream stream = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);

            foreach (Korisnik k in korisnici)
            {
                sw.WriteLine(k.KorisnickoIme + ";" + k.Loznika + ";" + k.Ime + ";" + k.Prezime + ";" + k.Pol + ";" + k.DatumRodjenja + ";" + k.Uloga + ";" + k.Obrisano + ";");

            }

            sw.Close();
            stream.Close();
        }

        public static List<Vozilo> ReadProducts(string path)
        {
            vozila = new List<Vozilo>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                //MestoOdrzavanja mestoodrzavanja = new MestoOdrzavanja(tokens[7], tokens[8], tokens[9], int.Parse(tokens[10]));
                Vozilo p = new Vozilo(tokens[0], tokens[1], tokens[2], (TipVozila)Enum.Parse(typeof(TipVozila), tokens[3]), int.Parse(tokens[4]), DateTime.Parse(tokens[5]), int.Parse(tokens[6]), bool.Parse(tokens[7]), tokens[8], tokens[9], tokens[10], int.Parse(tokens[11]), tokens[12], bool.Parse(tokens[13]), bool.Parse(tokens[14]));
                vozila.Add(p);
            }
            sr.Close();
            stream.Close();

            return vozila;
        }

        public static void SaveVozila(Vozilo vozilo)
        {
            //ReadProducts("~/App_Data/manifestacije.txt");
            //manifestacije.Add(manifestacija);
            string path = HostingEnvironment.MapPath("~/App_Data/vozila.txt");
            FileStream stream = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);

            int id = 0;

            foreach (Vozilo m in vozila)
            {
                sw.WriteLine(id + ";" + m.MarkaVozila + ";" + m.ModelVozila + ";" + m.TipVozila + ";" + m.BrojMestaUVozilu + ";" + m.DatumKadJeSlobodnoVozilo + ";" + m.CenaPoDanu + ";" + m.Status + ";" + m.Ulica + ";" + m.Broj + ";" + m.Mesto + ";" + m.PostanskiBroj + ";" + m.Poster + ";" + m.Obrisano + ";" + m.Aktivno + ";");
                id++;
            }

            sw.Close();
            stream.Close();
        }

    }
}