﻿const int    min = 0;
int          max;
var          numberOfArrows       = 5;
var          worldSize            = WorldSize.None;
const string amarokEndGame        = "You have been torn apart by an amarok and died.";
const string amarokWarning        = "You can smell the rotten stench of an amarok in a nearby room.";
const string entranceText         = "You see light coming from the cavern entrance.";
const string winText              = "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!";
const string fountainArrival      = "You hear water dripping in this room. The Fountain of Objects is here!";
const string fountainActive       = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
const string maelstromPlayerMoved = "You encountered a maelstrom! You have been blown 1 space North and 2 spaces East";
const string maelstromWarning     = "You hear the growling and groaning of a maelstrom nearby.";
const string pitWarning           = "You feel a draft. There is a pit in a nearby room.";
const string pitEndGame           = "You have fallen into a pit and died.";
const string status               = "You are in the room at";
Point        fountainLocation;
Point        entranceLocation;
Point        currentLocation;
List<Point>  amarokLocations;
List<Point>  pitLocations;
List<Point>  maelstromLocations;
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

DisplayIntroduction();

while (!(AtEntrance() && fountainIsActive))
{
    DisplayStatus();
    ParseCommand();
    if (PlayerIsInPit())
    {
        DisplayEndGame(pitEndGame);
        return;
    }

    if (PLayerEncounteredAmarok())
    {
        DisplayEndGame(amarokEndGame);
        return;
    }
}

// The player has escaped!
narrativeItem.SetItem(winText);
narrativeItem.Display();
Console.ResetColor();

// End of main program. The remaining code contains supporting methods
void DisplayIntroduction()
{
    Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.");
    Console.WriteLine("Light is visible in the entrance, and no other light is seen anywhere in the caverns.");
    Console.WriteLine("You must navigate the Caverns with your other senses.");
    Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
    Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. if you enter a room with a pit, you will die.");
    Console.WriteLine(
        "Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.");
    Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.");
    Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns, but be warned: you have a limited supply.");
}

void DisplayEndGame(string ending)
{
    error.SetItem($"{ending} The game is over.");
    error.Display();
    Console.ResetColor();
}

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
    SetMaelstromLocations();
    SetAmarokLocations();
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
        WorldSize.Small  => new List<Point> {new (2, 1)},
        _                => new List<Point> {new (2, 1)}
    };
}

void SetAmarokLocations()
{
    amarokLocations = worldSize switch
    {
        WorldSize.Large  => new List<Point> {new (1, 3), new (3, 1), new (6, 5)},
        WorldSize.Medium => new List<Point> {new (0, 1), new (3, 3)},
        WorldSize.Small  => new List<Point> {new (1, 0)},
        _                => new List<Point> {new (1, 0)}
    };
}

void SetMaelstromLocations()
{
    maelstromLocations = worldSize switch
    {
        WorldSize.Large  => new List<Point> {new (1, 5), new (4, 2)},
        WorldSize.Medium => new List<Point> {new (2, 1)},
        WorldSize.Small  => new List<Point> {new (1, 2)},
        _                => new List<Point> {new (1, 2)}
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
        "shoot north"     => Shoot(Direction.North),
        "shoot south"     => Shoot(Direction.South),
        "shoot east"      => Shoot(Direction.East),
        "shoot west"      => Shoot(Direction.West),
        "enable fountain" => EnableFountain(),
        "help"            => DisplayHelp(),
        _                 => "invalid command"
    };

    if (string.IsNullOrWhiteSpace(result))
    {
        return;
    }

    // There was a problem processing the command - display an error message.
    error?.SetItem(result);
    error?.Display();
}

string DisplayHelp()
{
    Console.ResetColor();
    Console.WriteLine("The following commands are available:");
    Console.WriteLine("move north/south/east/west  - Move in the specified direction.");
    Console.WriteLine("shoot north/south/east/west - Shoot an arrow in the specified direction into the next room. If a monster is in that room, they will be killed.");
    Console.WriteLine("enable fountain             - Activate the Fountain of Objects. Only available in the Fountain Room");
    Console.WriteLine("help                        - Display this help text");
    return string.Empty;
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
    narrativeItem?.SetItem($"You have {numberOfArrows} arrow{(numberOfArrows == 1 ? string.Empty : "s")} left");
    narrativeItem?.Display();

    if (AtEntrance())
    {
        entranceDescription.Display();
    }

    if (NearSpecialLocation(pitLocations))
    {
        DisplayDescriptiveText(pitWarning);
    }

    if (NearSpecialLocation(maelstromLocations))
    {
        DisplayDescriptiveText(maelstromWarning);
    }

    if (NearSpecialLocation(amarokLocations))
    {
        DisplayDescriptiveText(amarokWarning);
    }

    if (AtFountainLocation())
    {
        waterText.Display();
    }
}

void DisplayDescriptiveText(string text)
{
    descriptiveText.SetItem(text);
    descriptiveText.Display();
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

    // If this location contains a maelstrom, move the player and maelstrom
    if (PlayerEncounteredMaelstrom())
    {
        TriggerMaelstromBattle();
    }

    return string.Empty;
}

// Shot an arrow in the specified direction
string Shoot(Direction direction)
{
    if (numberOfArrows == 0)
    {
        error.SetItem("You don't have any more arrows.");
        error.Display();
        return string.Empty;
    }

    var targetLocation = direction switch
    {
        Direction.North   => currentLocation with {Row = Math.Clamp(currentLocation.Row       - 1, 0, max)},
        Direction.South   => currentLocation with {Row = Math.Clamp(currentLocation.Row       + 1, 0, max)},
        Direction.East    => currentLocation with {Column = Math.Clamp(currentLocation.Column + 1, 0, max)},
        Direction.West    => currentLocation with {Column = Math.Clamp(currentLocation.Column - 1, 0, max)},
        Direction.Unknown => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
        _                 => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
    maelstromLocations.Remove(targetLocation);
    amarokLocations.Remove(targetLocation);
    numberOfArrows--;
    return string.Empty;
}

bool PlayerIsInPit() => pitLocations.Contains(currentLocation);

bool PLayerEncounteredAmarok() => amarokLocations.Contains(currentLocation);

bool PlayerEncounteredMaelstrom() => maelstromLocations.Contains(currentLocation);

bool NearSpecialLocation(ICollection<Point> specialLocations)
{
    // Modified from https://www.royvanrijn.com/blog/2019/01/longest-path/
    // TODO: Incorporate into a Function library - this is a really useful method!
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
            if (!specialLocations.Contains(neighbour))
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

void TriggerMaelstromBattle()
{
    // Move maelstrom 1 South, 2 West
    maelstromLocations.Remove(currentLocation);
    var row = Math.Clamp(currentLocation.Row    + 1, 0, max);
    var col = Math.Clamp(currentLocation.Column - 2, 0, max);
    maelstromLocations.Add(new Point(row, col));

    // Move player 1 North, 2 East
    row             = Math.Clamp(currentLocation.Row    - 1, 0, max);
    col             = Math.Clamp(currentLocation.Column + 2, 0, max);
    currentLocation = new Point(row, col);
    DisplayDescriptiveText(maelstromPlayerMoved);
}

#region Internal declarations
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
#endregion

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