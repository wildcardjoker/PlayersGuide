# The Final Battle

The final battle has arrived. On a volcanic island, enshrouded in a cloud of ash, you have reached the lair of the *Uncoded One*. You have prepared for this fight, and you will return Programming to the lands. Your allies have gathered to engage the Uncoded One's minions on the volcano's slopes while you (and maybe a companion or two) strike into the heart of the Uncoded One's lair to battle and destroy it. Only a True Programmer will be able to survive the encounter, defeat the Uncoded One, and escape!

## Core Game: Building Character

This challenge is deceptively complex: it will require building out enough of the game's foundation to get two characters taking turns in a loop. (Sure, they'll be doing *nothing*, but that's still a big step forward!)

### Building Character Objectives

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

## Core Game: The True Programmer

Our skeletons need a hero to fight. We'll do that by adding in the focal character of the game, the player character; which represents the player directly, called the `True Programmer` by in-game role. The player will choose the `True Programmer`'s name.

### The True Programmer Objectives

- The game must represent a *True Programmer* character with a name supplied by the user.
- Before getting started, ask the user for a name for this character.
- The game should run a battle with the `True Programmer` in the `hero` party vs. a skeleton in the `monster` party. The game might look like the following:

````console
It is TOG's turn ...
TOG did NOTHING.

It is SKELETON's turn ...
SKELETON did NOTHING.
...
````

## Core Game: Actions and Players

The previous two challenges have had the characters taking turns directly. But instead of characters deciding actions, the player controlling the character's team should pick the action for each character. Eventually, there will be several action types to choose from (do nothing, attack, use item, etc.). There will also be multiple player types (computer/AI and human input from the console window). A player is responsible for picking an action for each character in their party. The game should ask the *players* to choose the action rather than asking the *characters* to act for themselves.

For now, the only action type will be a *do-nothing* action, and the only player type will be a *computer player* .

This challenge does not demand that you add new externally visible capabilities but make any needed changes to allow the game to work as described above, with players choosing actions instead of characters. If you are confident your design already supports this, claim the XP now and move on.

### Actions and Players Objectives

- The game needs to be able to represent action types. Each action should be able to run when asked.
- The game needs to include a *do-nothing* action, which displays the same text as in previous challenges (for example, `SKELETON did NOTHING`.)
- The game needs to be able to represent different player types. A player needs the ability to pick an action for a character they control, given the battle's current state.
- The game needs a sole player type: a computer player (a simple AI of sorts). For now, the computer player will simply pick the one available option: do nothing (and optionally wait a bit first with `Thread.Sleep`).
- The game must know which player controls each party to ask the correct player to pick each character's action. Set up the game to ask the player to select an action for each of their characters and then run the chosen action.
- Put a simple computer player in charge of each party.
- **Note**: To somebody watching, the end result of this challenge may look identical to before this challenge.

## Core Game: Attacks

In this challenge, we will extend our game by giving characters attacks and allowing players to pick an attack instead of doing nothing. We won't address tracking or dealing out damage yet.

### Attacks Objectives

- The game needs to be able to represent specific types of attacks. Attacks all have a name (and will have other capabilities later).
- Each character has a standard attack, but this varies from character to character. The True Programmer's (the player character's) attack is called *punch*. The skeleton's attack is called *bone crunch*.
- The program must be capable of representing an *attack* action, our second action type. An attack action must represent which attack is being used and the target of the attack. When this action runs, it should state the attacker, the attack, and the target. For example: `TOG used PUNCH on SKELETON.`
- Our computer player should pick an attack action instead of a do-nothing action. The attack action can be simple for now: always use the character's standard attach and always target the other guy's first character. (If you want to choose a random target of some other logic, you can).
- The game should now run like this:

````console
It is TOG's turn ...
TOG used PUNCH on SKELETON.

It is SKELETON's turn ...
SKELETON used BONE CRUNCH on TOG.
````

## Core Game: Damage and HP

Now that our characters are attacking each other, it is time to let those attacks matter. In this challenge, we will enhance the game to give characters hit points (HP). Attacking should reduce the HP of the target down to 0 but not past it. Reaching `0 HP` means death, which we will deal with in the next challenge.

### Damage and HP Objectives

- Characters should be able to track both their initial/maximum HP and their current HP. The True Programmer should have 25 HP, while skeletons should have 5.
- Attacks should be able to produce `attack data` for a specific use of the attack. For now, this is simple the amount of damage that they will deal this time, though keep in mind that other challenges will add more data to this, including things like the frequency of hitting or missing and damage types.
- The *punch* attack should deliver `1 point` of damage every time, while the `bone crunch` attack should randomly deal 0 or 1. **Hint**: Remember that `Random` can be used to generate random numbers. `random.Next(2)` will generate a 0 or 1 with equal probability.
- The attack action should ask the attack to determine how much damage it caused this time and then reduce the target's HP by that amount. A character's HP should not be lowered below 0.
- The attack action should report how much damage the attack did and what the target's HP is now at. For example, `PUNCH dealt 1 damage to SKELETON.` `SKELETON is not at 4/5 HP`.
- When the game runs after this challenge, the output might look something like this:

````console
It is TOG's turn ...
TOG used PUNCH on SKELETON.
PUNCH dealt 1 damage to SKELETON.
SKELETON is now at 4/5 HP.

It is SKELETON's turn ...
SKELETON used BONE CRUNCH on TOG.
BONE CRUNCH dealt 0 damage to TOG.
TOG is now at 25/25 HP.
...
````

## Core Game: Death

When a character's HP reaches 0, it has been defeated and should be removed from its party. If a party has no characters left, the battle is over.

### Death Objectives

- After an attack deals damage, if the target's HP has reached 0, remove them from the game.
- When you remove a character from the game, display text to illustrate this. For example, `SKELETON has been defected!`
- Between rounds (or between character turns), the game should see if a party has no more living characters. If so, the battle (and the game) should end.
After the battle is over, if the heroes won (there are still surviving characters in the hero party), then display a message stating that the heroes won, and the Uncoded One was defeated. If the monsters won, then display a message saying that the heroes lost and the Uncoded One's forces have prevailed.

## Core Game: Battle Series

The game runs as a series of battles, not just one. The heroes do not win until every battle has been won, while the monsters win if they can stop the heroes in any battle.

### Battle Series Objectives

- There is one part of heroes but multiple parties of monsters. For now, build two monster parties: The first should have one skeleton. The second has two skeletons.
- Start a battle with the heroes and the first party of monsters. When the heroes win, advance to the next party of monsters. If the heroes lose a battle, end the game. If the monsters lose a battle, move to the next battle unless it is the last.

## Core Game: The Uncoded One

It is time to put the final boss nto the game: The Uncoded One itself. We will add this in as a third battle.

### The Uncoded One Objectives

- Define a new type of monster: *The Uncoded One*. It should have `15 HP` and an *unrevalling* attack that randomly deals between 0 and 2 damage when used. (The Uncoded One ought to have more HP than the True Programmer, but much more than 15 HP means the Uncoded One wins everytime. We can adjust these numbers later.)
- Add a third battle to the series that contains The Uncoded One.
