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
}