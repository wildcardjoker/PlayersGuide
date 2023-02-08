# The Password Validator

The fifth and final pedestal describes a class that represents a concept more abstract than the first four: a password validator.

You must create a class that can determine if a password is valid (meets the rules defined for a legitimate password).

The pedestal initially doesn't describe any rules, but as you brush the dust off the pedestal, it vibrates for a moment, and the following rules appear:

- Passwords must be at least 6 letters long and no more than 13 letters long.
- Passwords must contain at least one uppercase letter, one lowercase letter, and one number.
- Passwords cannot contain a capital T or an ampersand (&) because Ingelmar in IT has decreed it.

That last rule seems random, and you wonder if the pedestal is just tormenting you with obscure rules.

You ponder for a moment about how to decide if a character is uppercase, lowercase, or a number, but while scratching your head, you notice a piece of folded parchment on the ground near your feet. You pick it up, unfold it, and read it:

    foreach with a string lets you get its characters!
    > foreach (char letter in word) { ... }

    char has static methods to categorize letters!
    > char.IsUpper('A'), char.IsLower('a'), char.IsDigit('0')

That might be useful information! You are grateful to whoever left it behind. It is signed simply, "A".

## Objectives

- Define a new `PasswordValidator` class that can be given a password and determine if the password follows the rules above.
- Make your main method loop forever, asking for a password and reporting whether the password is allowed using an instance of the `PasswordValidator` class.
