# The Long Game

The island of Io has a long-running tradition that was destroyed when the Uncoded One arrived. The inhabitants of Io would compete over a long period of time to see who could press the most keys on the keyboard. But the Uncoded One's arrival destroyed the island's ability to use the Medallion of Files, and the historic competitions spanning days, weeks, and months have become impossible. As a True Programmer, you can use the Medallion of Files to bring back these long-running games to the island.

## Objectives

- When the program starts, ask the user to enter their name.
- By default, the player starts with a score of 0.
- Add 1 point to their score for every keypress they make.
- Display the player's updated score after each keypress.
- When the player presses the `ENTER` key, end the game. **Hint**: the following code reads a keypress and checks whether it was the `ENTER` key: `Console.ReadKey().Key == ConsoleKey.Enter`.
When the player presses `ENTER`, save their score in a file. **Hint**: Consider saving this to a file named `[username].txt`. For this challenge, you can assume the user doesn't enter a name that would produce an illegal file name (such as `*`).
When a user enters a name at the start, if they already have a previously saved score, start with that score instead.
