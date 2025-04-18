// FinalBattle.Character

namespace FinalBattle.Character;

#region Using Directives
using Attacks;
#endregion

/// <summary>
///     Represents a modifier that can be applied to an attack.
/// </summary>
public class AttackModifier
{
    #region Constructors
    /// <inheritdoc />
    public AttackModifier(string name = "none", int modifier = 0) : this(name, AttackModifierType.Defensive, DamageType.Normal, modifier) {}

    /// <summary>
    ///     Initializes a new instance of the <see cref="AttackModifier" /> class.
    /// </summary>
    /// <param name="name">The name of the attack modifier.</param>
    /// <param name="modifierType">The Attack Modifier type (offensive or defensive).</param>
    /// <param name="resistsDamageType">The type of damage that the attack modifier resists. The default is <c>Normal</c>.</param>
    /// <param name="modifier">The value of the attack modifier.</param>
    public AttackModifier(string name, AttackModifierType modifierType, DamageType resistsDamageType, int modifier)
    {
        Name              = name;
        Modifier          = modifier;
        ResistsDamageType = resistsDamageType;
        ModifierType      = modifierType;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets a value indicating whether this instance has an Attack Modifier.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance has an Attack Modifier; otherwise, <c>false</c>.
    /// </value>
    public bool HasModifier => Modifier != 0;

    public AttackModifierType ModifierType {get;}

    /// <summary>
    ///     Gets the value of the attack modifier.
    /// </summary>
    private int Modifier {get;}

    /// <summary>
    ///     Gets the name of the attack modifier.
    /// </summary>
    private string Name {get;}

    /// <summary>
    ///     Gets the type of damage resisted by the modifier.
    /// </summary>
    /// <value>
    ///     The damage type that the modifier resists.
    /// </value>
    private DamageType ResistsDamageType {get;}
    #endregion

    /// <summary>
    ///     Modifies the attack by Modifier.
    /// </summary>
    /// <param name="attackData">The original attack data.</param>
    /// <returns>A new <c>AttackData</c> object with a modified damage amount.</returns>
    public AttackData ModifyAttack(AttackData attackData)
    {
        if (Modifier == 0 || (ModifierType == AttackModifierType.Defensive && attackData.Attack?.DamageType != ResistsDamageType))
        {
            return attackData;
        }

        var message = ModifierType == AttackModifierType.Offensive ? $"{this} added {Modifier} damage" : $"{this} reduced damage by {Math.Abs(Modifier)}";
        return new AttackData(attackData.Attack ?? new NoAttack(), message, attackData.Damage + Modifier);
    }

    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => Name.ToUpper();
    #endregion
}