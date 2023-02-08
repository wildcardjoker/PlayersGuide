# The Colour

The second pedestal asks you to create a `Colour` class to represent a colour. The pedestal includes an etching of this diagram that illustrates its potential usage:

    --- R -------0 255
    | | G ----0--- 165
    --- B 0------- 0

The colour consists of three parts of channels: red, green, and blue, which indicate how much those channels are lit up. Each channel can be from `0` to `255`. `0` means completely `off`; `255` means completely `on`.

The pedestal also includes some colour names, with a set of numbers indicating their specific values for each channel. There are commonly used colours:

- White (`255,255,255`)
- Black (`0,0,0`)
- Red (`255,0,0`)
- Orange (`255,165,0`)
- Yellow (`255,255,0`)
- Green (`0,128,0`)
- Blue (`0,0,255`)
- Purple (`128,0,128`)

## Objectives

- Define a new `Colour` class with properties for its `red`, `green`, and `blue` channels.
- Add appropriate constructors that you feel make sense for creating new `Colour` objects.
- Create static properties to define the eight commonly used colours for easy access.
- In your main method, make two `Colour`-typed variables. Use a constructor to create a colour instance and use a static property for the other. Display each of their read, green, and blue channel values.
