var coordinate1 = new Coordinate(0, 0);
var coordinate2 = new Coordinate(0, 1);
var coordinate3 = new Coordinate(0, 2);
var coordinate4 = new Coordinate(1, 0);
var coordinate5 = new Coordinate(1, 1);
var coordinate6 = new Coordinate(1, 2);
var coordinate7 = new Coordinate(1, 3);
var coordinate8 = new Coordinate(1, 4);

Console.WriteLine("These coordinates should be adjacent:");
Console.WriteLine(AdjacentResult(coordinate1, coordinate2));
Console.WriteLine(AdjacentResult(coordinate2, coordinate3));
Console.WriteLine(AdjacentResult(coordinate1, coordinate4));
Console.WriteLine(AdjacentResult(coordinate4, coordinate5));
Console.WriteLine(AdjacentResult(coordinate5, coordinate6));
Console.WriteLine(AdjacentResult(coordinate6, coordinate7));
Console.WriteLine(AdjacentResult(coordinate7, coordinate8));

Console.WriteLine("\nThese coordinates should not be adjacent");
Console.WriteLine(AdjacentResult(coordinate1, coordinate3));
Console.WriteLine(AdjacentResult(coordinate2, coordinate6));
Console.WriteLine(AdjacentResult(coordinate4, coordinate6));
Console.WriteLine(AdjacentResult(coordinate6, coordinate8));
Console.WriteLine(AdjacentResult(coordinate1, coordinate5));
Console.WriteLine(AdjacentResult(coordinate3, coordinate7));
Console.WriteLine(AdjacentResult(coordinate1, coordinate8));

string AdjacentResult(Coordinate sourceCoordinate, Coordinate destinationCoordinate) =>
    $"({sourceCoordinate.X},{sourceCoordinate.Y}) {(sourceCoordinate.IsAdjacent(destinationCoordinate) ? "is" : "is not")} Adjacent to ({destinationCoordinate.X},{destinationCoordinate.Y})";

internal readonly struct Coordinate
{
    public int X {get;}
    public int Y {get;}

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    ///     Determines whether the specified Coordinate is adjacent.
    /// </summary>
    /// <param name="other">The other coordinate.</param>
    /// <returns>
    ///     <c>true</c> if the specified other is adjacent; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     Determine whether the X points are within 1 point of each other *and* the Y point is the same, or whether the Y
    ///     points are within 1 point of each other and the X point is the same.
    ///     We're using an OR value here - only ONE of these calculations can be true. If both are false, or both are true, the
    ///     blocks aren't adjacent
    ///     For example:
    ///     (0,0) and (0,1)  == Adjacent
    ///     (0,1) and (-1,1) == Adjacent
    ///     (0,0) and (0,2)  != Adjacent
    ///     (0,0) and (-2,0) != Adjacent
    ///     (0,0) and (1,1)  != Adjacent
    /// </remarks>
    public bool IsAdjacent(Coordinate other) => Math.Abs(X - other.X) == 1 && (Y == other.Y) | (Math.Abs(Y - other.Y) == 1) && X == other.X;
}