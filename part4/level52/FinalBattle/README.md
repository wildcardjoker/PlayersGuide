# The Final Battle

The final battle has arrived. On a volcanic island, enshrouded in a cloud of ash, you have reached the lair of the *Uncoded One*. You have prepared for this fight, and you will return Programming to the lands. Your allies have gathered to engage the Uncoded One's minions on the volcano's slopes while you (and maybe a companion or two) strike into the heart of the Uncoded One's lair to battle and destroy it. Only a True Programmer will be able to survive the encounter, defeat the Uncoded One, and escape!

## Core Game: Building Character

This challenge is deceptively complex: it will require building out enough of the game's foundation to get two characters taking turns in a loop. (Sure, they'll be doing *nothing*, but that's still a big step forward!)

### Objectives

- The game needs to be able to represent characters with a name and able to take a turn. (We'll change this a little in another challenge.)
- The game should be able to have skeleton characters with the name `SKELETON`.
- The game should be able to represent a party with a collection of characters.
- The game should be able to run a battle composed of two parties - heroes and monsters. A battle needs to run a series of rounds where each character in each party (heroes first) can take a turn.
- Before a character takes their turn, the game should report to the user whose turn it is. For example, `It is SKELETON's turn ...`
- The only action the game needs to support at this point is the action of doing nothing (skipping a turn). This action is done by displaying text about doing nothing, resting, or skipping a turn in the console window. For example, `SKELETON did NOTHING.`
- The game must run a battle with a single skeleton in both the hero and the monster party. At this point, the two skeletons should do nothing separately. The game might look like the following:

````console
It is SKELETON's turn ...
SKELETON did NOTHING.

It is SKELETON's turn ...
SKELETON did NOTHING.
...
````

- **Optional**: Put a blank line between each character's turn to differentiate one turn from another.
- **Optional**: At this point, the game will run automatically. Consider adding a `Thread.Sleep(500);` to slow the game down enough to allow the user to see what is happening over time.
