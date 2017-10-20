using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotDemo.Core;

namespace ToyRobotDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependencies
            AbstractTable table;
            IRobot toyRobot;
            ISimulator sim;
            
            
            //Create a new table
            table = new Table();
            table.Create(5, 5);
            
            //Create a new Robot
            toyRobot = new Robot();
            
            //Start the simulation
            sim = new Simulator(table, toyRobot);
            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("Enter a command below");

            bool cont = true;
            while (cont)
            {
                String inputString = Console.ReadLine();
                if (String.Equals("EXIT", inputString, StringComparison.OrdinalIgnoreCase))
                {
                    cont = false;
                }
                else
                {
                    try
                    {
                        String outputVal = sim.TakeCommand(inputString);
                        Console.WriteLine(outputVal);
                    }
                    catch (ToyRobotException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }
    }
}
