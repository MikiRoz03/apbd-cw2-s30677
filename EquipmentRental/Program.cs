using EquipmentRental.Data;
using EquipmentRental.Models.Equipment;
using EquipmentRental.Models.Users;
using EquipmentRental.Services;

AppData data = new AppData();
RentalService rentalService = new RentalService(data);
ReportService reportService = new ReportService(data);

Student student1 = new Student("Jan", "Kowalski");
Student student2 = new Student("Anna", "Nowak");
Employee employee1 = new Employee("Piotr", "Kolorowy");

Laptop laptop1 = new Laptop("Dell XPS 13", "Intel i5", 16);
Laptop laptop2 = new Laptop("Lenovo ThinkPad", "Intel i7", 32);
Projector projector1 = new Projector("Optoma ZK1320", 3200, "4K");
Camera camera1 = new Camera("Nikon D9", 24, true);

rentalService.AddUser(student1);
rentalService.AddUser(student2);
rentalService.AddUser(employee1);

rentalService.AddEquipment(laptop1);
rentalService.AddEquipment(laptop2);
rentalService.AddEquipment(projector1);
rentalService.AddEquipment(camera1);

Console.WriteLine("Added equipment and users");

bool rent1 = rentalService.RentEquipment(student1, laptop1, 7);
bool rent2 = rentalService.RentEquipment(student1, projector1, 5);
bool rent3 = rentalService.RentEquipment(student1, camera1, 3);

Console.WriteLine("Student 1 rent laptop: " + rent1);
Console.WriteLine("Student 1 rent projector: " + rent2);
Console.WriteLine("Student 1 rent camera: " + rent3);

bool rent4 = rentalService.RentEquipment(employee1, camera1, 10);
Console.WriteLine("Employee rent camera: " + rent4);

foreach (var rental in data.Rentals)
{
    if (rental.User.Id == employee1.Id && rental.Equipment.Id == camera1.Id && rental.ReturnDate == null)
    {
        rental.DueDate = DateTime.Now.AddDays(-2);
    }
}

bool return1 = rentalService.ReturnEquipment(student1, laptop1);
Console.WriteLine("Student 1 returned laptop: " + return1);

bool mark1 = rentalService.MarkAsUnavailable(laptop2);
Console.WriteLine("Laptop 2 marked as unavailable: " + mark1);

bool rent5 = rentalService.RentEquipment(student2, laptop2, 4);
Console.WriteLine("Student 2 rent unavailable laptop: " + rent5);



Console.WriteLine();
Console.WriteLine("All equipment:");
foreach (var equipment in rentalService.GetAllEquipment())
{
    Console.WriteLine(equipment.Name + " - " + equipment.Status);
}

Console.WriteLine();
Console.WriteLine("Available equipment:");
foreach (var equipment in rentalService.GetAvailableEquipment())
{
    Console.WriteLine(equipment.Name + " - " + equipment.Status);
}

Console.WriteLine();
Console.WriteLine("Active rentals for Student 1:");
foreach (var rental in rentalService.GetUserActiveRentals(student1))
{
    Console.WriteLine(rental.Equipment.Name + " until " + rental.DueDate.ToShortDateString());
}

Console.WriteLine();
Console.WriteLine("Overdue rentals:");
foreach (var rental in rentalService.GetOverdueRentals())
{
    Console.WriteLine(rental.Equipment.Name + " borrowed by " + rental.User.GetFullName());
}

Console.WriteLine();
reportService.ShowSummary();