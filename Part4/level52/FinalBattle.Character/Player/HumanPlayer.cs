// FinalBattle.Character

namespace FinalBattle.Character.Player;

#region Using Directives
using Humanizer;
#endregion

public class HumanPlayer : IPlayer
{
    #region Implementation of IPlayer
    /// <inheritdoc />
    public Action SelectAction(Character character, Inventory inventory)
    {
        var actionValues = ((int[]) Enum.GetValues(typeof(Action))).ToList();
        if (!inventory.ContainsHealthPotion)
        {
            actionValues.Remove((int) Action.UseItem);
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
    public int SelectTarget(List<Character> characters)
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
    #endregion
}