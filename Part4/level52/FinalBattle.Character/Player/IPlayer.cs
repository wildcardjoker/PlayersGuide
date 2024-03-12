// FinalBattle.Player

namespace FinalBattle.Character.Player;

#region Using Directives
using Items;
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
    Action SelectAction(IEnumerable<Item> items);

    /// <summary>
    ///     Selects the target.
    /// </summary>
    /// <returns>The index of the targeted character in the opponent's party.</returns>
    int SelectTarget(List<Character> characters);
}