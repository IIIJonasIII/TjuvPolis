using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Stad
    {
        public List<Polis> poliser = new List<Polis>();
        public List<Tjuv> tjuvar = new List<Tjuv>();
        public List<Medborgare> medborgare = new List<Medborgare>();
        public List<Fånge> fangelse = new List<Fånge>();

        Stack<string> inventory = new Stack<string>(["Klocka", "Telefon", "Pengar", "Nycklar"]);
        Stack<string> inventoryTjuv = new Stack<string>([]);

        public int fikaPaus = 1;
        public int hastighet = 200;


        public void StartGame()
        {
            while (true)
            {
                PushKey();
                PrintStatus();
                PrintPersons();
                Check();     
                Thread.Sleep(hastighet);
            }
        }

        public Stad()
        {
            for (int i = 0; i < 7; i++)
                poliser.Add(new Polis(new Stack<string>(inventory)));

            for (int i = 0; i < 12; i++)
                tjuvar.Add(new Tjuv(new Stack<string>(inventoryTjuv)));

            for (int i = 0;i < 15; i++)
                medborgare.Add(new Medborgare(new   Stack<string>(inventory)));

        }
        public void PushKey()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.T:
                        tjuvar.Add(new Tjuv(new Stack<string>(inventoryTjuv)));
                        break;
                    case ConsoleKey.R:
                        if (tjuvar.Count > 0)
                        {
                            tjuvar[tjuvar.Count - 1].Position();
                            tjuvar.Remove(tjuvar[tjuvar.Count - 1]);
                        }
                        break;
                    case ConsoleKey.M:
                        medborgare.Add(new Medborgare(new Stack<string>(inventory)));
                        break;
                    case ConsoleKey.N:
                        if (medborgare.Count > 0)
                        {
                            medborgare[medborgare.Count - 1].Position();
                            medborgare.Remove(medborgare[medborgare.Count - 1]);
                        }
                        break;
                    case ConsoleKey.P:
                        poliser.Add(new Polis(new Stack<string>(inventory)));
                        break;
                    case ConsoleKey.O:
                        if (poliser.Count > 0)
                        {
                            poliser[poliser.Count - 1].Position();
                            poliser.Remove(poliser[poliser.Count - 1]);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        PlaySound();
                        break;
                    case ConsoleKey.S:
                        if (hastighet < 1000)
                            hastighet += 50;
                        break;
                    case ConsoleKey.A:
                        if (hastighet >= 50)
                            hastighet -= 50;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void PlaySound()
        {
            string filePath = Path.Combine("Audio", "cityaudio.mp3");
            
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found {filePath}");

            Task.Run(() =>
            {
                using (var audioFile = new AudioFileReader(filePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    outputDevice.PlaybackStopped += (sender, e) =>
                    {
                        audioFile.Position = 0;
                        outputDevice.Play();
                    };
                    while (true)
                    {
                        Thread.Sleep(100);
                    }
                }
            });

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
            Console.WriteLine($"Poliser: {poliser.Count}   ");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine($"Tjuvar: {tjuvar.Count}   ");

            Console.SetCursorPosition(2, 9);
            Console.WriteLine($"Medborgare: {medborgare.Count}   ");

            Console.SetCursorPosition(2, 10);
            Console.WriteLine($"Fångar: {fangelse.Count}    ");

            Console.SetCursorPosition(2, 14);
            Console.WriteLine($"Hastighet: {hastighet}    ");

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
