# Lists of Commands

In [Level 27](/../level27), we encountered a robot with an array to hold commands to run. But we could make the robot have as many commands as we want by turning the array into a list. Revisit that challenge to make the robot use a list instead of an array, and add commands to run until the user says to stop.

## Objectives

- Change the `Robot` class to use a `List<IRobotCommand>` instead of an array for it's `Commands` property.
- Instead of looping three times, go until the user types `stop`. Then run all of the commands created.
