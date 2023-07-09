namespace charberryTree
{
    public class CharberryTree
    {
        #region Fields
        private readonly Random _random = new ();
        #endregion

        #region Properties
        public bool Ripe {get; set;}
        #endregion

        public void MaybeGrow()
        {
            // Only a tiny chance of ripening each time, but we try a lot!
            if (_random.NextDouble() < 0.00000001 && !Ripe)
            {
                Ripe = true;
            }
        }
    }
}