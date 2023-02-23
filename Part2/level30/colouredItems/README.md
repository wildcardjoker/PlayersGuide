# Coloured items

You have a `sword`, a `bow`, and an `axe` in front or you, defined like this:

    public class Sword { }
    public class Bow   { }
    public class Axe   { }

You want to associate a colour with these items (or any item type). You could make `ColouredSword` derived from `Sword` that adds a `Colour` property, but doing this for all three item types will be painstaking. Instead, you define a new generic `ColouredItem` class that does this for any item.

## Objectives

- Put the three class definitions above into a new project.
- Define a generic class to represent a coloured item. It must have properties for the item itself (generic in type) and a `ConsoleColor` associated with it.
- Add a `void Display()` method to your coloured item type that changes the console's foreground colour to the item's colour and displays the item in that colour. (**Hint**: it is sufficient to just call `ToString()` on the item to get a text representation).
- In your main method, create a new coloured item containing a blue `sword`, a red `bow`, and a green `axe`. Display all three items to ess each item displayed in its colour.
