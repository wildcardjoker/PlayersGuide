namespace FinalBattle.Character.GearItems
{
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
        protected Gear(string name, float chanceToHit, int damage, AttackModifier? attackModifier = null) : base(name, chanceToHit, damage, attackModifier) {}

        /// <inheritdoc />
        protected Gear(string name, string description, float chanceToHit, int damage, AttackModifier? attackModifier = null) : base(
            description,
            chanceToHit,
            damage,
            attackModifier) =>
            Description = name;
        #endregion

        #region Properties
        /// <summary>
        ///     The gear's description (weapon type)
        /// </summary>
        public string Description
        {
            get => string.IsNullOrWhiteSpace(_description) ? GetType().Name.ToUpper() : _description.ToUpper();
            private set => _description = value;
        }
        #endregion

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name.ToUpper();
        #endregion
    }
}