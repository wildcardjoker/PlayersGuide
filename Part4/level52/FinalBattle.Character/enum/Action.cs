namespace FinalBattle.Character;

/// <summary>
///     Possible actions that can be performed by a character.
/// </summary>
public enum Action
{
    /// <summary>
    ///     Attack the player
    /// </summary>
    Attack = 1,

    /// <summary>
    ///     Do Nothing.
    /// </summary>
    DoNothing,

    /// <summary>
    ///     Equip an item
    /// </summary>
    Equip,

    /// <summary>
    ///     Use an Item
    /// </summary>
    UseItem
}