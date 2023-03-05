// Create a 3x3 grid

var rooms = new[,] {{0, 1, 2}, {0, 1, 2}};

// Set locations
const string entranceText        = "You see light coming from the cavern entrance.";
const string winText             = "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!";
const string fountainArrival     = "You hear water dripping in this room. The Fountain of Objects is here!";
const string fountainActive      = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
const string status              = "You are in the room at";
var          fountainLocation    = new Point(0, 2);
var          entranceLocation    = new Point(0, 0);
var          currentLocation     = entranceLocation;
var          narrativeItem       = new ColouredItem<string>(string.Empty,               ConsoleColor.Magenta);
var          descriptiveText     = new ColouredItem<string>(string.Empty,               ConsoleColor.White);
var          prompt              = new ColouredItem<string>("What do you want to do? ", ConsoleColor.White);
var          entranceDescription = new ColouredItem<string>(entranceText,               ConsoleColor.Yellow);
var          waterText           = new ColouredItem<string>(fountainArrival,            ConsoleColor.Blue);

// Simulate the player moving to the room
DisplayStatus();
GetCommand();
Move(Direction.East);

DisplayStatus();
Move(Direction.East);
DisplayStatus();

// Simulate fountain commands.
if (AtFountainLocation())
{
    waterText.SetItem(fountainActive);
    DisplayStatus();
}

Console.ResetColor();

bool AtEntrance()         => currentLocation == entranceLocation;
bool AtFountainLocation() => currentLocation == fountainLocation;

string? GetCommand()
{
    prompt?.Display(false);
    Console.ForegroundColor = ConsoleColor.Cyan;
    return Console.ReadLine();
}

void SetStatus() => narrativeItem?.SetItem($"{status} {currentLocation}");

void DisplayStatus()
{
    SetStatus();
    narrativeItem.Display();
    var description = descriptiveText.ToString();
    if (!string.IsNullOrWhiteSpace(description))
    {
        descriptiveText.Display();
    }

    if (AtEntrance())
    {
        entranceDescription.Display();
    }

    if (AtFountainLocation())
    {
        waterText.Display();
    }
}

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
        case Direction.Unknown:
        default:
            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}

// Create a simple object to hold the player's location
internal record Point(int Row, int Column)
{
    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => $"(Row={Row}, Column={Column})";
    #endregion
}

// Compass Directions
internal enum Direction
{
    North,
    South,
    East,
    West,
    Unknown
}

/// <summary>
///     Assign a colour to any item type.
/// </summary>
/// <typeparam name="T">The item type to be coloured.</typeparam>
public class ColouredItem<T>
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColouredItem{T}" /> class.
    /// </summary>
    /// <param name="item">The item to be colourised.</param>
    /// <param name="color">The color.</param>
    public ColouredItem(T item, ConsoleColor color)
    {
        Item       = item;
        ItemColour = color;
    }
    #endregion

    #region Properties
    private T            Item       {get; set;}
    private ConsoleColor ItemColour {get;}
    #endregion

    /// <summary>
    ///     Change the console colour to the object's specified colour.
    /// </summary>
    public void Display(bool newLine = true)
    {
        Console.ForegroundColor = ItemColour;
        Console.Write(Item?.ToString());
        if (newLine)
        {
            Console.WriteLine();
        }
    }

    /// <summary>
    ///     Update the item related to this object. In this project, we need to update the Current Location.
    /// </summary>
    /// <param name="item">The item.</param>
    public void SetItem(T item) => Item = item;

    #region Overrides of Object
    /// <inheritdoc />
    public override string? ToString() => Item?.ToString();
    #endregion
}