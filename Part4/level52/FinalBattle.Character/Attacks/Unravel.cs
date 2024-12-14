// FinalBattle.Character

namespace FinalBattle.Character.Attacks;

/// <inheritdoc />
/// <summary>
///     An unravelling attack
/// </summary>
/// <seealso cref="T:FinalBattle.Character.Attack" />
public class Unravel : Attack
{
    #region Fields
    private readonly Random _random = new ();
    #endregion

    #region Constructors
    /// <inheritdoc />
    public Unravel() : base("Unravelling", DamageType.Decoding, 0.8f, 4) {}
    #endregion

    #region Implementation of IAttack
    /// <inheritdoc />
    public override int CalculateDamage() => _random.Next(Damage);
    #endregion
}