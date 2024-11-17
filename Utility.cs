using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class UserUtility
{
    private static string filePath = @"Files\Users.txt";
    private static List<RegisteredUser> registeredUsers = new List<RegisteredUser>();

    // Indlæs brugere fra filen
    public static void LoadUsersFromFile()
    {
        registeredUsers.Clear();
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(", ");
                if (parts.Length == 4)
                {
                    var firstName = parts[0];
                    var lastName = parts[1];
                    var age = int.Parse(parts[2]);
                    var email = parts[3];
                    var user = new RegisteredUser(firstName, lastName, age, email);
                    registeredUsers.Add(user);
                }
            }
        }
    }

    // Gem en bruger i filen
    public static void SaveUserToFile(RegisteredUser user)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{user.FirstName}, {user.LastName}, {user.Age}, {user.Email}");
        }
        registeredUsers.Add(user);
    }

    // Returner sorteret liste af brugere
    public static List<RegisteredUser> GetSortedUsers()
    {
        return registeredUsers.OrderBy(user => user.LastName).ToList();
    }

    // Udskriv listen af brugere
    public static void DisplayUsers()
    {
        var sortedUsers = GetSortedUsers();
        if (sortedUsers.Any())
        {
            Console.WriteLine("\nRegistrerede brugere:");
            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("Ingen registrerede brugere fundet.");
        }
    }
}
