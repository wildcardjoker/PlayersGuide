// Create a 3x3 grid

var rooms = new[,] {{0, 1, 2}, {0, 1, 2}};

// Set locations
var fountainLocation = new Point(0, 2);
var entranceLocation = new Point(0, 0);
var currentLocation  = entranceLocation;

// Simulate the player moving to the room
Console.WriteLine(currentLocation);
Move(Direction.East);
Console.WriteLine(currentLocation);
Move(Direction.East);
Console.WriteLine(currentLocation);

// Check that we are at the Fountain's location.
Console.WriteLine(currentLocation == fountainLocation);

// Move in the specified direction
// TODO: Check for boundaries and prevent movement outside the grid
void Move(Direction direction)
{
    switch (direction)
    {
        case Direction.North:
            currentLocation = currentLocation with {Column = currentLocation.Row + 1};
            break;
        case Direction.South:
            currentLocation = currentLocation with {Column = currentLocation.Row - 1};
            break;
        case Direction.East:
            currentLocation = currentLocation with {Column = currentLocation.Column + 1};
            break;
        case Direction.West:
            currentLocation = currentLocation with {Column = currentLocation.Column - 1};
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}

// Create a simple object to hold the player's location
internal record Point(int Row, int Column)
{
    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => $"You are in the room at (Row={Row}, Column={Column})";
    #endregion
}

// Compass Directions
internal enum Direction
{
    North,
    South,
    East,
    West
}