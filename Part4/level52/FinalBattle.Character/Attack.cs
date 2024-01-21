// FinalBattle.Character

namespace FinalBattle.Character;

/// <summary>
///     An object representing an attack on another character.
/// </summary>
public abstract class Attack
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="Attack" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    protected Attack(string name) => Name = name;
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the damage.
    /// </summary>
    /// <value>
    ///     The damage.
    /// </value>
    public int Damage {get; set;}

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string Name {get; private set;}
    #endregion

    /// <summary>
    ///     Calculates the damage.
    /// </summary>
    /// <returns>The amount of damage inflicted by the character.</returns>
    public abstract int CalculateDamage();
}