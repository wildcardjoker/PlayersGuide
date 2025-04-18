namespace FinalBattle.Character.Attacks
{
    /// <summary>
    ///     A Punch attack
    /// </summary>
    /// <seealso cref="FinalBattle.Character.Attack" />
    internal class ChargedPunch : Attack
    {
        #region Constructors
        /// <inheritdoc />
        public ChargedPunch() : base("charged punch", DamageType.Physical, .9f, 2, new AttackModifier("Charge", AttackModifierType.Offensive, DamageType.Physical, 1)) {}
        #endregion

        #region Implementation of IAttack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage;
        #endregion
    }
}