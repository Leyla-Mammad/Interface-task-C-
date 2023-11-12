
using System;
using System.Linq;

public interface IAccount
{
    bool PasswordChecker(string password);
    void ShowInfo();
}

public class User : IAccount
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    private string password;

    public string Password
    {
        get => password;
        set
        {
            if (PasswordChecker(value))
            {
                password = value;
            }
            else
            {
                Console.WriteLine("Invalid password. Please make sure it meets the specified conditions.");
            }
        }
    }

    public bool PasswordChecker(string password)
    {
        // Check password conditions
        if (password.Length >= 8 &&
            password.Any(char.IsUpper) &&
            password.Any(char.IsLower) &&
            password.Any(char.IsDigit))
        {
            return true;
        }
        return false;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Fullname: {Fullname}");
        Console.WriteLine($"Email: {Email}");
    }
}

class Program
{
    static void Main()
    {
        User user = new User
        {
            Fullname = "John Doe",
            Email = "john.doe@example.com",
            Password = "StrongPass123"
        };

        user.ShowInfo();
    }
}