// FinalBattle.Character

namespace FinalBattle.Character.Items;

/// <summary>
///     A Health potion that adds Hit Points
/// </summary>
/// <seealso cref="FinalBattle.Character.Items.Item" />
public class HealthPotion : Item
{
    #region Constants
    private const int HealPoints = 10;
    #endregion

    #region Constructors
    /// <inheritdoc />
    public HealthPotion() : base("Health Potion") {}
    #endregion

    #region Overrides of Item
    /// <inheritdoc />
    public override void Use(Character? character)
    {
        Console.WriteLine($"{character} uses {Name}");
        character!.ModifyHitPoints(HealPoints);
        Console.WriteLine($"{character} HP is now {character.HitPoints}");
    }
    #endregion
}