using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Fånge : Person
{
    public int sizeY = 24;
    public int sizeX = 99;
    public Fånge(Tjuv tjuv, Stack<string> inventory) : base(inventory)
    {
        Xdirection = random.Next(70, sizeX);
        Ydirection = random.Next(8, sizeY);
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
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(symbol);
        Console.ResetColor();
    }
    public override int MoveRight(int Xdirection)
    {
        if (Xdirection == sizeX)
            Xdirection = 69;
        else
            Xdirection++;

        return Xdirection;
    }
    public override int MoveLeft(int Xdirection)
    {
        if (Xdirection == 69)
            Xdirection = sizeX;
        else
            Xdirection--;

        return Xdirection;
    }
    public override int MoveUp(int Ydirection)
    {
        if (Ydirection == 7)
            Ydirection = sizeY;
        else
            Ydirection--;

        return Ydirection;
    }
    public override int MoveDown(int Ydirection)
    {
        if (Ydirection == sizeY)
            Ydirection = 7;
        else
            Ydirection++;

        return Ydirection;
    }

}
