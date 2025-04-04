using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Tjuv : Person
{
    public string Symbol { get; set; } = "T";
    public int StolenItems { get; set; } = 0;
    public Tjuv(List<string> inventory) : base(inventory)
    {
        
    }
    public void PositionWithSymbol()
    {
        Console.SetCursorPosition(Xdirection, Ydirection);
        PrintColor();
    }
    public void PrintColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(Symbol);
        Console.ResetColor();
    }
}
