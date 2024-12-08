namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <summary>
    ///     A Stone Amarok. Has 4 HP and a Bite attack
    /// </summary>
    /// <seealso cref="FinalBattle.Character.Character" />
    public class StoneAmarok : Character
    {
        #region Constructors
        /// <inheritdoc />
        public StoneAmarok() : base("Stone Amarok", new[] {new Bite()}, 4) {}
        #endregion
    }
}