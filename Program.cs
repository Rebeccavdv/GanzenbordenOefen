namespace Ganzenbord
{
    internal class Program
    {
        public static Spel spel;
        static void Main()
        {
            // Instantieer een spel en start het
            spel = new Spel();
            spel.StartSpel();
        }
    }
}
