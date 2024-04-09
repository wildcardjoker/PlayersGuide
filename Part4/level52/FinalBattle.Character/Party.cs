namespace FinalBattle.Character
{
    #region Using Directives
    using Items;
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
        /// <param name="items">The starting items provided to the party.</param>
        /// <param name="isHeroParty">Indicates whether this is the Hero party</param>
        public Party(IPlayer player, IEnumerable<Character>? characters, IEnumerable<Item> items, bool isHeroParty = false)
        {
            Player         = player;
            IsHeroParty    = isHeroParty;
            Characters     = characters?.ToList() ?? new List<Character>();
            PartyInventory = new Inventory(items);
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
        ///     Indicates if this is the Hero party
        /// </summary>
        public bool IsHeroParty {get;}

        /// <summary>
        ///     Gets the party's items.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public Inventory PartyInventory {get;}

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