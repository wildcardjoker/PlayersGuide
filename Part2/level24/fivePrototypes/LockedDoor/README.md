# The Locked Door

The fourth pedestal demands constructing a door class with a locking mechanism that requires a unique numeric code to unlock.

You have done something similar before without using a class, but the locking mechanism is new.

The door should only unlock if the passcode is the right one.

The following statements describe how the door works:

- An open door can always be closed.
- A closed (but not locked) door can always be opened.
- A locked door can be unlocked, but a numeric passcode is needed, and the door will only unlock if the code supplied matches the door's current passcode.
- When a door is created, it must be given an initial passcode.
- Additionally, you should be able to change the passcode by supplying the current code and a new one. the passcode should only change if the correct, current code is given.

## Objectives

- Define a `Door` class that can keep track of whether it is `locked`, `open`, or `closed`.
- Make it so you can perform the four transitions defined above with methods.
- Build a method that will allow you to change the passcode for an existing door by supplying the current passcode and new passcode. Only change the passcode if the current passcode is correct.
- Make your main method ask the user for a starting passcode, then create a new `Door` instance. Allow the user to attempt the four transitions described above (`open`, `close`, `lock`, `unlock`) and change the code by typing in text commands.
