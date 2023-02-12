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