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
    public Unravel() : base("Unravelling") {}
    #endregion

    #region Implementation of IAttack
    /// <inheritdoc />
    public override int CalculateDamage() => _random.Next(2);
    #endregion
}