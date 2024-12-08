namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     The Uncoded One
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.Character" />
    public class UncodedOne : Character
    {
        #region Constructors
        /// <inheritdoc />
        public UncodedOne() : base("The Uncoded One", new[] {new Unravel()}, new AttackModifier(), 15) {}
        #endregion
    }
}