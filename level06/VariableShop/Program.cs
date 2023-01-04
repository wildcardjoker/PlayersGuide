/* The Variable Shop
 * You see an old shopkeeper struggling to stack up variables in a window display.
 * "Hoo-wee! All these variable types sure are exciting but setting the all up to show them off to excited new programmers
 * like yourself is a lot of work for these aching bones," she says. "You wouldn't mind helping me set up this program with
 * one variable of every type, would you?"
 *
 * Objectives:
 * Build a program with a variable of all fourteen types described in this level.
 * Assign each of them a value using a literal of the correct type.
 * Use Console.WriteLine to display the contents of each variable.
 */

// I've used the underscore as a digit separator in some of the numbers below.
// It makes them so much easier to read.
// Until I read the book, I had no idea that this was possible

byte byteVariable = 0b00101010; // 42 - the answer to life, the universe, and everything
short shortVariable = -32_768; // This is why you read the whole book, kids!
int intVariable = 0x400; // 1024 in hexadecimal - a nice, round number
long longVariable = -9_123_456_789_000;
sbyte sbyteVariable = 127; // The maximum value. The minimum value is -128
ushort uShortVariable = 65_535;
uint uintVariable = 4_294_967_295; // The maximum value. You could also use uint.MaxValue
ulong ulongVariable = ulong.MaxValue; // See?
char singleCharacter = 'J'; // Could also be a unicode character. Either the character itself ✅ or the Unicode number '\u2705'
string stringVariable = "This is a string variable";
float floatVariable = 1.234567f; // The f notation is required, or the compiler will create a double instead.
double doubleVariable = 1.0000000000001; // Up to 16 significant digits
decimal decimalVariable = 1e-28m; // Up to 28 significant digits. This number is 0.000000000000000000000000001 - my savings interest rate!
bool wildCardJokerIsAwesome = true;

var padding = 25;
// Write those values to the console.
// I'm using the nameof() method to display the variable name as well.
Console.WriteLine($"{nameof(byteVariable).PadRight(padding)}: {byteVariable}");
Console.WriteLine($"{nameof(shortVariable).PadRight(padding)}: {shortVariable}");
Console.WriteLine($"{nameof(intVariable).PadRight(padding)}: {intVariable}");
Console.WriteLine($"{nameof(longVariable).PadRight(padding)}: {longVariable}");
Console.WriteLine($"{nameof(sbyteVariable).PadRight(padding)}: {sbyteVariable}");
Console.WriteLine($"{nameof(uShortVariable).PadRight(padding)}: {uShortVariable}");
Console.WriteLine($"{nameof(uintVariable).PadRight(padding)}: {uintVariable}");
Console.WriteLine($"{nameof(ulongVariable).PadRight(padding)}: {ulongVariable}");
Console.WriteLine($"{nameof(singleCharacter).PadRight(padding)}: {singleCharacter}");
Console.WriteLine($"{nameof(stringVariable).PadRight(padding)}: {stringVariable}");
Console.WriteLine($"{nameof(floatVariable).PadRight(padding)}: {floatVariable}");
Console.WriteLine($"{nameof(doubleVariable).PadRight(padding)}: {doubleVariable}");
Console.WriteLine($"{nameof(decimalVariable).PadRight(padding)}: {decimalVariable}");
Console.WriteLine($"{nameof(wildCardJokerIsAwesome).PadRight(padding)}: {wildCardJokerIsAwesome}");
