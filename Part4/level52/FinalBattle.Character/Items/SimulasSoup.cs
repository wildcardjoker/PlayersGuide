// FinalBattle.Character

namespace FinalBattle.Character.Items;

/// <summary>
///     A Health potion that adds Hit Points
/// </summary>
/// <seealso cref="FinalBattle.Character.Items.Item" />
public class SimulasSoup : Item
{
    #region Constructors
    /// <inheritdoc />
    public SimulasSoup() : base("Simula's Soup") {}
    #endregion

    #region Overrides of Item
    /// <inheritdoc />
    public override void Use(Character? character)
    {
        Console.WriteLine($"{character} uses {Name}");
        character!.ModifyHitPoints(character.MaxHitPoints - character.HitPoints);
        Console.WriteLine($"{character} HP is now {character.HitPoints}");
    }
    #endregion
}