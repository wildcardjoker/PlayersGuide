# The Great Humanizer

The people in the village of New Ghett come to you with a complaint. "Our leaders keep giving us `DateTimes` that are hard to understand." They show you an example:

`When is the feast? 12/21/2021 9:56:34 AM`

"We keep showing up too early of too late for the feasts! We have to pull out our clocks and calendars! Isn't there a better way?" When pressed, they describe what they'd prefer. "What if it said `When is the feast? 11 horus from now` or `When is the feast? 6 days from now`? This is easier to understand, and we wouldn't show up too early or too late. If you can do this for us, we can retrieve the NuGet Medallion for you."

You know that writing code to convert times and dates to human-friendly strings would be a lot of work, but you suspect other programmers have already solved this problem and made a NuGet package for it.

## Objectives

- Start by making a new program that does what whas shown above: displaying the raw `DateTime`.
- Add the NuGetpackage [**Humanizer.Core**](https://humanizr.net) to your project using the instructions in the level. This NuGet package provides many extension methods (Level 34) that make it easy to display things in human-readable formats.
- Call the new `DateTime` extension method `Humanize()` provided by this library to get a better format. You will also need to add a `using Himanizer;` directive to call this.
- Run the program with a few different hour offsets (for example, `DateTime.UtcNow.Addhours(2.5)` and `DateTime.UtcNow.AddHours(50)`) to see that it correctly displays a human-readable message.
