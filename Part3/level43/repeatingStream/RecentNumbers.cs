// repeatingStream

namespace repeatingStream;

/// <summary>
///     Class for holding and managing the recent numbers.
/// </summary>
public class RecentNumbers
{
    #region Fields
    /// <summary>
    ///     The most recent numbers
    /// </summary>
    /// <remarks>
    ///     A <c>Queue</c> stores and retrieves numbers in the order they were added.
    ///     The first number added to the queue is also the first number read/removed from the queue.
    ///     We'll use this object to store the most recent 2 numbers.
    ///     If the queue already contains 2 numbers, we'll remove the first number, thus storing only the 2 most recent.
    /// </remarks>
    private readonly Queue<int> _numbers = new ();

    private readonly Random _random = new ();
    #endregion

    /// <summary>
    ///     Generates random numbers indefinitely.
    /// </summary>
    public void GenerateInfiniteNumbers()
    {
        while (true)
        {
            var number = _random.Next(0, 10); // 0 - 9
            AddNumber(number);
            Console.WriteLine(number);
            Thread.Sleep(1000); // Sleep one second.
        }
    }

    /// <summary>
    ///     Adds the number to the queue.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <remarks>
    ///     If 2 numbers are already stored, the oldest number is removed before adding the next number.
    ///     This ensures that a maximum of 2 numbers are stored at any given time.
    /// </remarks>
    private void AddNumber(int number)
    {
        if (_numbers.Count == 2)
        {
            // Remove the first number, keep the most recent.
            _numbers.Dequeue();
        }

        // Add the number to the queue.
        _numbers.Enqueue(number);
    }
}