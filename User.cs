public class RegisteredUser : IComparable<RegisteredUser>
{
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public string Email { get; }

    // Constructor
    public RegisteredUser(string firstName, string lastName, int age, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Email = email;
    }

    // Implementerer IComparable for at sortere efter efternavn
    public int CompareTo(RegisteredUser other)
    {
        return string.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
    }

    // Override ToString() for nem udskrivning
    public override string ToString()
    {
        return $"{FirstName} {LastName}, {Age}, {Email}";
    }
}
