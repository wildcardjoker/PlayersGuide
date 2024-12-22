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
var vinFletcher        = new VinFletcher();
var mylaraAndSkorin    = new MylaraAndSkorin();

// Create the Hero party
heroPlayer.Parties.Add(
    new Party(new Character[] {trueProgrammer, vinFletcher, mylaraAndSkorin}, new[] {new HealthPotion(), new HealthPotion(), new HealthPotion()}, isHeroParty: true));

// Create a collection of enemy parties
monsterPlayer.Parties.Add(new Party(new[] {new Skeleton {EquippedGear = new Dagger()}}, new[] {new HealthPotion()}));
monsterPlayer.Parties.Add(new Party(new[] {new StoneAmarok()},                          Array.Empty<Item>()));
monsterPlayer.Parties.Add(new Party(new[] {new Skeleton(), new Skeleton()},             new[] {new HealthPotion()}, new[] {new Dagger(), new Dagger()}));
monsterPlayer.Parties.Add(new Party(new[] {new UncodedOne()},                           new[] {new HealthPotion()}));

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
            party!.IsCurrentParty = true;
            foreach (var character in party.Characters)
            {
                character!.IsActive = true;
                if (!battle.First(p => !p?.IsCurrentParty ?? false)?.Characters.Any() ?? false)
                {
                    battle = new[] {heroPlayer.CurrentParty, monsterPlayer.CurrentParty};
                }

                if (battle.Any(b => b == null))
                {
                    // One of the parties has been defeated
                    battleOver = true;
                    break;
                }

                DisplayBattleStatus(battle);

                var action = currentPlayer.SelectAction();
                switch (action)
                {
                    case Action.Attack:
                    case Action.DoNothing:
                        battleOver = PerformAction(battle, action, currentPlayer, character);
                        break;

                    case Action.Equip:
                        EquipItem();
                        break;

                    case Action.UseItem:
                        UseItem();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
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

void DisplayBattleStatus(Party?[] battle)
{
    const string title               = " BATTLE ";
    const string vs                  = " vs ";
    var          headerLength        = Console.WindowWidth / 2;
    var          header              = new string('=', headerLength - title.Length / 2);
    var          vsHeader            = new string('-', headerLength - vs.Length    / 2);
    var          maxCurrentHpPadding = (from party in battle select party.Characters.Max(x => x!.HitPoints!)).Max().ToString().Length;
    var          maxMaxHpPadding     = (from party in battle select party.Characters.Max(x => x!.MaxHitPoints!)).Max().ToString().Length;
    Console.WriteLine($"{header}{title}{header}");
    foreach (var party in battle.OrderByDescending(x => x!.IsCurrentParty))
    {
        if (!party!.IsCurrentParty)
        {
            Console.WriteLine($"{vsHeader}{vs}{vsHeader}");
        }

        foreach (var character in party.Characters)
        {
            var stats        = $"( {character!.HitPoints.ToString().PadLeft(maxCurrentHpPadding)}/{character.MaxHitPoints.ToString().PadLeft(maxMaxHpPadding)} )";
            var equippedGear = character.EquippedGear == null ? string.Empty : $" ({character.EquippedGear.Description})";
            var name         = $"{character.Name}{equippedGear}";
            var nameLength   = name.Length;
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

void EquipItem()
{
    // Display available gear
    // Player chooses gear to equip
    // Gear is equipped or player returns to menu.
    int index;
    var inventory = currentPlayer!.CurrentParty!.PartyGear;

    // If the current player is a computer, select the first available weapon
    // If the current player is a human AND only there is only one equippable item, select it automatically
    // Otherwise, display a list of available gear and allow the player to choose.
    if (currentPlayer is ComputerPlayer || (currentPlayer is HumanPlayer && inventory.Items.Count == 1))
    {
        // Use first available weapon
        index = 0;
    }
    else
    {
        Console.WriteLine("Your party has the following gear");
        for (var i = 0; i < inventory.Items.Count; i++)
        {
            Console.WriteLine($"{i}: {inventory.Items[i].Description}");
        }

        int.TryParse(GetResponseFromConsole("Please select the item to use"), out index);
        if (index < 0 || index > inventory.Items.Count - 1)
        {
            // Value is out of range
            return;
        }
    }

    var character = currentPlayer.CurrentCharacter;
    currentPlayer.CurrentParty.PartyGear.Equip(character, index);
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
        var inventory = currentPlayer!.CurrentParty!.PartyInventory;
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

bool PerformAction(IEnumerable<Party?> parties, Action action, Player player, Character? character)
{
    {
        var battleOver  = false;
        var targetParty = parties.First(x => !x!.IsCurrentParty!);
        var target      = action == Action.Attack ? targetParty!.Characters![player.SelectTarget(targetParty!.Characters!)] : null;
        DisplayCharacterAction(character, action, player is ComputerPlayer, target!);
        if (target?.HitPoints == 0)
        {
            if (!targetParty!.IsHeroParty!)
            {
                LootEnemy(target, character);
            }

            targetParty.Characters.Remove(target);
            if (!targetParty.HasBeenDefeated)
            {
                return battleOver;
            }

            if (!targetParty.IsHeroParty)
            {
                LootParty(character);
            }
            else
            {
                // Hero party has been defeated.
                heroPlayer.Parties.RemoveAt(0);
            }

            Console.WriteLine($"{target.Name} has been defeated!");

            battleOver = true;
        }
        else
        {
            Thread.Sleep(500);
        }

        return battleOver;
    }

    static void DisplayCharacterAction(Character? character, Action action, bool isComputerPlayer, Character target)
    {
        var result = character.PerformAction(action, isComputerPlayer, target);
        Console.WriteLine(result.Description);
        if (result.Attack != null)
        {
            if (result.WasSuccessful)
            {
                if (target!.AttackModifier.HasModifier)
                {
                    result = target.AttackModifier.ModifyAttack(result);
                    Console.WriteLine(result.Description);
                }

                target.ModifyHitPoints(-result.Damage);
                Console.WriteLine($"{result.Attack} dealt {result.Damage} to {target}");
                Console.WriteLine($"{target} is now at {target.CurrentHealth}");
            }
            else
            {
                Console.WriteLine($"{character} missed!");
            }
        }

        Console.WriteLine();
    }
}

void LootEnemy(Character target, Character? character)
{
    // Recover any equipped gear that the enemy was carrying.
    if (target.EquippedGear == null)
    {
        return;
    }

    var gear = target.EquippedGear;
    Console.WriteLine($"{character} looted {gear.Description} from {target}");
    currentPlayer!.CurrentParty!.PartyGear.Items.Add(target.EquippedGear);
}

void LootParty(Character? character)
{
    // Recover any items from the party's inventory.
    var inventory = monsterPlayer.Parties.First()?.PartyInventory.Items;
    if (inventory?.Any() ?? false)
    {
        foreach (var item in inventory)
        {
            Console.WriteLine($"{character} looted {item}");
            currentPlayer!.CurrentParty!.PartyInventory.Items.Add(item);
        }
    }

    // Recover any items from the party's gear inventory.
    var gearInventory = monsterPlayer.Parties.First()?.PartyGear.Items;
    if (gearInventory?.Any() ?? false)
    {
        foreach (var item in gearInventory)
        {
            Console.WriteLine($"{character} looted {item.Description}");
            currentPlayer!.CurrentParty!.PartyGear.Items.Add(item);
        }
    }

    // Remove the first Enemy party; it has been defeated
    monsterPlayer.Parties.RemoveAt(0);
}