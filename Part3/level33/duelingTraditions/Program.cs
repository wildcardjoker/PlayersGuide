namespace duelingTraditions;

internal static class DuelingTraditions
{
    #region Constants
    private const int    Min                  = 0;
    private const string AmarokEndGame        = "You have been torn apart by an amarok and died.";
    private const string AmarokWarning        = "You can smell the rotten stench of an amarok in a nearby room.";
    private const string EntranceText         = "You see light coming from the cavern entrance.";
    private const string FountainActive       = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
    private const string FountainArrival      = "You hear water dripping in this room. The Fountain of Objects is here!";
    private const string MaelstromPlayerMoved = "You encountered a maelstrom! You have been blown 1 space North and 2 spaces East";
    private const string MaelstromWarning     = "You hear the growling and groaning of a maelstrom nearby.";
    private const string PitEndGame           = "You have fallen into a pit and died.";
    private const string PitWarning           = "You feel a draft. There is a pit in a nearby room.";
    private const string Status               = "You are in the room at";
    private const string WinText              = "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!";
    #endregion

    #region Fields
    private static readonly ColouredItem<string> Command             = new (string.Empty, ConsoleColor.Cyan);
    private static readonly ColouredItem<string> DescriptiveText     = new (string.Empty, ConsoleColor.White);
    private static readonly ColouredItem<string> EntranceDescription = new (EntranceText, ConsoleColor.Yellow);
    private static readonly ColouredItem<string> Error               = new (string.Empty, ConsoleColor.Red);
    private static readonly ColouredItem<string> NarrativeItem       = new (string.Empty, ConsoleColor.Magenta);
    private static readonly ColouredItem<string> Prompt              = new ("What do you want to do? ", ConsoleColor.White);
    private static readonly ColouredItem<string> WaterText           = new (FountainArrival, ConsoleColor.Blue);

    private static bool        _fountainIsActive;
    private static int         _max;
    private static int         _numberOfArrows = 5;
    private static List<Point> _amarokLocations;
    private static List<Point> _maelstromLocations;
    private static List<Point> _pitLocations;
    private static Point       _currentLocation;
    private static Point       _entranceLocation;
    private static Point       _fountainLocation;
    private static WorldSize   _worldSize = WorldSize.None;
    #endregion

    public static void Main(string[] args)
    {
        Console.Title = "The Fountain of Objects (Dueling Traditions)";
        CreateWorld();

        var startTime = DateTime.Now;
        DisplayIntroduction();

        while (!(AtEntrance() && _fountainIsActive))
        {
            DisplayStatus();
            ParseCommand();
            if (PlayerIsInPit())
            {
                DisplayEndGame(PitEndGame);
                return;
            }

            if (PLayerEncounteredAmarok())
            {
                DisplayEndGame(AmarokEndGame);
                return;
            }
        }

        // The player has escaped!
        NarrativeItem.SetItem(WinText);
        NarrativeItem.Display();
        Console.ResetColor();
        DisplayPlayTime();

        // End of main program. The remaining code contains supporting methods

        void DisplayEndGame(string ending)
        {
            Error.SetItem($"{ending} The game is over.");
            Error.Display();
            Console.ResetColor();
            DisplayPlayTime();
        }

        void DisplayPlayTime()
        {
            var endTime  = DateTime.Now;
            var playTime = endTime - startTime;
            Console.WriteLine($"Your adventure took {playTime.Days}d, {playTime.Hours}h, {playTime.Minutes}m, {playTime.Seconds}s.");
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

            while (_worldSize == WorldSize.None)
            {
                Console.Write("What size would you like to use? (Use Capitalisation) ");
                Enum.TryParse(typeof(WorldSize), Console.ReadLine(), out var desiredWorldSize);
                _worldSize = (WorldSize) (desiredWorldSize ?? WorldSize.None);
            }

            Console.WriteLine($"Using a {_worldSize} world.\n");

            // Because the world grid uses a 0-based index, we need to subtract 1 from the World Size.
            _max = (int) _worldSize - 1;
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
            _entranceLocation = _worldSize switch
            {
                WorldSize.Large  => new Point(2,    _max),
                WorldSize.Medium => new Point(_max, 1),
                WorldSize.Small  => new Point(0,    0),
                _                => new Point(0,    0)
            };
            _currentLocation = _entranceLocation;
        }

        void SetPitLocations()
        {
            _pitLocations = _worldSize switch
            {
                WorldSize.Large  => new List<Point> {new (1, 1), new (3, 5), new (4, 3), new (6, 0)},
                WorldSize.Medium => new List<Point> {new (1, 3), new (5, 5)},
                WorldSize.Small  => new List<Point> {new (2, 1)},
                _                => new List<Point> {new (2, 1)}
            };
        }

        void SetAmarokLocations()
        {
            _amarokLocations = _worldSize switch
            {
                WorldSize.Large  => new List<Point> {new (1, 3), new (3, 1), new (6, 5)},
                WorldSize.Medium => new List<Point> {new (0, 1), new (3, 3)},
                WorldSize.Small  => new List<Point> {new (1, 0)},
                _                => new List<Point> {new (1, 0)}
            };
        }

        void SetMaelstromLocations()
        {
            _maelstromLocations = _worldSize switch
            {
                WorldSize.Large  => new List<Point> {new (1, 5), new (4, 2)},
                WorldSize.Medium => new List<Point> {new (2, 1)},
                WorldSize.Small  => new List<Point> {new (1, 2)},
                _                => new List<Point> {new (1, 2)}
            };
        }

        void SetFountainLocation()
        {
            _fountainLocation = _worldSize switch
            {
                WorldSize.Large  => new Point(5, 2),
                WorldSize.Medium => new Point(2, 0),
                WorldSize.Small  => new Point(0, 2),
                _                => new Point(0, 2)
            };
        }

        // Is the player at the entrance?
        bool AtEntrance() => _currentLocation == _entranceLocation;

        // Is the player at the Fountain's location?
        bool AtFountainLocation() => _currentLocation == _fountainLocation;

        // After receiving the player's command, process it and display an error if the command input isn't valid or can't be performed.
        void ParseCommand()
        {
            DescriptiveText.SetItem(string.Empty);
            Prompt?.Display(false);
            var input = Command.GetInput();
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
            Error?.SetItem(result);
            Error?.Display();
        }

        string DisplayHelp()
        {
            Console.ResetColor();
            Console.WriteLine("The following commands are available:");
            Console.WriteLine("move north/south/east/west  - Move in the specified direction.");
            Console.WriteLine(
                "shoot north/south/east/west - Shoot an arrow in the specified direction into the next room. If a monster is in that room, they will be killed.");
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
            _fountainIsActive = true;
            WaterText.SetItem(FountainActive);
            return string.Empty;
        }

        // Inform the player of their location, any descriptive text for this room, and whether they are in the presence of the Fountain.
        void DisplayStatus()
        {
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------------");
            NarrativeItem?.SetItem($"{Status} {_currentLocation}");
            NarrativeItem?.Display();
            NarrativeItem?.SetItem($"You have {_numberOfArrows} arrow{(_numberOfArrows == 1 ? string.Empty : "s")} left");
            NarrativeItem?.Display();

            if (AtEntrance())
            {
                EntranceDescription.Display();
            }

            if (NearSpecialLocation(_pitLocations))
            {
                DisplayDescriptiveText(PitWarning);
            }

            if (NearSpecialLocation(_maelstromLocations))
            {
                DisplayDescriptiveText(MaelstromWarning);
            }

            if (NearSpecialLocation(_amarokLocations))
            {
                DisplayDescriptiveText(AmarokWarning);
            }

            if (AtFountainLocation())
            {
                WaterText.Display();
            }
        }

        void DisplayDescriptiveText(string text)
        {
            DescriptiveText.SetItem(text);
            DescriptiveText.Display();
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
            _currentLocation = direction switch
            {
                Direction.North   => _currentLocation with {Row = _currentLocation.Row       - 1},
                Direction.South   => _currentLocation with {Row = _currentLocation.Row       + 1},
                Direction.East    => _currentLocation with {Column = _currentLocation.Column + 1},
                Direction.West    => _currentLocation with {Column = _currentLocation.Column - 1},
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
            if (_numberOfArrows == 0)
            {
                Error.SetItem("You don't have any more arrows.");
                Error.Display();
                return string.Empty;
            }

            var targetLocation = direction switch
            {
                Direction.North   => _currentLocation with {Row = Math.Clamp(_currentLocation.Row       - 1, 0, _max)},
                Direction.South   => _currentLocation with {Row = Math.Clamp(_currentLocation.Row       + 1, 0, _max)},
                Direction.East    => _currentLocation with {Column = Math.Clamp(_currentLocation.Column + 1, 0, _max)},
                Direction.West    => _currentLocation with {Column = Math.Clamp(_currentLocation.Column - 1, 0, _max)},
                Direction.Unknown => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                _                 => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
            _maelstromLocations.Remove(targetLocation);
            _amarokLocations.Remove(targetLocation);
            _numberOfArrows--;
            return string.Empty;
        }

        bool PlayerIsInPit() => _pitLocations.Contains(_currentLocation);

        bool PLayerEncounteredAmarok() => _amarokLocations.Contains(_currentLocation);

        bool PlayerEncounteredMaelstrom() => _maelstromLocations.Contains(_currentLocation);

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
                var nRow = _currentLocation.Row    + (direction / 3 - 1);
                var nCol = _currentLocation.Column + (direction % 3 - 1);

                // Check the bounds:
                if (nRow >= 0 && nRow < (int) _worldSize && nCol >= 0 && nCol < (int) _worldSize)
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
        bool CanMove(Direction direction) => (direction    == Direction.North && _currentLocation.Row    != Min)
                                             || (direction == Direction.South && _currentLocation.Row    != _max)
                                             || (direction == Direction.West  && _currentLocation.Column != Min)
                                             || (direction == Direction.East  && _currentLocation.Column != _max);

        void TriggerMaelstromBattle()
        {
            // Move maelstrom 1 South, 2 West
            _maelstromLocations.Remove(_currentLocation);
            var row = Math.Clamp(_currentLocation.Row    + 1, 0, _max);
            var col = Math.Clamp(_currentLocation.Column - 2, 0, _max);
            _maelstromLocations.Add(new Point(row, col));

            // Move player 1 North, 2 East
            row              = Math.Clamp(_currentLocation.Row    - 1, 0, _max);
            col              = Math.Clamp(_currentLocation.Column + 2, 0, _max);
            _currentLocation = new Point(row, col);
            DisplayDescriptiveText(MaelstromPlayerMoved);
        }
    }

    private static void DisplayIntroduction()
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

    #region Internal declarations
    // Create a simple object to hold the player's location

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
}
#endregion