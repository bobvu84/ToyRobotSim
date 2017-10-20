using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public class Robot : IRobot
    {
        private Position _currentPosition;
        private AbstractTable _table;

        public bool Place(int x, int y, Directions f, AbstractTable table)
        {
            if (!table.IsValid(x, y))
            {
                return false;
            }
            else
            {
                _currentPosition = new Position(x, y, f);
                _table = table;
                return true;
            }
        }
        public Position Move()
        {
            if (_currentPosition == null)
            {
                return _currentPosition;
            }
            switch (_currentPosition.F)
            {
                case Directions.SOUTH:
                    if (_table.IsValid(_currentPosition.X, _currentPosition.Y - 1))
                    {
                        _currentPosition.Y --;                       
                    }
                    break;
                case Directions.EAST:
                    if (_table.IsValid(_currentPosition.X + 1, _currentPosition.Y))
                    {
                        _currentPosition.X ++;                      
                    }
                    break;
                case Directions.WEST:
                    if (_table.IsValid(_currentPosition.X - 1, _currentPosition.Y))
                    {
                        _currentPosition.X --;
                    }

                    break;
                case Directions.NORTH:
                    if (_table.IsValid(_currentPosition.X, _currentPosition.Y + 1))
                    {
                        _currentPosition.Y ++;
                    }
                    break;
            }
            return _currentPosition;
        }
        public Directions Turn(TurnTo turn)
        {
            return Turn(turn, _currentPosition.F);
        }
        public Directions Turn(TurnTo turn, Directions currentDirection)
        {
            //Order here is NORTH(1) -> EAST(2) -> SOUTH(3) -> WEST(4) ->NORTH (5/0)
            int nextDirection = (int)_currentPosition.F;
            switch (turn)
            {
                case TurnTo.RIGHT:
                    nextDirection++;
                    if (nextDirection > (int)Directions.WEST) nextDirection = (int)Directions.NORTH ;
                    break;
                case TurnTo.LEFT:
                    nextDirection--;
                    if (nextDirection < (int)Directions.NORTH) nextDirection = (int)Directions.WEST;
                    break;
            }
            _currentPosition.F = (Directions)nextDirection;
            return _currentPosition.F;
        }

        public Position Report()
        {
            return _currentPosition;
        }


    }
}
