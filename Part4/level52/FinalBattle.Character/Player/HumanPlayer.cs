// FinalBattle.Character

namespace FinalBattle.Character.Player;

#region Using Directives
using Humanizer;
#endregion

/// <inheritdoc />
/// <summary>
///     Represents a Human Player.
/// </summary>
/// <seealso cref="T:FinalBattle.Character.Player.Player" />
public class HumanPlayer : Player
{
    #region Constructors
    /// <inheritdoc />
    public HumanPlayer() {}
    #endregion

    /// <inheritdoc />
    public override Action SelectAction()

    {
        var actionValues = ((int[]) Enum.GetValues(typeof(Action))).ToList();
        if (!CurrentParty!.PartyInventory.ContainsHealthPotion)
        {
            actionValues.Remove((int) Action.UseItem);
        }

        if (!CurrentParty.IsEquippableGearAvailable)
        {
            actionValues.Remove((int) Action.Equip);
        }

        foreach (Action value in actionValues)
        {
            Console.WriteLine($"{(int) value} - {value.Humanize()}");
        }

        var action = 0;
        while (!actionValues.Contains(action))
        {
            Console.Write("What do you want to do? ");
            int.TryParse(Console.ReadLine(), out action);
        }

        return (Action) action;
    }

    /// <inheritdoc />
    public override int SelectTarget(List<Character> characters)
    {
        for (var i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1} {characters[i].Name}");
        }

        var target = 0;
        while (target <= 0 || target > characters.Count)
        {
            Console.Write("Which character do you want to target? ");
            int.TryParse(Console.ReadLine(), out target);
        }

        return --target;
    }

    /// <inheritdoc />
    public override void UseItem(int index) => CurrentParty!.PartyInventory.UseItem(CurrentCharacter, index);
}