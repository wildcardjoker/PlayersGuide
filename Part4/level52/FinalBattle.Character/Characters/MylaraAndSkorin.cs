// FinalBattle.Character

namespace FinalBattle.Character.Characters;

#region Using Directives
using Attacks;
#endregion

/// <inheritdoc />
/// <summary>
///     Mylara and Skorin: a team who fire a cannon shot at their enemies.
/// </summary>
/// <seealso cref="T:FinalBattle.Character.Character" />
public class MylaraAndSkorin : Character
{
    #region Constructors
    /// <inheritdoc />
    public MylaraAndSkorin() : base("Mylara and Skorin", new[] {new CannonShot()}, new AttackModifier(), 15) {}
    #endregion
}