namespace FinalBattle.Character.Player
{
    #region Using Directives
    #endregion

    /// <summary>
    ///     A computer/AI player. All decisions are made by the computer.
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class ComputerPlayer : IPlayer
    {
        #region IPlayer Members
        #region Implementation of IPlayer
        /// <inheritdoc />
        public Action SelectAction() => Action.DoNothing; // TODO: Replace with method to select from a range of Actions.
        #endregion
        #endregion
    }
}