// FinalBattle.Character

namespace FinalBattle.Character;

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
    ///     Gets the value of the attack modifier.
    /// </summary>
    public int Modifier {get;}

    /// <summary>
    ///     Gets the name of the attack modifier.
    /// </summary>
    public string Name {get;}
    #endregion
}