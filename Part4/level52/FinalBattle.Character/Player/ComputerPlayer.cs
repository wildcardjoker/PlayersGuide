namespace FinalBattle.Character.Player
{
    /// <summary>
    ///     A computer/AI player. All decisions are made by the computer.
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class ComputerPlayer : IPlayer
    {
        #region IPlayer Members
        #region Implementation of IPlayer
        /// <inheritdoc />
        public Action SelectAction()
        {
            Thread.Sleep(500); // simulate decision
            return Action.Nothing;

            // TODO: Replace with method to select from a range of Actions.
        }
        #endregion
        #endregion
    }
}