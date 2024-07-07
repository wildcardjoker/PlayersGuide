namespace FinalBattle.Character.GearItems
{
    /// <inheritdoc />
    /// <summary>
    ///     Vin's Bow. Has a quick shot attack.
    /// </summary>
    /// <remarks>
    ///     The attack will be successful 50% of the time, and deal 3 points of damage.
    /// </remarks>
    /// <seealso cref="T:FinalBattle.Character.GearItems.Gear" />
    public class VinsBow : Gear
    {
        #region Constructors
        /// <inheritdoc />
        public VinsBow() : base("Vin's Bow", "Quick Shot", 0.5f, 3) {}
        #endregion

        #region Overrides of Attack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage;
        #endregion
    }
}