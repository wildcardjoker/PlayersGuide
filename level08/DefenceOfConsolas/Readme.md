# The defence of Consolas

The Uncoded One has begun an assault on the city of Consolas; the situation is dire. From a moving airship called the `Manticore`, massive fireballs capable of destroying city blocks are being catapulted into the city.

The city is arranged in blocks, numbered like a chessboard.

The city's only defence is a movable magical barrier, operated by a squad of four that can protect a single city block by
putting themselves in each of the target's four adjacent blocks, as shown below:

    8
    7       *
    6      *X*
    5       * 
    4
    3
    2
    1 2 3 4 5 6 7 8

For example, to protect the city block at (`Row 6`, `Column 5`), the crew deploys themselves to (`Row 6`, `Column 4`), (`Row 5`, `Column 5`), (`Row 6`, `Column 6`), and (`Row 7`, `Column 5`).

The good news is that if we can compute the deployment locations fast enough, the crew can be deployed around the target in time to prevent catastrophic damage to the city for as long as the siege lasts. The City of Consolas needs a program to tell the squad where to deploy, given the anticipated target. Something like this:

    Target Row? 6
    Target Column? 5
    Deploy to:
    (6,4)
    (5,5)
    (6,6)
    (7,5)

## Objectives

- Ask the user for the target row and column.
- Compute the neighbouring rows and columns of where to deploy the squad.
- Display the deployment instructions in a different colour of your choosing.
- Change the window title to be "`Defence of Consolas`".
- Play a sound with `Console.Beep` when the results have been computed and displayed.
