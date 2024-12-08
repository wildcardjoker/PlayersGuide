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
public class VinFletcher : Character
{
    #region Constructors
    /// <inheritdoc />
    public VinFletcher() : base("Vin Fletcher", new[] {new Punch()}, new AttackModifier(), 15) => EquippedGear = new VinsBow();
    #endregion
}