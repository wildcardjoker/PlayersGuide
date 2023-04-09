namespace duelingTraditions;

internal static partial class DuelingTraditions
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
    private static DateTime    _startTime;
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

        _startTime = DateTime.Now;
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
    }

    private static void DisplayDescriptiveText(string text)
    {
        DescriptiveText.SetItem(text);
        DescriptiveText.Display();
    }

    private static void DisplayEndGame(string ending)
    {
        Error.SetItem($"{ending} The game is over.");
        Error.Display();
        Console.ResetColor();
        DisplayPlayTime();
    }

    private static string DisplayHelp()
    {
        Console.ResetColor();
        Console.WriteLine("The following commands are available:");
        Console.WriteLine("move north/south/east/west  - Move in the specified direction.");
        Console.WriteLine("shoot north/south/east/west - Shoot an arrow in the specified direction into the next room. If a monster is in that room, they will be killed.");
        Console.WriteLine("enable fountain             - Activate the Fountain of Objects. Only available in the Fountain Room");
        Console.WriteLine("help                        - Display this help text");
        return string.Empty;
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

    private static void DisplayPlayTime()
    {
        var endTime  = DateTime.Now;
        var playTime = endTime - _startTime;
        Console.WriteLine($"Your adventure took {playTime.Days}d, {playTime.Hours}h, {playTime.Minutes}m, {playTime.Seconds}s.");
    }

    // Inform the player of their location, any descriptive text for this room, and whether they are in the presence of the Fountain.
    private static void DisplayStatus()
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
}