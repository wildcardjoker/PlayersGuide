// FinalBattle.Character

namespace FinalBattle.Character.Characters;

#region Using Directives
using Attacks;
using GearItems;
#endregion

/// <summary>
///     The True Programmer
/// </summary>
public class VinFletcher : Character
{
    #region Constructors
    /// <inheritdoc />
    public VinFletcher() : base("Vin Fletcher", new[] {new Punch()}, 15) => EquippedGear = new VinsBow();
    #endregion
}