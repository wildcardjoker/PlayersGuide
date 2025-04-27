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
    /// <inheritdoc />
    protected Attack(string name, float chanceToHit, int damage, AttackModifier? attackModifier = null) :
        this(name, DamageType.Normal, chanceToHit, damage, attackModifier) {}

    /// <summary>
    ///     Initializes a new instance of the <see cref="Attack" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="damageType">The damage type inflicted by the attack</param>
    /// <param name="chanceToHit">
    ///     The chance of a successful attack, expressed as a percentage. 0 is an automatic failure, 1 is
    ///     an automatic hit.
    /// </param>
    /// <param name="damage">The amount of damage that the attack inflicts.</param>
    /// <param name="attackModifier">The attack modifier applied to this attack.</param>
    protected Attack(string name, DamageType damageType, float chanceToHit, int damage, AttackModifier? attackModifier = null)
    {
        Name           = name;
        DamageType     = damageType;
        ChanceToHit    = chanceToHit;
        Damage         = damage;
        AttackModifier = attackModifier;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets or sets the attack modifier.
    /// </summary>
    public AttackModifier? AttackModifier {get;}

    /// <summary>
    ///     Gets the chance to hit.
    /// </summary>
    public float ChanceToHit {get;}

    /// <summary>
    ///     Gets the damage.
    /// </summary>
    public int Damage {get;}

    /// <summary>
    ///     Gets the damage type.
    /// </summary>
    public DamageType DamageType {get;}

    /// <summary>
    ///     Gets the name.
    /// </summary>
    protected string Name {get;}
    #endregion

    #region Methods
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
    public bool IsSuccess() => random.NextDouble() < ChanceToHit;

    /// <inheritdoc />
    public override string ToString() => Name.ToUpper();
    #endregion
}