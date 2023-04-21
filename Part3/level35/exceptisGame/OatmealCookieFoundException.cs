// exceptisGame

/// <summary>
///     A custom exception to indicate that the oatmeal raisin cookie has been found.
/// </summary>
public class OatmealCookieFoundException : Exception
{
    #region Constructors
    /// <inheritdoc />
    /// <summary>
    ///     Initializes a new instance of the <see cref="T:OatmealCookieFoundException" /> class.
    /// </summary>
    public OatmealCookieFoundException() {}

    /// <inheritdoc />
    /// <summary>
    ///     Initializes a new instance of the <see cref="T:OatmealCookieFoundException" /> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public OatmealCookieFoundException(string message) : base(message) {}
    #endregion
}