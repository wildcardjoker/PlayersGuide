Console.Title = "The Old Robot";
Console.WriteLine(Console.Title);

// Create a set of valid commands
var validCommands = new[] {"on", "off", "north", "south", "east", "west"};

// Set the number of commands supported by the robot
var numCommands = 3;

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

RobotCommand GetCommand()
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
        "west"  => new WestCommand()
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
    public RobotCommand?[] Commands  {get;} = new RobotCommand?[3];
    public bool            IsPowered {get; set;}
    public int             X         {get; set;}
    public int             Y         {get; set;}
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

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

internal class OnCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
    #endregion
}

internal class OffCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
    #endregion
}

internal class NorthCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
    #endregion
}

internal class SouthCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
    #endregion
}

internal class EastCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
    #endregion
}

internal class WestCommand : RobotCommand
{
    #region Overrides of RobotCommand
    /// <inheritdoc />
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
    #endregion
}