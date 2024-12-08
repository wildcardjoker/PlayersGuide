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
    public TrueProgrammer(string name) : base(name, new[] {new Punch()}, new AttackModifier(), 25) => EquippedGear = new Sword();
    #endregion
}