Console.Title = "The Old Robot";
Console.WriteLine(Console.Title);

// Create a set of valid commands
var validCommands = new[] {"on", "off", "stop", "north", "south", "east", "west"};

// Create a new robot
var robot = new Robot();

DisplayValidCommands();

// Enter the commands for the robot, as determined by the user
for (var i = 0; i < numCommands; i++)
{
    robot.Commands[i] = GetCommand();
}

Console.WriteLine();

// Initiate the Robot's command list.
robot.Run();

IRobotCommand GetCommand()
{
    // Assume that the user has entered a valid command.
    // We should include validation and error handling here, but it's just an exercise.
    Console.Write("Please enter a command: ");
    return Console.ReadLine() switch
    {
        "on"    => new OnCommand(),
        "off"   => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east"  => new EastCommand(),
        "west"  => new WestCommand(),
        "stop"  => null
    };
}

void DisplayValidCommands()
{
    Console.WriteLine("\n\nValid robot commands are:");
    foreach (var command in validCommands)
    {
        Console.WriteLine($"\t{command}");
    }
}

public class Robot
{
    #region Properties
    public List<IRobotCommand> Commands  {get;} = new List<IRobotCommand>();
    public bool                IsPowered {get; set;}
    public int                 X         {get; set;}
    public int                 Y         {get; set;}
    #endregion

    public void Run()
    {
        foreach (var command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
    #endregion
}

public class OffCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
    #endregion
}

public class NorthCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
    #endregion
}

public class SouthCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
    #endregion
}

public class EastCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
    #endregion
}

public class WestCommand : IRobotCommand
{
    #region IRobotCommand Members
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
    #endregion
}

public class StopCommand : IRobotCommand
{
    #region IRobotCommand Members
    #region Implementation of IRobotCommand
    /// <inheritdoc />
    public void Run(Robot robot)
    {
        throw new NotImplementedException();
    }
    #endregion
    #endregion
}