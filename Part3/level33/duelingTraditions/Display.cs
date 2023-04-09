// duelingTraditions

namespace duelingTraditions;

internal static partial class DuelingTraditions
{
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