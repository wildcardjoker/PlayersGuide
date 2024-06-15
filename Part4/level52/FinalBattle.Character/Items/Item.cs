namespace FinalBattle.Character.Items
{
    /// <inheritdoc />
    /// <summary>
    ///     Base class for items.
    /// </summary>
    public abstract class Item : InventoryItem
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Item(string name) => Name = name.ToUpper();
        #endregion

        /// <summary>
        ///     Uses this instance.
        /// </summary>
        public abstract void Use(Character character);
    }
}