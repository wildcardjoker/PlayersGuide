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
        #region Fields
        private string? _description;
        #endregion

        #region Constructors
        /// <inheritdoc />
        protected Gear(string name, float chanceToHit, int damage) : base(name, chanceToHit, damage) {}

        /// <inheritdoc />
        protected Gear(string name, string description, float chanceToHit, int damage) : base(description, chanceToHit, damage) => Description = name;
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;

        /// <summary>
        ///     The gear's description (weapon type)
        /// </summary>
        /// <returns></returns>
        public string Description
        {
            get => string.IsNullOrWhiteSpace(_description) ? GetType().Name.ToUpper() : _description.ToUpper();
            private set => _description = value;
        }
        #endregion
    }
}