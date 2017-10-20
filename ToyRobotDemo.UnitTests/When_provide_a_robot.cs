using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotDemo.Core;

namespace ToyRobotDemo.UnitTests
{
    [TestClass]
    public class When_provide_a_robot
    {
        private IRobot _robot;
        private AbstractTable _table;        
        public When_provide_a_robot()
        {
            _table = new Table();
            _table.Create(5, 5);
            _robot = new Robot();
        }


        [TestMethod]
        public void Its_moving_area_should_says_if_a_position_is_valid()
        {
            //Test placing robot on the board
            Assert.AreEqual(false, _table.IsValid(2, 5));
            Assert.AreEqual(false, _table.IsValid(-1, 0));
            Assert.AreEqual(true, _table.IsValid(2, 3));
        }

        [TestMethod]
        public void It_should_be_able_to_turn_around()
        {
            _robot.Place(2, 3, Directions.NORTH, _table);
            //Test placing robot on the board
            Assert.AreEqual(Directions.EAST, _robot.Turn(TurnTo.RIGHT));
            Assert.AreEqual(Directions.SOUTH, _robot.Turn(TurnTo.RIGHT));
            Assert.AreEqual(Directions.WEST, _robot.Turn(TurnTo.RIGHT));
            Assert.AreEqual(Directions.NORTH, _robot.Turn(TurnTo.RIGHT));
            Assert.AreEqual(Directions.WEST, _robot.Turn(TurnTo.LEFT));
            Assert.AreEqual(Directions.SOUTH, _robot.Turn(TurnTo.LEFT));
        }

        [TestMethod]
        public void It_should_be_able_to_move_and_ignore_invalid_moves()
        {
            _robot.Place(2, 3, Directions.NORTH, _table);
            Position pos = new Position();
            pos = _robot.Move();
            Assert.AreEqual(2, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.NORTH, pos.F);
            //Ignore any move that makes the robot fall
            pos = _robot.Move();
            Assert.AreEqual(2, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.NORTH, pos.F);
            //Ignore
            pos = _robot.Move();
            Assert.AreEqual(2, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.NORTH, pos.F);
            //turn right & move
            _robot.Turn(TurnTo.RIGHT);
            pos = _robot.Move();
            Assert.AreEqual(3, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.EAST, pos.F);
            //Move
            pos = _robot.Move();
            Assert.AreEqual(4, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.EAST, pos.F);
            //Ignore this invalid move 
            pos = _robot.Move();
            Assert.AreEqual(4, pos.X);
            Assert.AreEqual(4, pos.Y);
            Assert.AreEqual(Directions.EAST, pos.F);
            //turn right and move
            _robot.Turn(TurnTo.RIGHT);
            pos = _robot.Move();
            Assert.AreEqual(4, pos.X);
            Assert.AreEqual(3, pos.Y);
            Assert.AreEqual(Directions.SOUTH, pos.F);
        }
    }
}
