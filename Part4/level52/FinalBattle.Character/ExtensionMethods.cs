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
    /// <param name="action">The action.</param>
    /// <returns>The adjective related to the specified action.</returns>
    public static string GetActionAdjective(this Action action)
    {
        var adjective = action switch
        {
            Action.Nothing => "did",
            _              => "used"
        };
        return adjective;
    }
}