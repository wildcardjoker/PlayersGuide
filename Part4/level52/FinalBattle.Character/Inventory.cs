// FinalBattle.Character

namespace FinalBattle.Character;

#region Using Directives
using Items;
#endregion

public class Inventory
{
    #region Constructors
    public Inventory(IEnumerable<Item> items) => Items = items.ToList();
    #endregion

    #region Properties
    /// <summary>
    ///     Determines whether the party has at least one health potion.
    /// </summary>
    /// <returns>
    ///     <c>true</c> if the party's Inventory contains at least one health potion; otherwise, <c>false</c>.
    /// </returns>
    public bool ContainsHealthPotion => Items.Any(i => i is HealthPotion);

    public List<Item> Items {get;}
    #endregion

    public void UseItem(Character? character, int index)
    {
        Items[index].Use(character);
        Items.RemoveAt(index);
    }
}