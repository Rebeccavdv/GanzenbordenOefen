using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public abstract class Vakje
    {
        public int Nummer { get; set; }

        public Vakje(int nummer)
        {
            Nummer = nummer;
        }
        public abstract void Actie(Speler speler);
    }
}
