namespace FinalBattle.Character
{
    /// <summary>
    ///     Represents a Character
    /// </summary>

    // TODO: Add Interface
    public class Character
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Character" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="attacks">The attacks available to the character</param>
        /// <param name="hitPoints">The hit points.</param>
        public Character(string name, IEnumerable<Attack>? attacks, int hitPoints = 10)
        {
            Name         = name.ToUpper();
            Attacks      = attacks?.ToList() ?? new List<Attack>();
            HitPoints    = hitPoints;
            MaxHitPoints = hitPoints;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the attacks.
        /// </summary>
        /// <value>
        ///     The attacks.
        /// </value>
        public List<Attack> Attacks {get;}

        /// <summary>
        ///     Gets the current health.
        /// </summary>
        /// <value>
        ///     The current health.
        /// </value>
        public string CurrentHealth => $"{HitPoints}/{MaxHitPoints} HP";

        /// <summary>
        ///     Gets the hit points.
        /// </summary>
        /// <value>
        ///     The hit points.
        /// </value>
        public int HitPoints {get; private set;}

        /// <summary>
        ///     Gets the maximum hit points.
        /// </summary>
        /// <value>
        ///     The maximum hit points.
        /// </value>
        public int MaxHitPoints {get;}

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name {get;}
        #endregion

        /// <summary>
        ///     Modifies the hit points by the specified amount.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <remarks>Negative values inflict damage, positive values restore health.</remarks>
        public void ModifyHitPoints(int points) => HitPoints = Math.Clamp(HitPoints + points, 0, MaxHitPoints);

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;
        #endregion
    }
}