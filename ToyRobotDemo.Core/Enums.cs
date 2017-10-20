using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{

    public enum Directions{
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    public enum Commands
    {
        PLACE,
        MOVE,
        REPORT,
        LEFT, 
        RIGHT
    }

    public enum TurnTo
    {
        LEFT, 
        RIGHT
    }
    
}
