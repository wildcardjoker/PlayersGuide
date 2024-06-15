// The final battle!

#region Using Directives
using FinalBattle;
using FinalBattle.Character;
using FinalBattle.Character.Characters;
using FinalBattle.Character.GearItems;
using FinalBattle.Character.Items;
using FinalBattle.Character.Player;
using Humanizer;
using Action = FinalBattle.Character.Action;
#endregion

Console.ForegroundColor = ConsoleColor.White;
var selectedGameMode = GetGameMode();

// Set up the players
Player heroPlayer    = selectedGameMode == GameMode.ComputerVsComputer ? new ComputerPlayer() : new HumanPlayer();
Player monsterPlayer = selectedGameMode == GameMode.HumanVsHuman ? new HumanPlayer() : new ComputerPlayer();

// Get the True Programmer's name
var trueProgrammerName = GetResponseFromConsole("What is your name, hero?");
var trueProgrammer     = new TrueProgrammer(trueProgrammerName);

// Create the Hero party
heroPlayer.Parties.Add(new Party(new[] {trueProgrammer}, new[] {new HealthPotion(), new HealthPotion(), new HealthPotion()}, new[] {new Sword()}, true));

// Create a collection of enemy parties
monsterPlayer.Parties.Add(new Party(new[] {new Skeleton {EquippedGear = new Dagger()}}, new[] {new HealthPotion()}));
monsterPlayer.Parties.Add(new Party(new[] {new Skeleton(), new Skeleton()},             new[] {new HealthPotion()}, new[] {new Dagger(), new Dagger()}));
monsterPlayer.Parties.Add(new Party(new[] {new UncodedOne()},                           new[] {new HealthPotion()}, new[] {new Dagger(), new Dagger()}));

// Hero goes first
var currentPlayer = heroPlayer;
do
{
    var battleOver = false;
    do
    {
        var battle = new[] {heroPlayer.CurrentParty, monsterPlayer.CurrentParty};
        foreach (var party in battle)
        {
            party.IsCurrentParty = true;
            foreach (var character in party.Characters)
            {
                character.IsActive = true;
                DisplayBattleStatus(battle);

                var action = currentPlayer.SelectAction();
                if (action == Action.UseItem)
                {
                    UseItem();
                }
                else
                {
                    var targetParty = battle.First(x => !x.IsCurrentParty);
                    var target      = action == Action.Attack ? targetParty.Characters[currentPlayer.SelectTarget(targetParty.Characters)] : null;
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
                                monsterPlayer.Parties.RemoveAt(0);
                            }
                            else
                            {
                                // Hero party has been defeated.
                                heroPlayer.Parties.RemoveAt(0);
                            }

                            battleOver = true;
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }

                character.IsActive = false;
            }

            party.IsCurrentParty = false;
            currentPlayer        = currentPlayer == heroPlayer ? monsterPlayer : heroPlayer;
        }
    }
    while (!battleOver);
}
while (heroPlayer.Parties.Any() && monsterPlayer.Parties.Any());

Console.WriteLine(
    heroPlayer.Parties.Any() ? "The heroes have won, and the Uncoded One has been defeated!" : "The heroes have lost, and the Uncoded One's forces have prevailed...");
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

void DisplayBattleStatus(Party[] battle)
{
    const string title               = " BATTLE ";
    const string vs                  = " vs ";
    var          headerLength        = Console.WindowWidth / 2;
    var          header              = new string('=', headerLength - title.Length / 2);
    var          vsHeader            = new string('-', headerLength - vs.Length    / 2);
    var          maxCurrentHpPadding = (from party in battle select party.Characters.Max(x => x.HitPoints)).Max().ToString().Length;
    var          maxMaxHpPadding     = (from party in battle select party.Characters.Max(x => x.MaxHitPoints)).Max().ToString().Length;
    Console.WriteLine($"{header}{title}{header}");
    foreach (var party in battle.OrderByDescending(x => x.IsCurrentParty))
    {
        if (!party.IsCurrentParty)
        {
            Console.WriteLine($"{vsHeader}{vs}{vsHeader}");
        }

        foreach (var character in party.Characters)
        {
            var stats      = $"( {character.HitPoints.ToString().PadLeft(maxCurrentHpPadding)}/{character.MaxHitPoints.ToString().PadLeft(maxMaxHpPadding)} )";
            var nameLength = character.Name.Length;
            var name       = character.Name;
            if (character.IsActive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                name                    = $"{name}*";
                nameLength++;
            }

            Console.WriteLine($"{name}{stats.PadLeft(Console.WindowWidth - nameLength)}");
            Console.ResetColor();
        }
    }

    Console.WriteLine(new string('=', Console.WindowWidth));
}

void UseItem()
{
    // Display available items and quantity
    // Player chooses item to use
    // Item is used or player returns to menu.
    int index;
    if (currentPlayer is ComputerPlayer)
    {
        // Only Health potions at this stage.
        index = 0;
    }
    else
    {
        var inventory = currentPlayer.CurrentParty.PartyInventory;
        Console.WriteLine("Your party has the following items");
        for (var i = 0; i < inventory.Items.Count; i++)
        {
            Console.WriteLine($"{i}: {inventory.Items[i]}");
        }

        int.TryParse(GetResponseFromConsole("Please select the item to use"), out index);
        if (index < 0 || index > inventory.Items.Count - 1)
        {
            // Value is out of range
            return;
        }
    }

    currentPlayer.UseItem(index);
}