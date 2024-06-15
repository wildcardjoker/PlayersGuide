// FinalBattle.Character

namespace FinalBattle.Character.Attacks;

/// <summary>
///     An unravelling attack
/// </summary>
/// <seealso cref="FinalBattle.Character.Attack" />
public class Unravel : Attack
{
    #region Fields
    private readonly Random _random = new ();
    #endregion

    #region Constructors
    /// <inheritdoc />
    public Unravel() : base("Unravelling", 2) {}
    #endregion

    #region Implementation of IAttack
    /// <inheritdoc />
    public override int CalculateDamage() => _random.Next(Damage);
    #endregion
}