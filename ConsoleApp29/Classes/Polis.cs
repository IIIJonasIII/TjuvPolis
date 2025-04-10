using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Polis : Person
{
    public string Symbol { get; private set; } = "P";
    public int ThiefsCaught { get; set; } = 0;
    public Polis( List<string> inventory) : base(inventory)
    {

    }
    public void PositionWithSymbol()
    {
        Console.SetCursorPosition(Xdirection, Ydirection);
        PrintColor();
    }
    public void PrintColor()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(Symbol);
        Console.ResetColor();
    }
}

