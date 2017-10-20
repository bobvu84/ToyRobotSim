using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public class Simulator : ISimulator
    {
        private AbstractTable _table;
        private IRobot _robot;

        public Simulator(AbstractTable table, IRobot robot)
        {
            this._table = table;
            this._robot = robot;
        }

        public string TakeCommand(string inputString)
        {
            string output = "";
            if (String.IsNullOrEmpty(inputString))
            {
                throw new ToyRobotException("Invalid command");                
            }
           
            //Get arguments 
            String[] args = inputString.Split(' ');
            Commands command;
            try
            {
                command = (Commands)Enum.Parse(typeof(Commands), args[0].ToUpper());
            }
            catch (ArgumentException e)
            {
                throw new ToyRobotException("Invalid command");
            }

            switch (command)
            {
                case Commands.PLACE:
                    if (!Place(args, _robot)) throw new ToyRobotException("Can't place him here");
                    output = "Good!!! now start moving the robot";
                    break;
                case Commands.MOVE:
                    Position newPos = _robot.Move();
                    if (newPos == null)
                    {
                        output = "Put the robot on the table first";
                        throw new ToyRobotException("Put the robot on the table first");
                    }
                    output = String.Format("({0},{1})", newPos.X, newPos.Y);
                    break;
                case Commands.LEFT:
                    output = String.Format("(New direction: {0})", (_robot.Turn(TurnTo.LEFT)).ToString());
                    break;
                case Commands.RIGHT:
                    output = String.Format("(New direction: {0})", (_robot.Turn(TurnTo.RIGHT)).ToString());
                    break;
                case Commands.REPORT:
                    var pos = _robot.Report();
                    output = String.Format("{0},{1},{2}", pos.X, pos.Y, pos.F);
                    break;
                default:
                    throw new ToyRobotException("Invalid command");
            }
            return output;
        }

        private bool Place(string[] args, IRobot _robot)
        {
            if (args != null && args.Length > 0)
            {
                var vals = args[1].Split(',');
                if (vals.Length != 3)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        return _robot.Place(Int32.Parse(vals[0]), Int32.Parse(vals[1]), (Directions)Enum.Parse(typeof(Directions), vals[2].ToUpper()), _table);

                    }
                    catch (Exception e)
                    {
                        throw new ToyRobotException(String.Format("Invalid Direction {0}", e.Message));
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
