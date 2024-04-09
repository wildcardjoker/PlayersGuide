namespace FinalBattle.Character.Player
{
    /// <summary>
    ///     A computer/AI player. All decisions are made by the computer.
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class ComputerPlayer : IPlayer
    {
        #region Fields
        private readonly Random _random = new Random();
        #endregion

        #region IPlayer Members
        /// <inheritdoc />
        public Action SelectAction(Character character, Inventory inventory)
        {
            Thread.Sleep(500); // simulate decision
            var availableActions = Enum.GetNames(typeof(Action)).ToList();
            if (inventory.ContainsHealthPotion && character.IsWounded && _random.Next(1, 101) <= 25)
            {
                return Action.UseItem;
            }

            availableActions.Remove(Action.UseItem.ToString());
            var selectedAction = _random.Next(availableActions.Count) + 1;
            return (Action) selectedAction;
        }

        /// <inheritdoc />
        public int SelectTarget(List<Character> characters) => _random.Next(characters.Count);
        #endregion
    }
}