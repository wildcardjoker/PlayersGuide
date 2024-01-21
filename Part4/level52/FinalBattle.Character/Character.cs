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
            Name      = name;
            Attacks   = attacks?.ToList() ?? new List<Attack>();
            HitPoints = hitPoints;
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
        ///     Gets the hit points.
        /// </summary>
        /// <value>
        ///     The hit points.
        /// </value>
        public int HitPoints {get; private set;}

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name {get;}
        #endregion
    }
}