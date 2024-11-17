using System;

public class FileHandler
{
    static void Main()
    {
        try
        {
            // Sørg for, at Files-mappen eksisterer
            Directory.CreateDirectory("Files");

            // Indlæs brugere fra filen ved opstart
            UserUtility.LoadUsersFromFile();

            // Vis registrerede brugere ved opstart
            UserUtility.DisplayUsers();

            // Indtast brugerdata
            Console.WriteLine("\nIndtast fornavn:");
            string firstName = Console.ReadLine();
            ValidateName(firstName);

            Console.WriteLine("Indtast efternavn:");
            string lastName = Console.ReadLine();
            ValidateName(lastName);

            Console.WriteLine("Indtast alder (18-50):");
            int age = int.Parse(Console.ReadLine());
            ValidateAge(age);

            Console.WriteLine("Indtast e-mail:");
            string email = Console.ReadLine();
            ValidateEmail(email);

            // Opret og gem bruger
            var newUser = new RegisteredUser(firstName, lastName, age, email);
            UserUtility.SaveUserToFile(newUser);

            // Vis opdateret liste af brugere
            Console.WriteLine("\nOpdateret liste af registrerede brugere:");
            UserUtility.DisplayUsers();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Programmet er afsluttet.");
        }
    }

    // Valideringsmetoder
    static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Navnet må ikke være tomt.");
        }
    }

    static void ValidateAge(int age)
    {
        if (age < 18 || age > 50)
        {
            throw new ArgumentException("Alderen skal være mellem 18 og 50.");
        }
    }

    static void ValidateEmail(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new ArgumentException("E-mailen er ugyldig.");
        }
    }
}
