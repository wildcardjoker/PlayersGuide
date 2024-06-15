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
        public Dagger() : base("Dagger", "stab", 1) {}
        #endregion
    }
}