// FinalBattle.Character

namespace FinalBattle.Character.Attacks;

/// <summary>
///     A Bone Crunch attack
/// </summary>
/// <seealso cref="FinalBattle.Character.Attack" />
public class BoneCrunch : Attack
{
    #region Fields
    private readonly Random _random = new ();
    #endregion

    #region Constructors
    /// <inheritdoc />
    public BoneCrunch() : base("bone crunch") {}
    #endregion

    #region Implementation of IAttack
    /// <inheritdoc />
    public override int CalculateDamage() => _random.Next(2);
    #endregion
}