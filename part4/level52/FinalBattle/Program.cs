// The final battle!

// Create two characters, both skeletons
// Create two parties of a variable number of characters (one character each to start with); one party of heroes, one of monsters
// Loop through each party (heroes first) and loop through each character in the party
// Each character in the party performs an action (not yet implemented; we'll be using a constant to represent the action for now)

#region Using Directives
using FinalBattle.Character;
#endregion

// TODO: use default SKELETON class
var heroes   = new List<Character> {new ("Skeleton", 10)};
var monsters = new List<Character> {new ("Skeleton", 10)};

// Create a collection of all parties; this will assist with looping through the parties
var parties = new[] {heroes, monsters};

// TODO: check if a party has been defeated
while (true)
{
    // Loop through each party
    // ReSharper disable once LoopCanBePartlyConvertedToQuery
    foreach (var party in parties)
    {
        foreach (var character in party)
        {
            // TODO: use variable action.
            DisplayCharacterAction(character, "nothing");
        }
    }
}

return;

static void DisplayCharacterAction(Character character, string action)
{
    Console.WriteLine($"It's {character.UpperName}'s turn ...");
    Console.WriteLine($"{character.UpperName} did {action.ToUpper()}.\n");
    Thread.Sleep(500);
}