using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis;
internal class Polis : Person
{
    public Polis(List<string> inventory, int xdirection, int ydirection) : base(inventory, xdirection, ydirection)
    {
    }
}
