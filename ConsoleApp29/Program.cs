﻿using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TjuvOchPolis;

namespace ConsoleApp29
{
    internal class Program
    {
        //Om konsolen krashar(Windows powershell): Starta konsolen, tryck på pil ner (vid flikarna), settings, Launch size,
        //Sätt columns till 120 och rows till 60
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            PrintFrame();

            Stad stad = new Stad();
            stad.StartGame();

        }
        private static void PrintHeadLine()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
@"  ____ ___ _______   __                                        ____ ____   ___  _   _ ____    _  _   
 / ___|_ _|_   _\ \ / /                                       / ___|  _ \ / _ \| | | |  _ \  | || |  
| |    | |  | |  \ V /                                       | |  _| |_) | | | | | | | |_) | | || |_ 
| |___ | |  | |   | |                                        | |_| |  _ <| |_| | |_| |  __/  |__   _|
 \____|___| |_|   |_|                                         \____|_| \_\\___/ \___/|_|        |_|  ");
            Console.ResetColor();
        }
        private static void PrintFrame()
        {
            PrintHeadLine();
            Console.WriteLine(
@"
╔════════════════════════════ STATUS ═════════════════════════════╗ ╔═══════════ PRISON ════════════╗
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
║                                                                 ║ ║                               ║
╚═════════════════════════════════════════════════════════════════╝ ║                               ║
╔═════════════════════════════ NEWS ══════════════════════════════╗ ║                               ║
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
╔═════════════════════════════════════════════ CONTROLS ════════════════════════════════════════════╗
║   Key: R/T = Ta bort/lägg till tjuv                   Key: A/S = Öka/sänk farten                  ║
║   Key: O/P = Ta bort/lägg till polis                  Key: Mellanslag = Musik                     ║
║   Key: N/M = Ta bort/lägg till medborgare             Key: Escape = Avsluta                       ║
╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝
");
        }
        
    }
}
