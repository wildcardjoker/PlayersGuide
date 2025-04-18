﻿namespace FinalBattle.Character.GearItems
{
    /// <inheritdoc />
    /// <summary>
    ///     A sword, deals 2 points of damage
    /// </summary>
    /// <seealso cref="T:FinalBattle.Character.GearItems.Gear" />
    public class Sword : Gear
    {
        #region Constructors
        /// <inheritdoc />
        public Sword() : base("slash", 0.75f, 2) {}
        #endregion

        #region Overrides of Attack
        /// <inheritdoc />
        public override int CalculateDamage() => Damage;
        #endregion
    }
}