using EquipmentRental.Data;

namespace EquipmentRental.Services;

public class ReportService
{
    private AppData data;

    public ReportService(AppData data)
    {
        this.data = data;
    }

    public void ShowSummary()
    {
        Console.WriteLine("Report");
        Console.WriteLine("Users count: " + data.Users.Count);
        Console.WriteLine("Equipment count: " + data.EquipmentList.Count);
        Console.WriteLine("Rentals count: " + data.Rentals.Count);

        int activeRentals = 0;
        decimal totalPenalty = 0;

        foreach (var rental in data.Rentals)
        {
            if (rental.ReturnDate == null)
            {
                activeRentals++;
            }

            totalPenalty += rental.Penalty;
        }

        Console.WriteLine("Active rentals: " + activeRentals);
        Console.WriteLine("Total penalties: " + totalPenalty);
    }
}