// FinalBattle.Character

namespace FinalBattle.Character.Player;

#region Using Directives
using Humanizer;
#endregion

public class HumanPlayer : IPlayer
{
    #region IPlayer Members
    #region Implementation of IPlayer
    /// <inheritdoc />
    public Action SelectAction()
    {
        var actionValues = (int[]) Enum.GetValues(typeof(Action));
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
    #endregion
    #endregion
}