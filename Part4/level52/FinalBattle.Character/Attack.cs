﻿// FinalBattle.Character

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
    /// <param name="damage"></param>
    protected Attack(string name, int damage)
    {
        Name   = name.ToUpper();
        Damage = damage;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the damage.
    /// </summary>
    /// <value>
    ///     The damage.
    /// </value>
    public int Damage {get;}

    /// <summary>
    ///     Gets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    protected string Name {get;}
    #endregion

    /// <summary>
    ///     Calculates the damage.
    /// </summary>
    /// <returns>The amount of damage inflicted by the character.</returns>
    public abstract int CalculateDamage();

    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => Name;
    #endregion
}