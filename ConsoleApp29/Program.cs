using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using TjuvOchPolis;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlaySound();
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
");
        }
        static void PlaySound()
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
    }
}
