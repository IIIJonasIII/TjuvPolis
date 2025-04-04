using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TjuvOchPolis;
internal class Person
{
    public static int sizeY = 51;
    public static int sizeX = 100;
    public static Random random = new Random();


    public string Name { get; set; }
    public List<string> Inventory { get; set; }
    public int riktning { get; set; } = random.Next(1, 9);
    public int Xdirection { get; set; } = random.Next(1, 100);
    public int Ydirection { get; set; } = random.Next(27, 51);
    public string symbol { get; set; }

    public Person(string name, List<string> inventory)
    {
        Name = name;
        Inventory = inventory;
    }


    public void RandomDirection()
    {
       
        switch (riktning)
        {
            case 1:
                Xdirection = MoveRight(Xdirection);
                break;
            case 2:
                Xdirection = MoveLeft(Xdirection);
                break;
            case 3:
                Ydirection = MoveUp(Ydirection);
                break;
            case 4:
                Ydirection = MoveDown(Ydirection);
                break;
            case 5:
                Xdirection = MoveRight(Xdirection);
                Ydirection = MoveUp(Ydirection);
                break;
            case 6:
                Xdirection = MoveLeft(Xdirection);
                Ydirection = MoveUp(Ydirection);
                break;
            case 7:
                Xdirection = MoveRight(Xdirection);
                Ydirection = MoveDown(Ydirection);
                break;
            case 8:
                Xdirection = MoveLeft(Xdirection);
                Ydirection = MoveDown(Ydirection);
                break;
        }
    }
    public int MoveRight(int Xdirection, int sizeX = 100)
    {
        if (Xdirection == sizeX - 1)
            Xdirection = 1;
        else
            Xdirection++;

        return Xdirection;
    }
    public int MoveLeft(int Xdirection, int sizeX = 100)
    {
        if (Xdirection == 1)
            Xdirection = sizeX - 1;
        else
            Xdirection--;

        return Xdirection;
    }
    public int MoveUp(int Ydirection, int sizeY = 51)
    {
        if (Ydirection == 27)
            Ydirection = sizeY - 1;
        else
            Ydirection--;

        return Ydirection;
    }
    public int MoveDown(int Ydirection, int sizeY = 51)
    {
        if (Ydirection == sizeY - 1)
            Ydirection = 27;
        else
            Ydirection++;

        return Ydirection;
    }
    public void Position()
    {
        Console.SetCursorPosition(Xdirection, Ydirection);
        Console.Write(" ");
    }
    

}
