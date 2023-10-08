// repeatingStream

namespace repeatingStream;

public class RecentNumbers
{
    #region Fields
    public Queue<int> Numbers = new ();
    #endregion

    public void AddNumber(int number)
    {
        if (Numbers.Count == 2)
        {
            // Remove the first number, keep the most recent.
            Numbers.Dequeue();
        }

        Numbers.Enqueue(number);
    }
}