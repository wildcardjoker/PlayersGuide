// FinalBattle.Character

namespace FinalBattle.Character;

#region Using Directives
using GearItems;
#endregion

/// <summary>
///     A collection of <c>Gear</c> items available to the player, which can be equipped.
/// </summary>
public class AvailableGear
{
    #region Constructors
    /// <summary>
    ///     Initializes a new instance of the <see cref="AvailableGear" /> class.
    /// </summary>
    /// <param name="items">The items.</param>
    public AvailableGear(IEnumerable<Gear> items) => Items = items.ToList();
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the items.
    /// </summary>
    /// <value>
    ///     The items.
    /// </value>
    public List<Gear> Items {get;}
    #endregion

    /// <summary>
    ///     Direct the character to equip the specified gear.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="index">The index.</param>
    public void Equip(Character? character, int index)
    {
        if (character == null)
        {
            // No character to equip the gear
            return;
        }

        if (character.EquippedGear != null)
        {
            Console.WriteLine($"{character} unequips {character.EquippedGear}");
            Items.Add(character.EquippedGear);
        }

        Console.WriteLine($"{character} equips {Items[index]}");
        character.EquippedGear = Items[index];
        Items.RemoveAt(index);
    }
}