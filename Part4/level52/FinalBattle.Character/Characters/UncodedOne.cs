namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <summary>
    ///     The Uncoded One
    /// </summary>
    /// <seealso cref="FinalBattle.Character.Character" />
    public class UncodedOne : Character
    {
        #region Constructors
        /// <inheritdoc />
        public UncodedOne() : base("The Uncoded One", new[] {new Unravel()}, 15) {}
        #endregion
    }
}