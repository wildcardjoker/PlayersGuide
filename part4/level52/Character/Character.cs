namespace FinalBattle.Character
{
    /// <summary>
    ///     Represents a Character
    /// </summary>

    // TODO: Add Interface and common classes
    public class Character
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Character" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="hitPoints">The hit points.</param>
        public Character(string name, int hitPoints = 10)
        {
            Name      = name;
            HitPoints = hitPoints;
        }
        #endregion

        #region Properties
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

        /// <summary>
        ///     Convert the character's name to Uppercase.
        /// </summary>
        public string UpperName => Name.ToUpper();
        #endregion
    }
}