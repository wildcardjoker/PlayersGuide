// FinalBattle.Character

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
    /// <param name="damage">The damage.</param>
    public AttackData(string description, int damage = 0)
    {
        Damage      = damage;
        Description = description;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the damage.
    /// </summary>
    /// <value>
    ///     The damage.
    /// </value>
    public int Damage {get; private set;}

    public string Description {get; private set;}
    #endregion
}