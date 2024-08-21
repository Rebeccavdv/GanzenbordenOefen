using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public class Speler
    {
        public string Naam { get; set; }
        public int Positie { get; set; }
        public int BeurtenOverslaan { get; set; }
        public int LaatsteWorp { get; set; }
        public Speler(string naam)
        {
            Naam = naam;
            Positie = 0;
            BeurtenOverslaan = 0;
            LaatsteWorp = 0;
        }

        public void Verplaats(int aantalStappen)
        {
            Positie += aantalStappen;
            LaatsteWorp = aantalStappen;         
            if (Positie > 63)
            {
               int terug = Positie - 63;
               Positie = 63 - terug;
            }
            Console.WriteLine($"Speler {Naam} is nu op positie {Positie}");
        }
    }
}
