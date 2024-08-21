using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public class GewoonVakje : Vakje
    {
        public GewoonVakje(int nummer) : base(nummer) { }
        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Speler {speler.Naam} is op een gewoon vakje.");
        }
    }
}
