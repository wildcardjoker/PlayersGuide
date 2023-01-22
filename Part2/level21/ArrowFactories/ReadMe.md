# Arrow Factories

Vin Fletcher sometimes makes custom-ordered arrows, but these are rare. Most of the time, he sells one of the following standard arrows:

- The `Elite Arrow`, made from a steel arrowhead, plastic fletching, and a 95cm shaft.
- The `Beginner Arrow`, made from a wood arrowhead, goose feathers, and a 75cm shaft.
- The `Marksman Arrow`, made from a steel arrowhead, goose feathers, and a 65cm shaft.

You can make static methods to make these specific variations of arrows easy.

## Objectives

- Modify your `Arrow` class one final time to include static methods of the form `public static Arrow CreateEliteArrow(){...}` for each of the three above arrow types.
- Modify the program to allow users to choose one of these pre-defined types or a custom arrow. If they select one of the predefined styles, produce an `Arrow` instance using one of the new static methods. If they choose to make a custom arrow, use your earlier code to get their custom data about the desired arrow.
