# The Old Robot

You spot something shiny, half-buried in the mud. You pull it out and realise that it seems to be some mechanical automaton with the words "Property of Dynamak" etched into it. As you knock off the caked-on mud, you realise that it seems like this old automaton might even be *programmable* if you can give it the proper commands. The automaton seems to be structured like this:

    public class Robot
    {
        public int             X         {get; set;}
        public int             Y         {get; set;}
        public bool            IsPowered {get; set;}
        public RobotCommand?[] Commands  {get;} = new RobotCommand?[3];

        public void Run()
        {
            foreach (RobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }

You don't see a definition of that `RobotCommand` class. Still, you think you might be able to recreate it (a class with only an abstract `Run` command) and then make derived classes that extend `RobotCommand` that move it in each of the four directions and power it on and off. (You wish you could manufacture a whole army of these!)

## Objectives

- Copy the code above into a new project.
- Create a `RobotCommand` with a public and abstract `void Run(Robot robot)` method. (The code above should compile after this step).
- Make `OnCommand` and `OffCommand` classes that inherit from `RobotCommand` and turn the robot on or off by overriding the `Run` method.
- Make a `NorthCommand`, `SouthCommand`, `WestCommand`, and `EastCommand` that move the robot 1 unit in the `+Y` direction, 1 unit in the `-Y` direction, 1 unit in the `-X` direction, and 1 unit in the `+X` direction, respectively. Also, ensure that these commands only work if the robot's `IsPowered` property is true.
- Make your main method able to collect three commands from the console window. Generate new `RobotCommand` objects based on the text entered. After filling the robot's command set with these new `RobotCommand` objects, use the robot's `Run` method to execute them. For example:

        on
        north
        west

        [0 0 True]
        [0 1 True]
        [-1 1 True]

- **Note**: You might find this strategy for making commands that update other objects useful in some of the larger challenges in the coming levels.
