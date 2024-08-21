using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord
{
    public class Spel
    {
        public List<Speler> Spelers { get; set; }
        public List<Vakje> Bord { get; set; }
        public Dobbelsteen Dobbelsteen { get; set; }

        public Spel()
        {
            Spelers = new List<Speler>();
            Bord = new List<Vakje>();
            Dobbelsteen = new Dobbelsteen();

            // Initieer het bord met verschillende vakjes
            for (int i = 0; i < 64; i++)
            {


                if (i == 6)
                    Bord.Add(new BrugVakje(i));
                else if (i == 19)
                    Bord.Add(new HerbergVakje(i));
                else if (i == 31)
                    Bord.Add(new PutVakje(i));
                else if (i == 63)
                    Bord.Add(new EindVakje(i));
          else if (IsGansVakje(i))
                    Bord.Add(new GansVakje(i));
                else
                    Bord.Add(new GewoonVakje(i));
            }
        }

        public static bool IsGansVakje(int nummer)
        {
            // Controleer of het vakje een gansvakje is
            int[] gansVakjes = { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };
            return gansVakjes.Contains(nummer);
        }


        
        
        
        public void StartSpel()
        {
            // Vraag het aantal spelers en hun namen op
            int aantalSpelers = 2; // Voor nu hardcoded naar 2, kan uitgebreid worden
            for (int i = 1; i <= aantalSpelers; i++)
            {
                Console.Write($"Voer de naam van speler {i} in: ");
                string naam = Console.ReadLine();
                Spelers.Add(new Speler(naam));
            }

            bool spelActief = true;
            while (spelActief)
            {
                foreach (var speler in Spelers)
                {
                    SpeelBeurt(speler);
                    if (speler.Positie == 63)
                    {
                        Console.WriteLine($"Speler {speler.Naam} heeft gewonnen!");
                        spelActief = false;
                        break;
                    }
                }
            }
        }


        public void SpeelBeurt(Speler speler)
        {
            if (speler.BeurtenOverslaan > 0)
            {
                Console.WriteLine($"Speler {speler.Naam} moet nog {speler.BeurtenOverslaan} beurt(en) overslaan.");
                speler.BeurtenOverslaan--;
                return;
            }

            // Dobbelsteen gooien
            int worp1 = Dobbelsteen.Gooi();
            int worp2 = Dobbelsteen.Gooi();
            int worp = worp1 + worp2;

            Console.WriteLine($"Speler {speler.Naam} gooit {worp1} en {worp2} (totaal: {worp})");

            // Speler verplaatsen
            speler.Verplaats(worp);

            // Actie van het vakje waar de speler op terechtkomt
            Bord[speler.Positie].Actie(speler);

            // Controle op speciale gevallen zoals in de put of het winnen van het spel
            if (speler.Positie == 63)
            {
                Console.WriteLine($"Speler {speler.Naam} heeft het spel gewonnen!");
            }

            Console.WriteLine("Druk op een toets om door te gaan");
            Console.ReadKey(intercept: true);
        }
    }
}