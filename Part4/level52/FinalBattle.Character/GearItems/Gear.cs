namespace FinalBattle.Character.GearItems
{
    #region Using Directives
    using Items;
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     Base class for items.
    /// </summary>
    public abstract class Gear : InventoryItem
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Gear" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Gear(string name) => Name = name.ToUpper();
        #endregion

        /// <summary>
        ///     Attacks the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        public abstract void Attack(Character character);

        /// <summary>
        ///     Uses this instance.
        /// </summary>
        public abstract void Equip(Character character);
    }
}