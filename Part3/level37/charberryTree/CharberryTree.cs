namespace charberryTree
{
    /// <summary>
    ///     A Tree whose fruit ripens randomly.
    /// </summary>
    public class CharberryTree
    {
        #region Fields
        private readonly Random _random = new ();
        #endregion

        #region Events
        /// <summary>
        ///     Occurs when a fruit has ripened.
        /// </summary>
        public event Action? Ripened;
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="CharberryTree" /> fruit is ripe.
        /// </summary>
        /// <value>
        ///     <c>true</c> if ripe; otherwise, <c>false</c>.
        /// </value>
        public bool Ripe {get; set;}
        #endregion

        /// <summary>
        ///     Randomly ripens the fruit.
        /// </summary>
        public void MaybeGrow()
        {
            // Only a tiny chance of ripening each time, but we try a lot!
            if (_random.NextDouble() < 0.00000001 && !Ripe)
            {
                Ripe = true;
                Ripened?.Invoke();
            }
        }
    }
}