using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public abstract class AbstractTable
    {
        protected int x { get; set; }
        protected int y { get; set; }
        protected List<Tuple<int, int>> validPositions { get; set; }

        
        public abstract bool IsValid(int x, int y);
        public abstract bool Create(int a, int b);
        public abstract bool Create(int a, int b, List<Tuple<int,int>> blockPoints);
    }
}
