// betterRandom

namespace betterRandom;

public static class RandomExtensions
{
    /// <summary>
    ///     Flip a coin, using the specified frequency for Heads.
    /// </summary>
    /// <param name="random">The random.</param>
    /// <param name="frequency">The frequency of heads returning. The default is 50%.</param>
    /// <returns></returns>
    public static bool CoinFlip(this Random random, double frequency = 0.5) => random.NextDouble() < frequency;

    /// <summary>
    ///     Returns a double-precision value between 0 and the specified maximum.
    /// </summary>
    /// <param name="random">The random.</param>
    /// <param name="maximum">The maximum.</param>
    /// <returns></returns>
    public static double NextDouble(this Random random, double maximum) => random.NextDouble() * maximum;

    /// <summary>
    ///     Returns a string from the available options.
    /// </summary>
    /// <param name="random">The random.</param>
    /// <param name="strings">The strings.</param>
    /// <returns></returns>
    public static string NextString(this Random random, params string[] strings) => strings[random.Next(strings.Length)];
}