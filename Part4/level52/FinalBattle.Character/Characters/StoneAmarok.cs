namespace FinalBattle.Character.Characters
{
    #region Using Directives
    using Attacks;
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     A Stone Amarok. Has 4 HP and a Bite attack
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.Character" />
    public class StoneAmarok : Character
    {
        #region Constructors
        /// <inheritdoc />
        public StoneAmarok() : base("Stone Amarok", new[] {new Bite()}, new AttackModifier("Stone Armour", -1), 4) {}
        #endregion
    }
}