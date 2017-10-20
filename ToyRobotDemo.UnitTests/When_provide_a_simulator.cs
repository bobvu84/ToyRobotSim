using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotDemo.Core;

namespace ToyRobotDemo.UnitTests
{
    [TestClass]
    public class When_provide_a_simulator
    {
        private IRobot _robot;
        private AbstractTable _table;
        private ISimulator _sim;
        public When_provide_a_simulator()
        {
            _table = new Table();
            _table.Create(5, 5);
            _robot = new Robot();            
            _sim = new Simulator(_table, _robot);

        }
        [TestMethod]
        public void It_should_be_able_to_take_commands_and_give_relevant_outputs()
        {
            _sim.TakeCommand("PLACE 2,2,NORTH");
            Assert.AreEqual("(2,3)",_sim.TakeCommand("MOVE"));
            Assert.AreEqual("(2,4)", _sim.TakeCommand("MOVE"));
            Assert.AreEqual("(2,4)", _sim.TakeCommand("MOVE"));
            Assert.AreEqual("(New direction: EAST)", _sim.TakeCommand("RIGHT"));
            Assert.AreEqual("(3,4)", _sim.TakeCommand("MOVE"));
            Assert.AreEqual("(4,4)", _sim.TakeCommand("MOVE"));
            Assert.AreEqual("(4,4)", _sim.TakeCommand("MOVE"));
            Assert.AreEqual("(New direction: SOUTH)", _sim.TakeCommand("RIGHT"));
            Assert.AreEqual("(New direction: EAST)", _sim.TakeCommand("LEFT"));
        }


        [TestMethod]
        [ExpectedException(typeof(ToyRobotException))]
        public void It_should_throw_exceptions_when_placing_robot_in_wrong_position()
        {
            _sim.TakeCommand("PLACE -1,2,NORTH");
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotException))]
        public void It_should_throw_exceptions_when_giving_wrong_direction()
        {
            _sim.TakeCommand("PLACE -1,2,direction");
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotException))]
        public void It_should_throw_exceptions_when_giving_a_wrong_command()
        {
            _sim.TakeCommand("Aasdc -1");
        }
    }
}
