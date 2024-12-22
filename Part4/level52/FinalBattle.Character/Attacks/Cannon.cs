namespace FinalBattle.Character.Attacks
{
    /// <inheritdoc />
    /// <summary>
    ///     A Punch attack
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.Attack" />
    internal class CannonShot : Attack
    {
        #region Fields
        private int _rounds;
        #endregion

        #region Constructors
        /// <inheritdoc />
        public CannonShot() : base("Cannon of Consolas", 1, 1) {}
        #endregion

        #region Implementation of IAttack
        /// <inheritdoc />
        public override int CalculateDamage()
        {
            _rounds++;
            Console.WriteLine($"Rounds: {_rounds}");
            return _rounds % 15 == 0 ? 5 : _rounds % 5 == 0 || _rounds % 3 == 0 ? 2 : 1;
        }
        #endregion
    }
}