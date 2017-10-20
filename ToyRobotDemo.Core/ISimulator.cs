using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public interface ISimulator
    {
        string TakeCommand(string input);
    }
}
