# Safer Number Crunching

"Master Programmer! We need your help! We are but humble number crunchers. We read numbers in, work with them for a bit, then display the results. But not everybody enters good numbers. Sometimes, we type in wrong things by accident. And sometimes, somebody does it *on purpose*. Trolls, looking to cause trouble, I tell ya!"

"We've heard about these so-called `TryParse` methods that cannot fail or break. We know you're here looking for Medallions and allies. If you can help us with this, the Medallion of Reference Passing is yours, and we will join you at the final battle."

## Objectives

- Create a program that asks the user for an `int` value. Use the static `int.TryParse(string s, out int result)` method to parse the number. Loop until they enter a valid value.
- Extend the program to do the same for both `double` and `bool`.
