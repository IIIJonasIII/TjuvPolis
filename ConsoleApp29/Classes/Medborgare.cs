using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TjuvOchPolis;
internal class Medborgare : Person
{
    public int Money { get; set; }
    public Medborgare(List<string> inventory, int xdirection, int ydirection, int money) : base(inventory, xdirection, ydirection)
    {   
        Money = money;
    }
}
