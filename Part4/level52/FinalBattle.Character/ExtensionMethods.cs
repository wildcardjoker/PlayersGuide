// FinalBattle.Character

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
    public static string PerformAction(this Character character, Action action, Character? targetCharacter)
    {
        var characterNameUpperCase = character.Name.ToUpper();
        var actionPerformed = action switch
        {
            Action.Nothing => $"{characterNameUpperCase} did NOTHING.",
            Action.Attack  => $"{characterNameUpperCase} used {character.Attacks.First().Name.ToUpper()} on {targetCharacter?.Name.ToUpper() ?? "UNKNOWN TARGET"}.",
            _              => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
        return actionPerformed;
    }
}