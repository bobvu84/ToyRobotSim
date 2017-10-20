using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public interface IRobot
    {
        bool Place(int x, int y, Directions f, AbstractTable table);
        Position Move();
        Directions Turn(TurnTo turn);
        Directions Turn(TurnTo turn, Directions currentDirection);
        Position Report();


    }
}
