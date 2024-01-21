// FinalBattle.Character

namespace FinalBattle.Character;

/// <summary>
///     An object representing an attack on another character.
/// </summary>
public class Attack
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="Attack" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public Attack(string name) => Name = name;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name {get; private set;}
    #endregion
}