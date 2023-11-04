# Uniter of Adds

"This city used the Four Great Adds for a million clock cycles. But legend foretells of a *True Programmer* who could reunite them," the Regent of the City of Dynamak tells you. She shows you the four great adds:

```c#
public static class Adds
{
    public static int      Add(int      a, int      b) => a + b;
    public static double   Add(double   a, double   b) => a + b;
    public static string   Add(string   a, string   b) => a + b;
    public static DateTime Add(DateTime a, TimeSpan b) => a + b;
}
```

"The code is identical, but the four types involved demand four different methods. So we have survived with the Four Great Adds. Uniting them would be a sign to us that you are a True Programmer." With dynamic typing, you know this is possible.

## Objectives

- Make a single `Add` method that can replace all four of the above methods using `dynamic`.
- Add code to your main method to call the new method with two `int`s, two `double`s, two `sting`s, and a `DateTime` and a `TimeSpan`, and display the results.
- **Answer this question**: What downside do you see with using `dynamic` here?
