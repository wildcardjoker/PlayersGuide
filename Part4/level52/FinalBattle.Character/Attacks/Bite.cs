// FinalBattle.Character

namespace FinalBattle.Character.Attacks;

/// <inheritdoc />
/// <summary>
///     Represents a Bite attack
/// </summary>
/// <seealso cref="T:FinalBattle.Character.Attack" />
public class Bite : Attack
{
    #region Constructors
    /// <inheritdoc />
    public Bite() : base(nameof(Bite), 1, 1) {}
    #endregion

    #region Overrides of Attack
    /// <inheritdoc />
    public override int CalculateDamage() => 1;
    #endregion
}