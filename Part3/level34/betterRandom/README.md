# Better Random

The villagers of Randetherin often use the `Random` class but struggle with its limited capabilities. They have asked for your help to make `Random` better. They offer you the Medallion of Powerful Methods in exchange. Their complaints are as follows:

- `Random.NextDouble()` only returns values between 0 and 1, and they often need to be able to produce random `double` values between 0 and another number, such as 0 to 10.
- They need to randomly choose from one of several `strings`, such as "up", "down", "left", and "right", with each having an equal probability of being chosen.
- They need to do a coin toss, randomly picking a `bool`, and usually want it to be a fair coin toss (50% heads and 50% tails) but occasionally want unequal probabilities. For example, a 75% chance of `true` and a 25% chance of `false`.

## Objectives

- Create a new static class to add extension methods for `Random`.
- As described above, add a `NextDouble` extension method that gives a maximum value for a randomly generated `double`.
- Add a `NextString` extension method for Random that allows you to pass in any number of `string` values (use `params`) and randomly pick one of them.
- Add a `CoinFlip` method that randomly picks a `bool` value. It should have an optional parameter that indicates the frequency of heads coming up, which should default to 0.5, or 50% of the time.
- **Answer this question**: In you opinion, would it be better to make a derived `AdvancedRandom` class that adds these methods or use extension methods and why?

### Answer

Extension methods are better in my opinion, as it makes the code cleaner, and a derived class would need to be instantiated, as opposed to a static class with extension methods.
