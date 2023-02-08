var point1 = new Point(2,  3);
var point2 = new Point(-4, 0);

Console.WriteLine($"Point 1: {point1.Coordinates}");
Console.WriteLine($"Point 2: {point2.Coordinates}");

//- **Answer this question **: Are your `x` and `y` properties immutable? Why did you choose what you did?
Console.WriteLine("\nX and Y properties are not immutable, as they do not represent fixed points in space.");
Console.WriteLine("Rather, they indicate the coordinates of an object, which has the ability to move in space.");

public class Point
{
    #region Constructors
    public Point() : this(0, 0) {}

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    #endregion

    #region Properties
    public string Coordinates => $"({X},{Y})";
    public int    X           {get; set;}
    public int    Y           {get; set;}
    #endregion
}