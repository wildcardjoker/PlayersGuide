﻿// FinalBattle.Character

namespace FinalBattle.Character;

/// <summary>
///     Contains information about the Attack that was performed.
/// </summary>
public class AttackData
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="AttackData" /> class.
    /// </summary>
    /// <param name="description">The description.</param>
    public AttackData(string description)
    {
        Attack      = null;
        Description = description;
        Damage      = 0;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AttackData" /> class.
    /// </summary>
    /// <param name="attack">The attack.</param>
    /// <param name="description">The description.</param>
    /// <param name="damage">The damage.</param>
    public AttackData(Attack attack, string description, int damage = 0)
    {
        Attack      = attack;
        Damage      = damage;
        Description = description;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the attack.
    /// </summary>
    /// <value>
    ///     The attack.
    /// </value>
    public Attack? Attack {get; private set;}

    /// <summary>
    ///     Gets the damage.
    /// </summary>
    /// <value>
    ///     The damage.
    /// </value>
    public int Damage {get; private set;}

    /// <summary>
    ///     Gets the description.
    /// </summary>
    /// <value>
    ///     The description.
    /// </value>
    public string Description {get; private set;}
    #endregion
}