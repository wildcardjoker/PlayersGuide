namespace FinalBattle.Character
{
    #region Using Directives
    using Player;
    #endregion

    /// <summary>
    ///     An object representing a party of Characters.
    /// </summary>
    public class Party
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Party" /> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="characters">The characters.</param>
        public Party(IPlayer player, IEnumerable<Character>? characters)
        {
            Player     = player;
            Characters = characters?.ToList() ?? new List<Character>();
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the characters.
        /// </summary>
        /// <value>
        ///     The characters.
        /// </value>
        public List<Character> Characters {get;}

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>
        ///     The player.
        /// </value>
        public IPlayer Player {get;}
        #endregion
    }
}