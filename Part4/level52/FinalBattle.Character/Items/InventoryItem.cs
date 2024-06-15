namespace FinalBattle.Character.Items
{
    /// <summary>
    ///     Base class for inventory items (potions, weapons, etc)
    /// </summary>
    public class InventoryItem
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the name of the item.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        protected string Name {get; init;} = null!;
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;
        #endregion
    }
}