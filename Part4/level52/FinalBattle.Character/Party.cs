﻿namespace FinalBattle.Character
{
    #region Using Directives
    using GearItems;
    using Items;
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
        /// <param name="characters">The characters.</param>
        /// <param name="items">The starting items provided to the party.</param>
        /// <param name="availableGear">The starting gear provided to the party.</param>
        /// <param name="isHeroParty">Indicates whether this is the Hero party</param>
        public Party(IEnumerable<Character?>? characters, IEnumerable<Item> items, IEnumerable<Gear>? availableGear = null, bool isHeroParty = false)
        {
            IsHeroParty    = isHeroParty;
            Characters     = characters?.ToList() ?? new List<Character?>();
            PartyInventory = new Inventory(items);
            PartyGear      = new AvailableGear(availableGear ?? new List<Gear>());
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the characters.
        /// </summary>
        /// <value>
        ///     The characters.
        /// </value>
        public List<Character?> Characters {get;}

        /// <summary>
        ///     Gets a value indicating whether the party has been defeated (no more characters in party).
        /// </summary>
        /// <value>
        ///     <c>true</c> if this party has been defeated; otherwise, <c>false</c>.
        /// </value>
        public bool HasBeenDefeated => !Characters.Any();

        /// <summary>
        ///     Gets or sets a value indicating whether this party is currently playing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this party is currently playing; otherwise, <c>false</c>.
        /// </value>
        public bool IsCurrentParty {get; set;}

        /// <summary>
        ///     Gets a value indicating whether any equippable gear is available.
        /// </summary>
        /// <value>
        ///     <c>true</c> if any equippable gear is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsEquippableGearAvailable => PartyGear.Items.Any();

        /// <summary>
        ///     Indicates if this is the Hero party
        /// </summary>
        public bool IsHeroParty {get;}

        /// <summary>
        ///     Gets the party gear.
        /// </summary>
        /// <value>
        ///     The party gear.
        /// </value>
        public AvailableGear PartyGear {get;}

        /// <summary>
        ///     Gets the party's items.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public Inventory PartyInventory {get;}
        #endregion
    }
}