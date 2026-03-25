using EquipmentRental.Enums;

namespace EquipmentRental.Models.Users;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        UserType = UserType.Employee;
    }
}