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
    public class Skeleton : Character
    {
        #region Constructors
        /// <inheritdoc />
        public Skeleton() : base("Skeleton", new[] {new BoneCrunch()}, new AttackModifier()) {}
        #endregion
    }
}