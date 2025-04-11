using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Fånge : Person
{
    public Fånge(Tjuv tjuv, Stack<string> inventory) : base(inventory)
    {
        Xdirection = 84;
        Ydirection = 15;
        riktning = tjuv.riktning;
        Name = tjuv.Name;
        Inventory = inventory;
        symbol = "T";
    }
    public void PositionWithSymbol()
    {
        Console.SetCursorPosition(Xdirection, Ydirection);
        PrintColor();
    }
    public void PrintColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(symbol);
        Console.ResetColor();
    }
    public override int MoveRight(int Xdirection)
    {
        if (Xdirection == 99)
            Xdirection = 69;
        else
            Xdirection++;

        return Xdirection;
    }
    public override int MoveLeft(int Xdirection)
    {
        if (Xdirection == 69)
            Xdirection = 99;
        else
            Xdirection--;

        return Xdirection;
    }
    public override int MoveUp(int Ydirection)
    {
        if (Ydirection == 7)
            Ydirection = 24;
        else
            Ydirection--;

        return Ydirection;
    }
    public override int MoveDown(int Ydirection)
    {
        if (Ydirection == 24)
            Ydirection = 7;
        else
            Ydirection++;

        return Ydirection;
    }

}
