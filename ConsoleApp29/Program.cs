using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TjuvOchPolis;

namespace ConsoleApp29
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Persons inom Y-axeln 27-50, X-axeln 1-99
            //NEWS X-axel = 2 till 65, Y-axel = 17 till 24
            //STATUS X-axel = 2 till 65, Y-axel = 7 till 14
            //PRISON X-axel = 69 till 99, Y-axel = 7 till 24


            int sizeY = 51;

            int sizeX = 100;

            int polisX = 40;
            int polisY = 40;

            int tjuvX = 40;
            int tjuvY = 40;

            int civilX = 40;
            int civilY = 40;

            Console.SetWindowSize(sizeX, sizeY);

            Console.SetBufferSize(sizeX, sizeY);
            Console.CursorVisible = false;
            
            
            PrintFrame();

            while (true)
            {
             
                Console.SetCursorPosition(polisX, polisY);
                Console.Write(" ");

                Console.SetCursorPosition(tjuvX, tjuvY);
                Console.Write(" ");

                Console.SetCursorPosition(civilX, civilY);
                Console.Write(" ");

                polisY = MoveUp(polisY, sizeY);

                tjuvY = MoveDown(tjuvY, sizeY);
                tjuvX = MoveLeft(tjuvX, sizeX);

                civilX = MoveRight(civilX, sizeX);

                Console.SetCursorPosition(polisX, polisY);
                PrintBlue("P");

                Console.SetCursorPosition(tjuvX, tjuvY);
                PrintRed("T");

                Console.SetCursorPosition(civilX, civilY);
                PrintGreen("C");

                Thread.Sleep(200);
            }
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

        private static void PrintBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(text);
            Console.ResetColor();
        }
        private static void PrintGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();
        }
        private static void PrintRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
        }

        public static int MoveRight(int X, int sizeX)
        {
            if (X == sizeX-1)
                X = 1;
            else
                X++;

            return X;
        }
        public static int MoveLeft(int X, int sizeX)
        {
            if (X == 1)
                X = sizeX-1;
            else
                X--;

            return X;
        }
        public static int MoveUp(int Y, int sizeY)
        {
            if (Y == 27)
                Y = sizeY-1;
            else
                Y--;

            return Y;
        }
        public static int MoveDown(int Y, int sizeY)
        {
            if (Y == sizeY - 1)
                Y = 27;
            else
                Y++;

            return Y;
        }

    }
}
