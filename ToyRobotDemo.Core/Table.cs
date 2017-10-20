using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotDemo.Core
{
    public class Table: AbstractTable
    {
      
        public override bool IsValid(int x, int y)
        {
            return base.validPositions.Contains(Tuple.Create(x, y));            
        }

        public override bool Create(int a, int b)
        {
            if (a <=0 || b <= 0)
            {
                return false;
            } else
            {
                base.x = a;
                base.y = b;
                base.validPositions = new List<Tuple<int, int>>();
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        base.validPositions.Add(Tuple.Create(i, j));
                    }
                }
                return true;
            }
        }

        public override bool Create(int a, int b, List<Tuple<int, int>> blockPoints)
        {
            if (a <= 0 || b <= 0)
            {
                return false;
            }
            else
            {
                base.x = a;
                base.y = b;
                base.validPositions = new List<Tuple<int, int>>();
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        var item = Tuple.Create(i, j);
                        if (!blockPoints.Contains(item)) {
                            base.validPositions.Add(Tuple.Create(i, j));
                        }                        
                    }
                }
                return true;
            }
        }
    }
}
