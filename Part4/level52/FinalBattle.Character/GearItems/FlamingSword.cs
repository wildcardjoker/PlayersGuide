namespace FinalBattle.Character.GearItems
{
    /// <inheritdoc />
    /// <summary>
    ///     A sword, deals 2 points of damage
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.GearItems.Gear" />
    public class FlamingSword : Gear
    {
        #region Constructors
        /// <inheritdoc />
        public FlamingSword() : base("slash", 0.75f, 2, new AttackModifier("fire", AttackModifierType.Offensive, DamageType.Fire, 1)) {}
        #endregion

        #region Overrides of Attack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage;
        #endregion
    }
}