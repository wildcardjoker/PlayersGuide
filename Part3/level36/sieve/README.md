# The Sieve

The Island of Delgata is home to the Numeromechanical Sieve, a machine that takes numbers and judges them as good or bad numbers. In ancient times, the sieve could be supplied with a single method to use as a filter by the island's rulers, making the sieve adaptable as leadership changed over time. The Delgatans will give you the Medallion of Delegates if you can reforge their Numeromechanical Sieve.

## Objectives

- Create a `Sieve` class with a `public bool IsGood(int number)` method. This class needs a constructor with a delegate parameter that can be invoked later within the `IsGood` method. **Hint**: You can make your own delegate type or use `Func<int,bool>`.
- Define methods with an `int` parameter and a `bool` return type for the following: (1) returns `true` for even numbers, (2) returns `true` for positive numbers, and (3) returns `true` for multiples of 10.
- Create a program that asks the user to pick one of those three filters, constructs a new `Sieve` instance by passing in one of those methods as a parameter, and then ask the user to enter numbers repeatedly, displaying whether the number is good or bad depending on the filter in use.
- **Answer this question**: Describe how you could have also solved this problem with inheritance and polymorphism. Which solution seems more straightforward to you, and why?