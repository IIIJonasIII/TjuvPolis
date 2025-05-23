﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TjuvOchPolis;
internal class Medborgare : Person
{
    public string Symbol { get; private set; } = "M";
    public int Money { get; set; }
    public Medborgare(Stack<string> inventory) : base(inventory)
    {

    }
    public void PositionWithSymbol()
    {
        Console.SetCursorPosition(Xdirection, Ydirection);
        PrintColor();
    }
    public void PrintColor()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Symbol);
        Console.ResetColor();
    }
}