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
                PrintStatus();
                PrintPersons();
                Check();     
                PrintPrison();         
                PrintNews();           
                Thread.Sleep(200);
            }
        }


        public List<Polis> poliser = new List<Polis>();
        public List<Tjuv> tjuvar = new List<Tjuv>();
        public List<Medborgare> medborgare = new List<Medborgare>();

        public List<Tjuv> fangelse = new List<Tjuv>();

        public Stad()
        {
            for (int i = 0; i < 5; i++)
                poliser.Add(new Polis(new List<string>()));

            for (int i =0; i < 10; i++)
                tjuvar.Add(new Tjuv(new List<string>()));

            for (int i = 0;i < 10; i++)
                medborgare.Add(new Medborgare(new List<string>()));
        }

        public void Start()
        {
            while (true)
            {
                PrintStatus();
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
        
        public void PrintStatus()
        {
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("''''''''''''''''''''''''''''''Status''''''''''''''''''''''''''''''");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Poliser: " + "A");

            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Tjuvar: " + "B");

            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Medborgare: " + "C");

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
            int rad = 8;
            Console.SetCursorPosition(69, 7);
            Console.WriteLine("Fängelse:");

            foreach (var fånge in fangelse)
            {
                Console.SetCursorPosition(69, rad++);
                Console.WriteLine($"- {fånge.Name}");
            }

            
            for (int i = rad; i < 25; i++)
            {
                Console.SetCursorPosition(69, i);
                Console.WriteLine("                          ");
            }
        }


  

        public void Check()
        {
            
            foreach (var polis in poliser)
            {
                foreach (var tjuv in tjuvar.ToList()) 
                {
                    if (polis.Xdirection == tjuv.Xdirection && polis.Ydirection == tjuv.Ydirection)
                    {
                        Console.SetCursorPosition(2, 18);
                        Console.WriteLine($"Polis {polis.Name} grep tjuven {tjuv.Name}!");

                        tjuvar.Remove(tjuv);
                        fangelse.Add(tjuv); 
                    }

                }
            }

            
            foreach (var tjuv in tjuvar)
            {
                foreach (var medb in medborgare.ToList())
                {
                    if (tjuv.Xdirection == medb.Xdirection && tjuv.Ydirection == medb.Ydirection)
                    {
                        Console.SetCursorPosition(2, 19);
                        Console.WriteLine($"Tjuven {tjuv.Name} rånade medborgaren {medb.Name}!");

                        medborgare.Remove(medb);

                       
                        tjuv.Inventory.Add("Plånbok");
                    }
                }
            }
        }




    }
}
