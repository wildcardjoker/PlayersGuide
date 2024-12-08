// FinalBattle.Character

namespace FinalBattle.Character.Attacks;

/// <inheritdoc />
public class NoAttack : Attack
{
    #region Constructors
    /// <inheritdoc />
    public NoAttack() : base(nameof(NoAttack), 0, 0) {}
    #endregion

    #region Overrides of Attack
    /// <inheritdoc />
    public override int CalculateDamage() => throw new NotImplementedException();
    #endregion
}