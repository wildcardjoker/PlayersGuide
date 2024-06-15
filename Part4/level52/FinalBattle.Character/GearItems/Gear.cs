namespace FinalBattle.Character.GearItems
{
    #region Using Directives
    using Items;
    #endregion

    /// <inheritdoc />
    /// <summary>
    ///     Base class for items.
    /// </summary>
    public abstract class Gear : InventoryItem
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Gear" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="attack">The attack description</param>
        /// <param name="damage">The amount of damage inflicted by the gear.</param>
        protected Gear(string name, string attack, int damage)
        {
            Name   = name.ToUpper();
            Attack = attack.ToUpper();
            Damage = damage;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the attack.
        /// </summary>
        /// <value>
        ///     The attack.
        /// </value>
        protected string Attack {get; init;}

        protected int Damage {get; init;}
        #endregion
    }
}