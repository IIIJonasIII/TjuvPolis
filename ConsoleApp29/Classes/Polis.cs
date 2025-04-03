using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Polis : Person
{
    public int ThiefsCaught { get; set; }
    public Polis(List<string> inventory, int xdirection, int ydirection, int thiefsCaught) : base(inventory, xdirection, ydirection)
    {
        ThiefsCaught = thiefsCaught;
    }
}
