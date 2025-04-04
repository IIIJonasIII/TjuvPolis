using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Stad
    {
        private List<Polis> poliser = new List<Polis>();
        private List<Tjuv> tjuvar = new List<Tjuv>();
        private List<Medborgare> medborgare = new List<Medborgare>();

        public Stad()
        {
            for (int i = 0; i < 5; i++)
            {
                poliser.Add(new Polis(new List<string>()));
                tjuvar.Add(new Tjuv(new List<string>()));
                medborgare.Add(new Medborgare(new List<string>()));
            }
        }

        public void Start()
        {
            while (true)
            {
                PrintPersons();
                Thread.Sleep(200);
            }
        }

        private void PrintPersons()
        {
            foreach (var polis in poliser)
            {
                polis.Position();             
                polis.RandomDirection();       
                polis.PositionWithSymbol();    
            }

            foreach (var tjuv in tjuvar)
            {
                tjuv.Position();
                tjuv.RandomDirection();
                tjuv.PositionWithSymbol();
            }

            foreach (var civil in medborgare)
            {
                civil.Position();
                civil.RandomDirection();
                civil.PositionWithSymbol();
            }
        }

        public void PrintStatus()
        {
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("''''''''''''''''''''''''''''''STATUS''''''''''''''''''''''''''''");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Poliser: HarriHaffa x5");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Tjuvar: Boven x5");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Medborgare: Fisen x5");
        }

        public void PrintNews()
        {
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("''''''''''''''''''''''''''''''NEWS''''''''''''''''''''''''''''''");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine("Polisen grep Alex");
            Console.SetCursorPosition(2, 19);
            Console.WriteLine("Tjuvarn skrek högt");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("Medborgaren sprang");
        }

        public void PrintPrison()
        {
            for (int i = 7; i < 25; i++)
            {
                Console.SetCursorPosition(69, i);
                Console.WriteLine("''''''''''''TEST'''''''''''''''");
            }
        }
    }
}
