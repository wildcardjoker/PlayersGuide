Console.WriteLine("Password Validator");
Console.WriteLine("Passwords must follow these rules:");
Console.WriteLine("- Password must be between 6 and 13 characters long");
Console.WriteLine("- Passwords must contain at least one Uppercase letter (A-Z)");
Console.WriteLine("- Passwords must contain at least one lowercase letter (a-z)");
Console.WriteLine("- Passwords must contain at least one number (0-9)");
Console.WriteLine("- Passwords cannot contain the letter T");
Console.WriteLine("- Passwords cannot contain an ampersand (&)");

while (true)
{
    Console.Write("Please enter a password: ");

    // We should mask this, but it hasn't been covered.
    // DO NOT ENTER AN ACTUAL PASSWORD HERE

    var userPassword = Console.ReadLine() ?? "none";
    var validator    = new PasswordValidator(userPassword);
    Console.WriteLine(validator.IsValid() ? "Password is valid" : "Password is not valid");
}

public class PasswordValidator
{
    #region Fields
    private readonly int MaximumLength = 13;
    private readonly int MinimumLength = 6;
    #endregion

    #region Constructors
    public PasswordValidator(string password) => Password = password;
    #endregion

    #region Properties
    public string Password {get;}
    #endregion

    public bool IsValid() => IsValidLength() && ContainsUpper() && ContainsLower() && ContainsNumber() && DoesNotContainInvalidLetter() && DoesNotContainInvalidSymbol();

    private bool ContainsLower()
    {
        foreach (var character in Password)
        {
            if (char.IsLower(character))
            {
                return true;
            }
        }

        Console.WriteLine("Password does not contain a lowercase letter");
        return false;
    }

    private bool ContainsNumber()
    {
        foreach (var character in Password)
        {
            if (char.IsDigit(character))
            {
                return true;
            }
        }

        Console.WriteLine("Password does not contain a number");
        return false;
    }

    private bool ContainsUpper()
    {
        foreach (var character in Password)
        {
            if (char.IsUpper(character))
            {
                return true;
            }
        }

        Console.WriteLine("Password does not contain an uppercase letter");
        return false;
    }

    private bool DoesNotContainInvalidLetter()
    {
        foreach (var character in Password)
        {
            // Ideally, we'd use a .ToLower() call here, but it hasn't been introduced.
            if (character == 'T' || character == 't')
            {
                Console.WriteLine($"Password contains an invalid letter ({character})");
                return false;
            }
        }

        return true;
    }

    private bool DoesNotContainInvalidSymbol()
    {
        foreach (var character in Password)
        {
            if (character == '&')
            {
                Console.WriteLine("Password contains an invalid character (&)");
                return false;
            }
        }

        return true;
    }

    private bool IsValidLength()
    {
        var passwordLength = Password.Length;
        if (passwordLength < MinimumLength)
        {
            Console.WriteLine($"Password is not long enough. Password is {passwordLength} characters, must be at least {MinimumLength} characters.");
            return false;
        }

        if (passwordLength > MaximumLength)
        {
            Console.WriteLine($"Password is too long. Password is {passwordLength} characters, must be no more than {MaximumLength} characters");
            return false;
        }

        return true;
    }
}