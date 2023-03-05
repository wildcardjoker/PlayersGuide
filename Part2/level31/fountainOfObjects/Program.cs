// Create a 4x4 grid

var       rooms = new[,] {{0, 1, 2, 3}, {0, 1, 2, 3}};
const int min   = 0;
const int max   = 3;

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
var          command             = new ColouredItem<string>(string.Empty,               ConsoleColor.Cyan);
var          error               = new ColouredItem<string>(string.Empty,               ConsoleColor.Red);
var          fountainIsActive    = false;

while (!(AtEntrance() && fountainIsActive))
{
    // Simulate the player moving to the room
    DisplayStatus();
    ParseCommand();
}

narrativeItem.SetItem(winText);
narrativeItem.Display();
Console.ResetColor();

bool AtEntrance()         => currentLocation == entranceLocation;
bool AtFountainLocation() => currentLocation == fountainLocation;

void ParseCommand()
{
    var input = GetCommand();
    var result = input?.ToLower() switch
    {
        "move north"      => Move(Direction.North),
        "move south"      => Move(Direction.South),
        "move east"       => Move(Direction.East),
        "move west"       => Move(Direction.West),
        "enable fountain" => EnableFountain(),
        _                 => "invalid command"
    };

    if (string.IsNullOrWhiteSpace(result))
    {
        return;
    }

    error?.SetItem(result);
    error?.Display();
}

string? EnableFountain()
{
    if (!AtFountainLocation())
    {
        return "You cannot touch the fountain. Your command has no effect.";
    }

    // Activate the Fountain
    fountainIsActive = true;
    waterText.SetItem(fountainActive);
    return string.Empty;
}

string? GetCommand()
{
    prompt?.Display(false);
    return command.GetInput();
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
string Move(Direction direction)
{
    if (currentLocation == null)
    {
        return "I don't know what your current location is!";
    }

    // Is this a valid move?
    if (!CanMove(direction))
    {
        return "A wall blocks your path. You cannot move in that direction.";
    }

    currentLocation = direction switch
    {
        Direction.North   => currentLocation with {Row = currentLocation.Row       - 1},
        Direction.South   => currentLocation with {Row = currentLocation.Row       + 1},
        Direction.East    => currentLocation with {Column = currentLocation.Column + 1},
        Direction.West    => currentLocation with {Column = currentLocation.Column - 1},
        Direction.Unknown => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        _                 => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
    return string.Empty;
}

bool CanMove(Direction direction) => (direction    == Direction.North && currentLocation.Row    != min)
                                     || (direction == Direction.South && currentLocation.Row    != max)
                                     || (direction == Direction.West  && currentLocation.Column != min)
                                     || (direction == Direction.East  && currentLocation.Column != max);

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
    ///     Gets the input.
    /// </summary>
    /// <returns></returns>
    public string? GetInput()
    {
        Console.ForegroundColor = ItemColour;
        return Console.ReadLine();
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