﻿namespace FinalBattle.Character
{
    #region Using Directives
    using GearItems;
    #endregion

    /// <summary>
    ///     Represents a Character
    /// </summary>

    // TODO: Add Interface
    public class Character
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Character" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="attacks">The attacks available to the character</param>
        /// <param name="attackModifier">The attack modifier (increases or decreases damage incurred)</param>
        /// <param name="hitPoints">The hit points.</param>
        public Character(string name, IEnumerable<Attack>? attacks, AttackModifier attackModifier, int hitPoints = 10)
        {
            Name           = name.ToUpper();
            Attacks        = attacks?.ToList() ?? new List<Attack>();
            AttackModifier = attackModifier;
            HitPoints      = hitPoints;
            MaxHitPoints   = hitPoints;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the attack modifier.
        /// </summary>
        /// <value>
        ///     The attack modifier.
        /// </value>
        public AttackModifier AttackModifier {get;}

        /// <summary>
        ///     Gets the attacks.
        /// </summary>
        /// <value>
        ///     The attacks.
        /// </value>
        public List<Attack> Attacks {get;}

        /// <summary>
        ///     Gets the current health.
        /// </summary>
        /// <value>
        ///     The current health.
        /// </value>
        public string CurrentHealth => $"{HitPoints}/{MaxHitPoints} HP";

        /// <summary>
        ///     Gets or sets the equipped gear.
        /// </summary>
        /// <value>
        ///     The currently-equipped gear.
        /// </value>
        public Gear? EquippedGear {get; set;} = null;

        /// <summary>
        ///     Gets the hit points.
        /// </summary>
        /// <value>
        ///     The hit points.
        /// </value>
        public int HitPoints {get; private set;}

        /// <summary>
        ///     Gets or sets a value indicating whether this is the Active character.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this is the current character; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive {get; set;}

        /// <summary>
        ///     Gets a value indicating whether this <see cref="Character" /> is wounded.
        /// </summary>
        /// <value>
        ///     <c>true</c> if wounded; otherwise, <c>false</c>.
        /// </value>
        public bool IsWounded => HitPoints <= MaxHitPoints / 2;

        /// <summary>
        ///     Gets the maximum hit points.
        /// </summary>
        /// <value>
        ///     The maximum hit points.
        /// </value>
        public int MaxHitPoints {get;}

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name {get;}
        #endregion

        /// <summary>
        ///     Modifies the hit points by the specified amount.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <remarks>Negative values inflict damage, positive values restore health.</remarks>
        public void ModifyHitPoints(int points) => HitPoints = Math.Clamp(HitPoints + points, 0, MaxHitPoints);

        #region Overrides of Object
        /// <inheritdoc />
        public override string ToString() => Name;
        #endregion
    }
}