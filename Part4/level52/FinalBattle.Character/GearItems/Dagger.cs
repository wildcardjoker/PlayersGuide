namespace FinalBattle.Character.GearItems
{
    /// <inheritdoc />
    /// <summary>
    ///     A dagger, deals 1 point of damage
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.GearItems.Gear" />
    public class Dagger : Gear
    {
        #region Constructors
        /// <inheritdoc />
        public Dagger() : base("stab") {}
        #endregion

        #region Overrides of Attack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage = 1;
        #endregion
    }
}