using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Stad
    {
        public static int fikaPaus = 1;
        public void StartGame()
        {
            while (true)
            {
                PrintStatus();
                PrintPersons();
                Check();     
                //PrintPrison();         
                //PrintNews();
                Thread.Sleep(200);
            }
        }


        public List<Polis> poliser = new List<Polis>();
        public List<Tjuv> tjuvar = new List<Tjuv>();
        public List<Medborgare> medborgare = new List<Medborgare>();
        public List<Fånge> fangelse = new List<Fånge>();

        public Stad()
        {
            Stack<string> inventory = new Stack<string>(["Klocka", "Telefon", "Pengar", "Nycklar"]);
            Stack<string> inventoryTjuv = new Stack<string>([]);

            for (int i = 0; i < 7; i++)
                poliser.Add(new Polis(new Stack<string>(inventory)));

            for (int i = 0; i < 12; i++)
                tjuvar.Add(new Tjuv(new Stack<string>(inventoryTjuv)));

            for (int i = 0;i < 15; i++)
                medborgare.Add(new Medborgare(new   Stack<string>(inventory)));

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
            foreach (var fånge in fangelse)
            {
                fånge.Position();
                fånge.RandomDirection();
                fånge.PositionWithSymbol();
            }
        }
        
        public void PrintStatus()
        {
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("''''''''''''''''''''''''''''''Status''''''''''''''''''''''''''''");
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
            Console.SetCursorPosition(2, 18);
            Console.SetCursorPosition(2, 19);
            Console.SetCursorPosition(2, 20);
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
                        Console.SetCursorPosition(2, 17);
                        Console.WriteLine($"Polis {polis.Name} grep tjuven {tjuv.Name}!         ");

                        if (tjuv.Inventory.Count() > 0) 
                        {
                            tjuv.Inventory.Clear();
                            tjuvar.Remove(tjuv);
                            fangelse.Add(new Fånge(tjuv, new Stack<string>([])));
                        }
                        else
                        {
                            Console.SetCursorPosition(2, 17);
                            Console.WriteLine($"{tjuv.Name} sprang iväg från Polisen {polis.Name}!      ");
                        }
                        //tjuvar.Remove(tjuv);
                        //fangelse.Add(tjuv);
                        
                    }

                }
            }

            
            foreach (var tjuv in tjuvar)
            {
                foreach (var medb in medborgare.ToList())
                {
                    if (tjuv.Xdirection == medb.Xdirection && tjuv.Ydirection == medb.Ydirection)
                    {
                        Console.SetCursorPosition(2, 18);
                        if (medb.Inventory.Count() < 1)
                            Console.WriteLine($"Medborgaren {medb.Name} slog ner tjuven {tjuv.Name}");
                        else
                        {
                            Console.WriteLine($"Tjuven {tjuv.Name} rånade {medb.Name} på hens {medb.Inventory.Peek()}!            ");
                            string item = medb.Inventory.Pop();
                            tjuv.Inventory.Push(item);
                            Console.SetCursorPosition(2, 20);

                            //Bara för att titta om inventoryn uppdateras
                            Console.WriteLine($"{tjuv.Inventory.Count()}"); 
                        }
                    }
                }
            }

            foreach (var medb in medborgare)
            {
                foreach (var polis in poliser.ToList())
                {
                    if (medb.Xdirection == polis.Xdirection && medb.Ydirection == polis.Ydirection)
                    {
                        Console.SetCursorPosition(2, 19);
                        Console.WriteLine($"Medborgaren {medb.Name} hälsade glatt på konstapel {polis.Name}!       ");
                    }

                }
            }

            
            foreach (var polis in poliser)
            {
                foreach (var polisen in poliser.ToList())
                {
                    if (polis.Xdirection == polisen.Xdirection && polis.Ydirection == polisen.Ydirection)
                    {
                        if(polis.Name != polisen.Name)
                        {
                        Console.SetCursorPosition(2, 23);
                        Console.WriteLine($"SKATTEBETALDA FIKAPAUSER: {fikaPaus++ / 2} ");
                        Console.SetCursorPosition(2, 24); 
                        Console.WriteLine($"Konstapel {polis.Name} tog en fika med konstapel {polisen.Name}!        ");
                        }
                        
                    }

                }
            }
        }




    }
}
