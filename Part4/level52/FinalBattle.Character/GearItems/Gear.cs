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
        protected Gear(string name, float chanceToHit, int damage) : base(name, chanceToHit, damage) {}
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;

        /// <summary>
        ///     The gear's description (weapon type)
        /// </summary>
        /// <returns></returns>
        public string Description => GetType().Name.ToUpper();
        #endregion
    }
}