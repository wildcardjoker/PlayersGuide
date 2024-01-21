// The final battle!

// Create two characters, both skeletons
// Create two parties of a variable number of characters (one character each to start with); one party of heroes, one of monsters
// Loop through each party (heroes first) and loop through each character in the party
// Each character in the party performs an action (not yet implemented; we'll be using a constant to represent the action for now)

#region Using Directives
using FinalBattle.Character;
using FinalBattle.Character.Characters;
using FinalBattle.Character.Player;
using Action = FinalBattle.Character.Action;
#endregion

var trueProgrammerName = GetResponseFromConsole("What is your name, hero?");
var trueProgrammer     = new TrueProgrammer(trueProgrammerName);
var heroes             = new Party(new ComputerPlayer(), new[] {trueProgrammer});

// TODO: use default SKELETON class
var monsters = new Party(new ComputerPlayer(), new[] {new Skeleton()});

// Create a collection of all parties; this will assist with looping through the parties
var parties = new[] {heroes, monsters};

// TODO: check if a party has been defeated
while (true)
{
    // Loop through each party
    // ReSharper disable once LoopCanBePartlyConvertedToQuery
    foreach (var party in parties)
    {
        party.IsCurrentParty = true;
        foreach (var character in party.Characters)
        {
            Console.WriteLine($"It's {character.Name.ToUpper()}'s turn ...");
            var action = party.Player.SelectAction();

            // TODO: Select target
            var target = parties.First(x => !x.IsCurrentParty).Characters.FirstOrDefault();
            DisplayCharacterAction(character, action, target);
        }

        party.IsCurrentParty = false;
    }
}

return;

static string GetResponseFromConsole(string message)
{
    var response = string.Empty;
    while (string.IsNullOrWhiteSpace(response))
    {
        Console.Write($"{message} ");
        response = Console.ReadLine();
    }

    return response;
}

static void DisplayCharacterAction(Character character, Action action, Character? target)
{
    Console.WriteLine(character.PerformAction(action, target));
    Console.WriteLine();
    Thread.Sleep(500);
}