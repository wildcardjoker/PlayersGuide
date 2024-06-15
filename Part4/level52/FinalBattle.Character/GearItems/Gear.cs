namespace FinalBattle.Character.GearItems
{
    #region Using Directives
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     Base class for items.
    /// </summary>
    public abstract class Gear : Attack
    {
        #region Constructors
        /// <inheritdoc />
        protected Gear(string name, int damage) : base(name, damage) {}
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;
        #endregion
    }
}