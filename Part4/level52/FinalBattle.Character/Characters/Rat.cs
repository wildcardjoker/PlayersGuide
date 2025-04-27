namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     A Skeleton character
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.Character" />
    public class Rat : Character
    {
        #region Constructors
        /// <inheritdoc />
        public Rat() : base("Rat", new[] {new Bite()}, new AttackModifier(), 4) {}
        #endregion
    }
}