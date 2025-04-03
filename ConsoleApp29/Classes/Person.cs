using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Person
{
    public List<string> Inventory { get; set; }
    public int Xdirection { get; set; }
    public int Ydirection { get; set; }

    public Person(List<string> inventory, int xdirection, int ydirection)
    {
        Inventory = inventory;
        Xdirection = xdirection;
        Ydirection = ydirection;
    }

   

}
