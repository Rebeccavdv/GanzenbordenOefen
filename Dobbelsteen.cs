using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public class Dobbelsteen
    {
        private Random _random;

        public Dobbelsteen()
        {
            _random = new Random();
        }
        public int Gooi()
        {
            return _random.Next(1, 7);
        }
    }
}
