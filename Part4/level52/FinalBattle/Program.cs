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
var monsters           = new Party(new ComputerPlayer(), new[] {new Skeleton()});

// Create a collection of all parties; this will assist with looping through the parties
var parties = new[] {heroes, monsters};

var gameOver = false;
while (!gameOver)
{
    // Loop through each party
    // ReSharper disable once LoopCanBePartlyConvertedToQuery
    foreach (var party in parties)
    {
        party.IsCurrentParty = true;
        foreach (var character in party.Characters)
        {
            Console.WriteLine($"It's {character.Name}'s turn ...");

            var action = party.Player.SelectAction();

            // DEBUG: Hero party does nothing, monsters attack.
            //var action = character.Name.Equals(trueProgrammerName, StringComparison.CurrentCultureIgnoreCase) ? Action.Nothing : Action.Attack;

            // TODO: Select target
            var targetParty = parties.First(x => !x.IsCurrentParty);
            var target      = targetParty.Characters.First();
            DisplayCharacterAction(character, action, target);
            if (target.HitPoints == 0)
            {
                targetParty.Characters.Remove(target);
                Console.WriteLine($"{target.Name} has been defeated!");
                if (!targetParty.Characters.Any())
                {
                    gameOver = true;
                }
            }
            else
            {
                Thread.Sleep(500);
                party.IsCurrentParty = false;
            }
        }
    }
}

Console.WriteLine(
    heroes.Characters.Any() ? "The heroes have won, and the Uncoded One has been defeated!" : "The heroes have lost, and the Uncoded One's forces have prevailed...");
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
    var result = character.PerformAction(action, target);
    Console.WriteLine(result.Description);
    if (result.Attack != null)
    {
        target!.ModifyHitPoints(-result.Damage);
        Console.WriteLine($"{result.Attack} dealt {result.Damage} to {target}");
        Console.WriteLine($"{target} is now at {target.CurrentHealth}");
    }

    Console.WriteLine();
}