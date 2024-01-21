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
        #region Implementation of IPlayer
        /// <inheritdoc />
        public Action SelectAction()
        {
            Thread.Sleep(500); // simulate decision
            var availableActions = Enum.GetNames(typeof(Action));
            var selectedAction   = _random.Next(availableActions.Length);
            return (Action) selectedAction;
        }
        #endregion
        #endregion
    }
}