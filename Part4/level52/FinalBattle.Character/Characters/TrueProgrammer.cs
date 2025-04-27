// FinalBattle.Character

namespace FinalBattle.Character.Characters;

#region Using Directives
using Attacks;
using GearItems;
#endregion

/// <inheritdoc />
/// <summary>
///     The True Programmer
/// </summary>
public class TrueProgrammer : Character
{
    #region Constructors
    /// <inheritdoc />
    public TrueProgrammer(string name) : base(
        name,
        new Attack[] {new Punch(), new ChargedPunch()},
        new AttackModifier("Object Sight", AttackModifierType.Defensive, DamageType.Decoding, -2),
        20) =>
        EquippedGear = new FlamingSword();
    #endregion
}