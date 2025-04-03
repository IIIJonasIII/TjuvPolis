using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Tjuv : Person
{
    public int StolenItems { get; set; }
    public Tjuv(List<string> inventory, int xdirection, int ydirection, int stolenItems) : base(inventory, xdirection, ydirection)
    {
        StolenItems = stolenItems;
    }
}
