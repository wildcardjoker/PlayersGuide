namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <summary>
    ///     A Skeleton character
    /// </summary>
    /// <seealso cref="FinalBattle.Character.Character" />
    public class Skeleton : Character
    {
        #region Constructors
        /// <inheritdoc />
        public Skeleton() : base("Skeleton", new[] {new BoneCrunch()}, 5) {}
        #endregion
    }
}