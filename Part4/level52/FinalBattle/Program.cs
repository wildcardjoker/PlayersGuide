// The final battle!

// Create two characters, both skeletons
// Create two parties of a variable number of characters (one character each to start with); one party of heroes, one of monsters
// Loop through each party (heroes first) and loop through each character in the party
// Each character in the party performs an action (not yet implemented; we'll be using a constant to represent the action for now)

#region Using Directives
using FinalBattle;
using FinalBattle.Character;
using FinalBattle.Character.Characters;
using FinalBattle.Character.Player;
using Humanizer;
using Action = FinalBattle.Character.Action;
#endregion

Console.ForegroundColor = ConsoleColor.White;
var     selectedGameMode   = GetGameMode();
IPlayer heroPlayer         = selectedGameMode == GameMode.ComputerVsComputer ? new ComputerPlayer() : new HumanPlayer();
IPlayer monsterPlayer      = selectedGameMode == GameMode.HumanVsHuman ? new HumanPlayer() : new ComputerPlayer();
var     trueProgrammerName = GetResponseFromConsole("What is your name, hero?");
var     trueProgrammer     = new TrueProgrammer(trueProgrammerName);
var     heroes             = new Party(heroPlayer, new[] {trueProgrammer}, true);

// Create a collection of enemy parties
var enemies = new List<Party>
{
    new (monsterPlayer, new[] {new Skeleton()}), new (monsterPlayer, new[] {new Skeleton(), new Skeleton()}), new (monsterPlayer, new[] {new UncodedOne()})
};

do
{
    var enemyParty = enemies.First();
    DisplayEnemyParty(enemyParty);
    var battleOver = false;
    do
    {
        var battle = new[] {heroes, enemyParty};
        foreach (var party in battle)
        {
            party.IsCurrentParty = true;
            foreach (var character in party.Characters)
            {
                Console.WriteLine($"It's {character.Name}'s turn ...");

                var action      = party.Player.SelectAction();
                var targetParty = battle.First(x => !x.IsCurrentParty);
                var target      = action == Action.DoNothing ? null : targetParty.Characters[party.Player.SelectTarget(targetParty.Characters)];
                DisplayCharacterAction(character, action, target);
                if (target?.HitPoints == 0)
                {
                    targetParty.Characters.Remove(target);
                    Console.WriteLine($"{target.Name} has been defeated!");
                    if (!targetParty.Characters.Any())
                    {
                        if (!targetParty.IsHeroParty)
                        {
                            // Remove the first Enemy party; it has been defeated
                            enemies.RemoveAt(0);
                        }

                        battleOver = true;
                    }
                }
                else
                {
                    Thread.Sleep(500);
                }
            }

            party.IsCurrentParty = false;
        }
    }
    while (!battleOver);
}
while (enemies.Any() && heroes.Characters.Any());

Console.WriteLine(
    heroes.Characters.Any() ? "The heroes have won, and the Uncoded One has been defeated!" : "The heroes have lost, and the Uncoded One's forces have prevailed...");
return;

void DisplayEnemyParty(Party party)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("You prepare to battle:");
    foreach (var character in party.Characters)
    {
        Console.WriteLine($" * {character.Name}");
    }

    Console.ResetColor();
}

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

GameMode GetGameMode()
{
    Console.WriteLine("Please choose your game mode:");
    var modes = (int[]) Enum.GetValues(typeof(GameMode));
    foreach (GameMode mode in modes)
    {
        Console.WriteLine($"{(int) mode}: {mode.Humanize()}");
    }

    var selectedMode = 0;
    while (!modes.Contains(selectedMode))
    {
        int.TryParse(GetResponseFromConsole("Game mode:"), out selectedMode);
    }

    return (GameMode) selectedMode;
}