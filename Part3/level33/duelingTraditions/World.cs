// duelingTraditions

namespace duelingTraditions;

internal static partial class DuelingTraditions
{
    private static void ConfigureWorld()
    {
        SetEntranceLocation();
        SetFountainLocation();
        SetPitLocations();
        SetMaelstromLocations();
        SetAmarokLocations();
    }

    private static void CreateWorld()
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

    private static void SetAmarokLocations()
    {
        _amarokLocations = _worldSize switch
        {
            WorldSize.Large  => new List<Point> {new (1, 3), new (3, 1), new (6, 5)},
            WorldSize.Medium => new List<Point> {new (0, 1), new (3, 3)},
            WorldSize.Small  => new List<Point> {new (1, 0)},
            _                => new List<Point> {new (1, 0)}
        };
    }

    private static void SetEntranceLocation()
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

    private static void SetFountainLocation()
    {
        _fountainLocation = _worldSize switch
        {
            WorldSize.Large  => new Point(5, 2),
            WorldSize.Medium => new Point(2, 0),
            WorldSize.Small  => new Point(0, 2),
            _                => new Point(0, 2)
        };
    }

    private static void SetMaelstromLocations()
    {
        _maelstromLocations = _worldSize switch
        {
            WorldSize.Large  => new List<Point> {new (1, 5), new (4, 2)},
            WorldSize.Medium => new List<Point> {new (2, 1)},
            WorldSize.Small  => new List<Point> {new (1, 2)},
            _                => new List<Point> {new (1, 2)}
        };
    }

    private static void SetPitLocations()
    {
        _pitLocations = _worldSize switch
        {
            WorldSize.Large  => new List<Point> {new (1, 1), new (3, 5), new (4, 3), new (6, 0)},
            WorldSize.Medium => new List<Point> {new (1, 3), new (5, 5)},
            WorldSize.Small  => new List<Point> {new (2, 1)},
            _                => new List<Point> {new (2, 1)}
        };
    }
}