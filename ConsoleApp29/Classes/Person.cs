using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TjuvOchPolis;
internal class Person
{
    public static int sizeY = 50;
    public static int sizeX = 99;
    public static Random random = new Random();


    public string Name { get; set; }
    public Stack<string> Inventory { get; set; }
    public int riktning { get; set; } = random.Next(1, 9);
    public int Xdirection { get; set; } = random.Next(1, 100);
    public int Ydirection { get; set; } = random.Next(27, 51);
    public string symbol { get; set; }

    public Person(Stack<string> inventory)
    {
        Name = RandomNamn();
       
        Inventory = inventory;

    }

    public string RandomNamn()
    {
        List<string> PTM = new List<string>() { "Bengt", "Lars", "Eva", "Olof", "Anders", "Kristina", "Göran", "Marianne", "Stefan", "Annika", "Hans", "Carina", "Johan", "Birgitta", "Alex", "Karin", "Joel", "Gunilla", 
            "Joakim", "Janne", "Karin", "Mats", "Stina", "Åsa", "Oskar", "Elin", "Tobias", "Malin", "Fredrik", "Lina", "Björn", "Helena", "Erik", "Jonas", "Kevin", "Rasmus", "Amer", "Ludvig", "Alexander", "Johan", "Mattias", 
            "Emil", "Robin", "Daniel", "Simon", "Oscar", "Niklas", "Patrik", "Andreas", "Marcus", "Erik", "Henrik", "Sebastian" };
         
        return PTM [random.Next(1, PTM.Count)];
        


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
    public virtual int MoveRight(int Xdirection)
    {
        if (Xdirection == sizeX)
            Xdirection = 1;
        else
            Xdirection++;

        return Xdirection;
    }
    public virtual int MoveLeft(int Xdirection)
    {
        if (Xdirection == 1)
            Xdirection = sizeX;
        else
            Xdirection--;

        return Xdirection;
    }
    public virtual int MoveUp(int Ydirection)
    {
        if (Ydirection == 27)
            Ydirection = sizeY;
        else
            Ydirection--;

        return Ydirection;
    }
    public virtual int MoveDown(int Ydirection)
    {
        if (Ydirection == sizeY)
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
