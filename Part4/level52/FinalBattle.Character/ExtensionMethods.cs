﻿// FinalBattle.Character

namespace FinalBattle.Character;

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
    /// <param name="targetCharacter">The target character.</param>
    /// <returns>
    ///     The adjective related to the specified action.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">The specified action is not valid.</exception>
    public static AttackData PerformAction(this Character character, Action action, Character? targetCharacter)
    {
        return action switch
        {
            Action.DoNothing => new AttackData($"{character} did NOTHING."),
            Action.Attack    => AttackTarget(character, character.Attacks.First(), targetCharacter!),
            _                => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
    }

    private static AttackData AttackTarget(Character character, Attack attack, Character targetCharacter)
    {
        var attackDescription = $"{character} used {attack} on {targetCharacter}.";
        return new AttackData(attack, attackDescription, attack.CalculateDamage());
    }
}