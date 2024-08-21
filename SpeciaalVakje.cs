using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public abstract class SpeciaalVakje : Vakje
    {
        public SpeciaalVakje(int nummer) : base(nummer) { }
    }

    public class BrugVakje : SpeciaalVakje
    {
        public BrugVakje(int nummer) : base(nummer) { }

        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Speler {speler.Naam} is op de brug! Springt vooruit naar vakje 12.");
            speler.Verplaats(12 - speler.Positie);
        }
    }
    public class HerbergVakje : SpeciaalVakje
    {
        public HerbergVakje(int nummer) : base(nummer) { }

        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Speler {speler.Naam} is in de herberg! Sla een beurt over.");
            speler.BeurtenOverslaan = 1;
        }
    }
    public class PutVakje : SpeciaalVakje
    {
        public PutVakje(int nummer) : base(nummer) { }

        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Speler {speler.Naam} is in de put gevallen! Wacht op hulp.");
            speler.BeurtenOverslaan = int.MaxValue; // Wachten tot een andere speler op dezelfde positie komt.
        }
    }
    public class EindVakje : SpeciaalVakje
    {
        public EindVakje(int nummer) : base(nummer) { }

        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Gefeliciteerd {speler.Naam}, je hebt gewonnen!");
            // Eventueel logica toevoegen om het spel te beëindigen.
        }
    }
    public class GansVakje : SpeciaalVakje
    {
        public GansVakje(int nummer) : base(nummer) { }

        public override void Actie(Speler speler)
        {
            Console.WriteLine($"Speler {speler.Naam} is op een gans vakje! Nogmaals {speler.LaatsteWorp} stappen vooruit.");
            speler.Verplaats(speler.LaatsteWorp);
        }
    }


}
