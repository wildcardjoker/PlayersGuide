// FinalBattle.Character

namespace FinalBattle.Character;

/// <summary>
///     An object representing an attack on another character.
/// </summary>
public abstract class Attack
{
    #region Fields
    private readonly Random random = new Random();
    #endregion

    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="Attack" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="chanceToHit">
    ///     The chance of a successful attack, expressed as a percentage. 0 is an automatic failure, 1 is
    ///     an automatic hit.
    /// </param>
    /// <param name="damage">The amount of damage that the attack inflicts.</param>
    protected Attack(string name, float chanceToHit, int damage)
    {
        Name        = name.ToUpper();
        ChanceToHit = chanceToHit;
        Damage      = damage;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the chance to hit.
    /// </summary>
    /// <value>
    ///     The chance to hit.
    /// </value>
    public float ChanceToHit {get;}

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

    /// <summary>
    ///     Determines whether this attack was successful.
    /// </summary>
    /// <returns>
    ///     <c>true</c> if this attack was successful; otherwise, <c>false</c>.
    /// </returns>
    public bool IsSuccess() =>
        ChanceToHit switch
        {
            0 => false,
            1 => true,
            _ => random.NextSingle() <= ChanceToHit
        };

    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => Name;
    #endregion
}