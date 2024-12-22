// FinalBattle.Character

namespace FinalBattle.Character;

#region Using Directives
using Attacks;
#endregion

/// <summary>
///     Extension methods for working with Characters and related properties.
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    ///     Gets the action adjective.
    /// </summary>
    /// <param name="character">The character performing the action</param>
    /// <param name="action">The action.</param>
    /// <param name="isComputerPlayer"></param>
    /// <param name="targetCharacter">The target character.</param>
    /// <returns>
    ///     The adjective related to the specified action.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">The specified action is not valid.</exception>
    public static AttackData PerformAction(this Character? character, Action action, bool isComputerPlayer, Character targetCharacter)
    {
        return action switch
        {
            Action.DoNothing => new AttackData($"{character} did NOTHING."),
            Action.Attack    => AttackTarget(character, GetPreferredAttack(isComputerPlayer, character), targetCharacter!),
            _                => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
    }

    private static AttackData AttackTarget(Character? character, Attack attack, Character targetCharacter)
    {
        var attackDescription = $"{character} used {attack} on {targetCharacter}.";
        return new AttackData(attack, attackDescription, attack.CalculateDamage());
    }

    private static Attack GetPreferredAttack(bool isComputerPlayer, Character? character)
    {
        if (character == null)
        {
            // no character, no attack
            return new NoAttack();
        }

        // Computer player always prefers gear-based attack
        if (isComputerPlayer && character.EquippedGear != null)
        {
            return character.EquippedGear;
        }

        // Human player doesn't have any gear equipped
        if (character.EquippedGear == null)
        {
            return character.Attacks.First();
        }

        // Allow human player to choose attack.
        var attacks = new List<Attack> {character.EquippedGear}; // Equipped gear is always the first attack option
        attacks.AddRange(character.Attacks);
        var index = 0;
        Console.WriteLine("You can choose from the following attacks:");
        foreach (var attack in attacks)
        {
            Console.WriteLine($"{index}: {attack} ({attack.Damage} damage, {attack.ChanceToHit:P0} chance to hit)");
            index++;
        }

        index = -1;
        while (index < 0)
        {
            Console.Write("Which attack do you choose? ");
            int.TryParse(Console.ReadLine(), out index);
        }

        return attacks[index];
    }
}