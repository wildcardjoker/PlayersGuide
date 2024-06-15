namespace FinalBattle.Character.Items
{
    /// <summary>
    ///     Base class for items.
    /// </summary>
    public abstract class Item
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Item(string name) => Name = name.ToUpper();
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the name of the item.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        protected string Name {get;}
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;
        #endregion

        /// <summary>
        ///     Uses this instance.
        /// </summary>
        public abstract void Use(Character character);
    }
}