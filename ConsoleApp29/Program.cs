using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test1();


            int sizeY = 27;
            int sizeX = 100;

            int polisX = 10;
            int polisY = 10;

            int tjuvX = 15;
            int tjuvY = 15;

            int civilX = 20;
            int civilY = 20;

            Console.SetWindowSize(sizeX, sizeY);

            Console.SetBufferSize(sizeX, sizeY);
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

                Thread.Sleep(100);
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

        private static void test1()
        {
            int sizeY = 25;
            int sizeX = 100;

            string[,] spelPlan = new string[sizeX, sizeY];

            int polisX = 10;
            int polisY = 10;

            int tjuvX = 15;
            int tjuvY = 15;

            int civilX = 20;
            int civilY = 20;

            // setting the window size 
            Console.SetWindowSize(sizeX, sizeY);

            // setting buffer size of console 
            Console.SetBufferSize(sizeX, sizeY);

            while (true)
            {

                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        spelPlan[i, j] = " ";
                    }
                }

                spelPlan[civilX, civilY] = "C";
                spelPlan[tjuvX, tjuvY] = "T";
                spelPlan[polisX, polisY] = "P";


                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(spelPlan[i, j]);
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(100);

                polisX = MoveRight(polisX, sizeX);
                //polisX = MoveLeft(polisX, sizeX);
                polisY = MoveUp(polisY, sizeY);
                //polisY = MoveDown(polisY, sizeY);

                //tjuvX = MoveRight(tjuvX, sizeX);
                tjuvX = MoveLeft(tjuvX, sizeX);
                //tjuvY = MoveUp(tjuvY, sizeY);
                tjuvY = MoveDown(tjuvY, sizeY);

                civilX = MoveRight(civilX, sizeX);
                //civilX = MoveLeft(civilX, sizeX);
                //civilY = MoveUp(civilY, sizeY);
                //civilY = MoveDown(civilY, sizeY);

            }
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
            if (Y == 3)
                Y = sizeY-1;
            else
                Y--;

            return Y;
        }
        public static int MoveDown(int Y, int sizeY)
        {
            if (Y == sizeY - 1)
                Y = 3;
            else
                Y++;

            return Y;
        }
        
    }
}
