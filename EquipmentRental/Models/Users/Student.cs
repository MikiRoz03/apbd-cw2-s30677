using EquipmentRental.Enums;

namespace EquipmentRental.Models.Users;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
        UserType = UserType.Student;
    }
}