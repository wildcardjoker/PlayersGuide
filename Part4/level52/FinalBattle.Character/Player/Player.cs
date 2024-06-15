// FinalBattle.Player

namespace FinalBattle.Character.Player;

/// <summary>
///     Interface for all players.
/// </summary>
/// <remarks>Players can be Computer/AI or Human, but both types implement the same methods, making them interchangeable.</remarks>
public abstract class Player
{
    #region Constructors
    /// <summary>
    ///     Create a new <c>Player</c> object and initialize the list of parties.
    /// </summary>
    protected Player() => Parties = new List<Party>();
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the current character.
    /// </summary>
    /// <value>
    ///     The current character.
    /// </value>
    public Character CurrentCharacter => CurrentParty.Characters.First(x => x.IsActive);

    /// <summary>
    ///     Gets the current party.
    /// </summary>
    /// <value>
    ///     The current party.
    /// </value>
    public Party CurrentParty => Parties.First();

    /// <summary>
    ///     Gets the Party associated with this player.
    /// </summary>
    /// <value>
    ///     The party.
    /// </value>
    public List<Party> Parties {get;}
    #endregion

    /// <summary>
    ///     Selects the action.
    /// </summary>
    /// <returns>The Action to be performed by the player.</returns>
    public abstract Action SelectAction();

    /// <summary>
    ///     Selects the target.
    /// </summary>
    /// <returns>The index of the targeted character in the opponent's party.</returns>
    public abstract int SelectTarget(List<Character> characters);

    /// <summary>
    ///     Uses the item.
    /// </summary>
    /// <param name="index">The index of the item to be used.</param>
    public abstract void UseItem(int index);
}