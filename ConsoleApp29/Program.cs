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

            while (true)
            {
                PrintPersons(poliser, tjuvar, medborgare);
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
