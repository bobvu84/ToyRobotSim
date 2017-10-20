using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public class Position
    {
        public Position(int x, int y, Directions f)
        {
            X = x;
            Y = y;
            F = f;
        }

        public Position()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Directions F { get; set; }
        

    }
}
