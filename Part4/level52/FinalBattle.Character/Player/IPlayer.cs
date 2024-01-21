// FinalBattle.Player

namespace FinalBattle.Character.Player;

#region Using Directives
#endregion

/// <summary>
///     Interface for all players.
/// </summary>
/// <remarks>Players can be Computer/AI or Human, but both types implement the same methods, making them interchangeable.</remarks>
public interface IPlayer
{
    /// <summary>
    ///     Selects the action.
    /// </summary>
    /// <returns>The Action to be performed by the player.</returns>
    Action SelectAction();
}