// FinalBattle.Character

namespace FinalBattle.Character.Characters;

#region Using Directives
using Attacks;
using GearItems;
#endregion

/// <summary>
///     The True Programmer
/// </summary>
public class TrueProgrammer : Character
{
    #region Constructors
    /// <inheritdoc />
    public TrueProgrammer(string name) : base(name, new[] {new Punch()}, 25) => EquippedGear = new Sword();
    #endregion
}