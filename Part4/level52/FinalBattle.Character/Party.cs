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
        ///     Gets or sets a value indicating whether this party is currently playing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this party is currently playing; otherwise, <c>false</c>.
        /// </value>
        public bool IsCurrentParty {get; set;}

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