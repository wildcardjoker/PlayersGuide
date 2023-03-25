// Create a 4x4 grid

const int    min = 0;
int          max;
var          worldSize       = WorldSize.None;
const string entranceText    = "You see light coming from the cavern entrance.";
const string winText         = "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!";
const string fountainArrival = "You hear water dripping in this room. The Fountain of Objects is here!";
const string fountainActive  = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
const string pitWarning      = "You feel a draft. There is a pit in a nearby room.";
const string pitEndGame      = "You have fallen into a pit and died. The game is over.";
const string status          = "You are in the room at";
Point        fountainLocation;
Point        entranceLocation;
Point        currentLocation;
List<Point>  pitLocations;
var          narrativeItem       = new ColouredItem<string>(string.Empty,               ConsoleColor.Magenta);
var          descriptiveText     = new ColouredItem<string>(string.Empty,               ConsoleColor.White);
var          prompt              = new ColouredItem<string>("What do you want to do? ", ConsoleColor.White);
var          entranceDescription = new ColouredItem<string>(entranceText,               ConsoleColor.Yellow);
var          waterText           = new ColouredItem<string>(fountainArrival,            ConsoleColor.Blue);
var          command             = new ColouredItem<string>(string.Empty,               ConsoleColor.Cyan);
var          error               = new ColouredItem<string>(string.Empty,               ConsoleColor.Red);
var          fountainIsActive    = false;

Console.Title = "The Fountain of Objects";
CreateWorld();

while (!(AtEntrance() && fountainIsActive))
{
    DisplayStatus();
    ParseCommand();
    if (PlayerIsInPit())
    {
        error.SetItem(pitEndGame);
        error.Display();
        return;
    }
}

// The player has escaped!
narrativeItem.SetItem(winText);
narrativeItem.Display();
Console.ResetColor();

// End of main program. The remaining code contains supporting methods
void CreateWorld()
{
    // Get enum values and convert to a List - remove WorldSize.None or the loop will exit immediately
    var worlds = Enum.GetNames(typeof(WorldSize)).Where(world => !world.Equals("None")).ToList();
    Console.WriteLine("The following game sizes are available:");
    foreach (var world in worlds)
    {
        Console.WriteLine(world);
    }

    while (worldSize == WorldSize.None)
    {
        Console.Write("What size would you like to use? (Use Capitalisation) ");
        Enum.TryParse(typeof(WorldSize), Console.ReadLine(), out var desiredWorldSize);
        worldSize = (WorldSize) (desiredWorldSize ?? WorldSize.None);
    }

    Console.WriteLine($"Using a {worldSize} world.\n");

    // Because the world grid uses a 0-based index, we need to subtract 1 from the World Size.
    max = (int) worldSize - 1;
    ConfigureWorld();
}

void ConfigureWorld()
{
    SetEntranceLocation();
    SetFountainLocation();
    SetPitLocations();
}

void SetEntranceLocation()
{
    entranceLocation = worldSize switch
    {
        WorldSize.Large  => new Point(2,   max),
        WorldSize.Medium => new Point(max, 1),
        WorldSize.Small  => new Point(0,   0),
        _                => new Point(0,   0)
    };
    currentLocation = entranceLocation;
}

void SetPitLocations()
{
    pitLocations = worldSize switch
    {
        WorldSize.Large  => new List<Point> {new (1, 1), new (3, 5), new (4, 3), new (6, 0)},
        WorldSize.Medium => new List<Point> {new (1, 3), new (5, 5)},
        WorldSize.Small  => new List<Point> {new Point(2, 1)},
        _                => new List<Point> {new Point(2, 1)}
    };
}

void SetFountainLocation()
{
    fountainLocation = worldSize switch
    {
        WorldSize.Large  => new Point(5, 2),
        WorldSize.Medium => new Point(2, 0),
        WorldSize.Small  => new Point(0, 2),
        _                => new Point(0, 2)
    };
}

// Is the player at the entrance?
bool AtEntrance() => currentLocation == entranceLocation;

// Is the player at the Fountain's location?
bool AtFountainLocation() => currentLocation == fountainLocation;

// After receiving the player's command, process it and display an error if the command input isn't valid or can't be performed.
void ParseCommand()
{
    descriptiveText.SetItem(string.Empty);
    prompt?.Display(false);
    var input = command.GetInput();
    var result = input?.ToLower() switch
    {
        "move north"      => Move(Direction.North),
        "move south"      => Move(Direction.South),
        "move east"       => Move(Direction.East),
        "move west"       => Move(Direction.West),
        "enable fountain" => EnableFountain(),
        _                 => "invalid command"
    };

    if (PlayerIsNearPit())
    {
        descriptiveText.SetItem(pitWarning);
    }

    if (string.IsNullOrWhiteSpace(result))
    {
        return;
    }

    // There was a problem processing the command - display an error message.
    error?.SetItem(result);
    error?.Display();
}

// Activate the fountain if the player is at the Fountain's location.
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

// Inform the player of their location, any descriptive text for this room, and whether they are in the presence of the Fountain.
void DisplayStatus()
{
    Console.ResetColor();
    Console.WriteLine("--------------------------------------------------------------------------------------");
    narrativeItem?.SetItem($"{status} {currentLocation}");
    narrativeItem?.Display();
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
    // Is this a valid move?
    if (!CanMove(direction))
    {
        return "A wall blocks your path. You cannot move in that direction.";
    }

    // Update the current location based on the desired direction.
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

bool PlayerIsInPit() => pitLocations.Contains(currentLocation);

bool PlayerIsNearPit()
{
    // Modified from https://www.royvanrijn.com/blog/2019/01/longest-path/
    // Create a 3x3 grid
    // 0 1 2
    // 3 4 5
    // 6 7 8
    for (var direction = 0; direction < 9; direction++)
    {
        if (direction == 4)
        {
            continue; // Skip 4, this is the middle (our location).
        }

        // Using mod 3 will convert the row/column values to between 0-2
        // 0 1 2     -1 0 1
        // 0 1 2  => -1 0 1
        // 0 1 2     -1 0 1

        // Subtracting 1 will set the range to -1 - 1
        // 0 0 0     -1 -1 -1
        // 1 1 1  =>  0  0  0
        // 2 2 2      1  1  1

        // With 0 marking the middle, we can use these values to determine the neighbouring values
        var nRow = currentLocation.Row    + (direction / 3 - 1);
        var nCol = currentLocation.Column + (direction % 3 - 1);

        // Check the bounds:
        if (nRow >= 0 && nRow < (int) worldSize && nCol >= 0 && nCol < (int) worldSize)
        {
            var neighbour = new Point(nRow, nCol);
            if (!pitLocations.Contains(neighbour))
            {
                continue;
            }

            // We found a pit - no need to iterate through the remaining neighbours
            return true;
        }
    }

    return false;
}

// Determine whether the player can move in this direction
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

internal enum WorldSize
{
    None   = 0,
    Small  = 4,
    Medium = 6,
    Large  = 8
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
    ///     Update the item related to this object.
    /// </summary>
    /// <param name="item">The item.</param>
    public void SetItem(T item) => Item = item;

    #region Overrides of Object
    /// <inheritdoc />
    public override string? ToString() => Item?.ToString();
    #endregion
}