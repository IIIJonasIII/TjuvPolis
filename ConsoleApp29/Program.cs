using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TjuvOchPolis;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //Console.SetWindowSize(sizeX, sizeY);
            //Console.SetBufferSize(sizeX+1, sizeY+1);
 
            //Persons inom Y-axeln 27-50, X-axeln 1-99
            //NEWS X-axel = 2 till 65, Y-axel = 17 till 24
            //STATUS X-axel = 2 till 65, Y-axel = 7 till 14
            //PRISON X-axel = 69 till 99, Y-axel = 7 till 24

            
            List<Polis> poliser = new List<Polis>();
            for (int i = 0; i < 5; i++)
            {
                poliser.Add(new Polis(new List<string>()));
            }

            List<Tjuv> tjuvar = new List<Tjuv>();
            for (int i = 0; i < 5; i++)
            {
                tjuvar.Add(new Tjuv(new List<string>()));
            }

            List<Medborgare> medborgare = new List<Medborgare>();
            for (int i = 0; i < 5; i++)
            {
                medborgare.Add(new Medborgare(new List<string>()));
            }


            PrintFrame();
            PrintStatus();
            PrintPrison();
            PrintNews();

            while (true)
            {
                PrintPersons(poliser, tjuvar, medborgare);
            }
        }
        private static void PrintStatus()
        {
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("''''''''''''''''''''''''''''''TEST''''''''''''''''''''''''''''''");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Poliser: HarriHaffa, HarriHaffa, HarriHaffa, HarriHaffa");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("Tjuvar: Boven, boven boven boven ");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Medborgare: fisen fisen fisen fisen");
        }
        private static void PrintNews()
        {
            Console.SetCursorPosition(2, 17);
            Console.WriteLine("''''''''''''''''''''''''''''''TEST''''''''''''''''''''''''''''''");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine("Polisen grep Alex");
            Console.SetCursorPosition(2, 19);
            Console.WriteLine("Tjuvarn skrek högt");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("Medborgaren sprang");
        }
        private static void PrintPrison()
        {
            for (int i = 7; i < 25; i++)
            {
                Console.SetCursorPosition(69, i);
                Console.WriteLine("''''''''''''TEST'''''''''''''''");
            }
        }
        private static void PrintPersons(List<Polis> poliser, List<Tjuv> tjuvar, List<Medborgare> medborgare)
        {
            foreach (var polis in poliser)
            {
                polis.Position();
                polis.RandomDirection();
                polis.PositionWithSymbol();
            }

            foreach (var tjyv in tjuvar)
            {
                tjyv.Position();
                tjyv.RandomDirection();
                tjyv.PositionWithSymbol();
            }

            foreach (var medborgar in medborgare)
            {
                medborgar.Position();
                medborgar.RandomDirection();
                medborgar.PositionWithSymbol();
            }
            Thread.Sleep(200);
        }

        private static void PrintFrame()
        {
            Console.WriteLine(@"
  ____ ___ _______   __                                        ____ ____   ___  _   _ ____    _  _   
 / ___|_ _|_   _\ \ / /                                       / ___|  _ \ / _ \| | | |  _ \  | || |  
| |    | |  | |  \ V /                                       | |  _| |_) | | | | | | | |_) | | || |_ 
| |___ | |  | |   | |                                        | |_| |  _ <| |_| | |_| |  __/  |__   _|
 \____|___| |_|   |_|                                         \____|_| \_\\___/ \___/|_|        |_|  
╔═ STATUS ════════════════════════════════════════════════════════╗ ╔═ PRISON ══════════════════════╗
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
╚═════════════════════════════════════════════════════════════════╝ ║                               ║
╔═ NEWS ══════════════════════════════════════════════════════════╗ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
╚═════════════════════════════════════════════════════════════════╝ ╚═══════════════════════════════╝
╔═════════════════════════════════════════════ MAP ═════════════════════════════════════════════════╗
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
║                                                                                                   ║
╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝
");
        }
    }
}
