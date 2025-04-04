using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Stad
    {
        public void StartGame()
        {
            while (true)
            {
                PrintStatus(poliser,tjuvar,medborgare);
                PrintNews();
                PrintPrison();
                PrintPersons();
                Thread.Sleep(200);
            }
        }


        public List<Polis> poliser = new List<Polis>();
        public List<Tjuv> tjuvar = new List<Tjuv>();
        public List<Medborgare> medborgare = new List<Medborgare>();

        public Stad()
        {
            for (int i = 0; i < 5; i++)
            {
                poliser.Add(new Polis(RandomNamn("Polis"), new List<string>()));

                tjuvar.Add(new Tjuv(RandomNamn("Tjuv"), new List<string>()));

                medborgare.Add(new Medborgare(RandomNamn("Medborgare"), new List<string>()));

            }
        }

        public void Start()
        {
            while (true)
            {
                PrintStatus(poliser, tjuvar, medborgare);
                PrintPersons();
                Thread.Sleep(200);
            }
        }

        public void PrintPersons()
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
        
        public void PrintStatus(List<Polis> poliser, List<Tjuv> tjuvar, List<Medborgare> medborgare)
        {
            Console.SetCursorPosition(2, 7);

            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Poliser: " + string.Join(", ", poliser.Select(p => p.Name)));

            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Tjuvar: " + string.Join(", ", tjuvar.Select(t => t.Name)));

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Medborgare: " + string.Join(", ", medborgare.Select(m => m.Name)));

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

        public string RandomNamn(string klass)
        {
            Random random = new Random();

            List<string> polisNamn = new List<string>() { "Bengt", "Lars", "Eva", "Olof", "Anders", "Kristina", "Göran", "Marianne", "Stefan", "Annika", "Hans", "Carina", "Johan", "Birgitta" };
            List<string> tjuvNamn = new List<string>() { "Jonas", "Kevin", "Rasmus", "Amer", "Ludvig", "Alexander", "Johan", "Mattias", "Emil", "Robin", "Daniel", "Simon", "Oscar", "Niklas", "Patrik", "Andreas", "Marcus", "Erik", "Henrik", "Sebastian" };
            List<string> medborgarNamn = new List<string>() { "Alex", "Karin", "Joel", "Gunilla", "Joakim", "Janne", "Karin", "Mats", "Stina", "Åsa", "Oskar", "Elin", "Tobias", "Malin", "Fredrik", "Lina", "Björn", "Helena", "Erik" };

            if (klass == "Polis")
                return polisNamn[random.Next(polisNamn.Count)];
            else if (klass == "Tjuv")
                return tjuvNamn[random.Next(tjuvNamn.Count)];
            else
                return medborgarNamn[random.Next(medborgarNamn.Count)];




        }

    }
}
