# ToyRobotSim
This Application has three projects:
1. "ToyRobotDemo" 
  - is where the starting point of the program located ("Program.cs") - Go there and press the start button in VS 2015, the program will run.
2. "ToyRobotDemo.Core" 
  - Contains all concepts like Directions (North, South...), Commands (MOVE, LEFT, RIGHT, PLACE...) in "Enum.cs"
  - Contain all the abstractions, interfaces (IRobot, ISimulator, AbstractTable...) and their implementation classes respectively (Robot, Simulator, Table...)
  - Note that you can also create a table with block points on it "Table.Create(int x, int y,List<Tuple<int,int>> blockPoints)
3. "ToyRobotDemo.UnitTests"
  - this project has all the unit tests to test a Robot/Simulator 's behaviors written using MSTest
  - Go there and run the test case normally
  
