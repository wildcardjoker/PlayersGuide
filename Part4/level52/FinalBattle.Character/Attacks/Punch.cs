namespace FinalBattle.Character.Attacks
{
    /// <summary>
    ///     A Punch attack
    /// </summary>
    /// <seealso cref="FinalBattle.Character.Attack" />
    internal class Punch : Attack
    {
        #region Constructors
        /// <inheritdoc />
        public Punch() : base("punch", 1, 1) {}
        #endregion

        #region Implementation of IAttack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage;
        #endregion
    }
}