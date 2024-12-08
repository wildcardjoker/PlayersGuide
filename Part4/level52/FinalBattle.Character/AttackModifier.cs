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
    /// <summary>
    ///     Initializes a new instance of the <see cref="AttackModifier" /> class.
    /// </summary>
    /// <param name="name">The name of the attack modifier.</param>
    /// <param name="modifier">The value of the attack modifier.</param>
    public AttackModifier(string name = "none", int modifier = 0)
    {
        Name     = name;
        Modifier = modifier;
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

    /// <summary>
    ///     Gets the value of the attack modifier.
    /// </summary>
    private int Modifier {get;}

    /// <summary>
    ///     Gets the name of the attack modifier.
    /// </summary>
    private string Name {get;}
    #endregion

    /// <summary>
    ///     Modifies the attack by Modifier.
    /// </summary>
    /// <param name="attackData">The original attack data.</param>
    /// <returns>A new <c>AttackData</c> object with a modified damage amount.</returns>
    public AttackData ModifyAttack(AttackData attackData) => new (
        attackData.Attack ?? new NoAttack(),
        $"{this} reduced damage by {Math.Abs(Modifier)}",
        attackData.Damage + Modifier);

    #region Overrides of Object
    /// <inheritdoc />
    public override string ToString() => Name.ToUpper();
    #endregion
}