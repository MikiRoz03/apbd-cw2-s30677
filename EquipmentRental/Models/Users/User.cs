using EquipmentRental.Enums;

namespace EquipmentRental.Models.Users;

public abstract class User
{
    private static int nextId = 1;

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }

    public User(string firstName, string lastName)
    {
        Id = nextId;
        nextId++;

        FirstName = firstName;
        LastName = lastName;
    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}