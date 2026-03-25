using EquipmentRental.Data;
using EquipmentRental.Enums;
using EquipmentRental.Models;
using EquipmentRental.Models.Users;
using EquipmentItem = EquipmentRental.Models.Equipment.Equipment;

namespace EquipmentRental.Services;

public class RentalService
{
    private AppData data;

    public RentalService(AppData data)
    {
        this.data = data;
    }

    public void AddUser(User user)
    {
        data.Users.Add(user);
    }

    public void AddEquipment(EquipmentItem equipment)
    {
        data.EquipmentList.Add(equipment);
    }

    public int GetUserLimit(User user)
    {
        if (user.UserType == UserType.Student)
        {
            return 2;
        }

        return 5;
    }

    public int GetActiveRentalsCount(User user)
    {
        int count = 0;

        foreach (var rental in data.Rentals)
        {
            if (rental.User.Id == user.Id && rental.ReturnDate == null)
            {
                count++;
            }
        }

        return count;
    }
    public bool RentEquipment(User user, EquipmentItem equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            return false;
        }

        if (GetActiveRentalsCount(user) >= GetUserLimit(user))
        {
            return false;
        }

        DateTime rentDate = DateTime.Now;
        DateTime dueDate = rentDate.AddDays(days);

        Rental rental = new Rental(user, equipment, rentDate, dueDate);

        data.Rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;

        return true;
    }
    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0;
        }

        int lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * 5;
    }
    public bool ReturnEquipment(User user, EquipmentItem equipment)
    {
        foreach (var rental in data.Rentals)
        {
            if (rental.User.Id == user.Id &&
                rental.Equipment.Id == equipment.Id &&
                rental.ReturnDate == null)
            {
                DateTime returnDate = DateTime.Now;

                rental.ReturnDate = returnDate;
                rental.Penalty = CalculatePenalty(rental.DueDate, returnDate);

                equipment.Status = EquipmentStatus.Available;

                return true;
            }
        }

        return false;
    }
    public bool MarkAsUnavailable(EquipmentItem equipment)
    {
        if (equipment.Status == EquipmentStatus.Rented)
        {
            return false;
        }

        equipment.Status = EquipmentStatus.Unavailable;
        return true;
    }
    public List<EquipmentItem> GetAllEquipment()
    {
        return data.EquipmentList;
    }
    public List<EquipmentItem> GetAvailableEquipment()
    {
        List<EquipmentItem> availableEquipment = new List<EquipmentItem>();

        foreach (var equipment in data.EquipmentList)
        {
            if (equipment.Status == EquipmentStatus.Available)
            {
                availableEquipment.Add(equipment);
            }
        }

        return availableEquipment;
    }
    public List<Rental> GetUserActiveRentals(User user)
    {
        List<Rental> userRentals = new List<Rental>();

        foreach (var rental in data.Rentals)
        {
            if (rental.User.Id == user.Id && rental.ReturnDate == null)
            {
                userRentals.Add(rental);
            }
        }

        return userRentals;
    }
    public List<Rental> GetOverdueRentals()
    {
        List<Rental> overdueRentals = new List<Rental>();

        foreach (var rental in data.Rentals)
        {
            if (rental.ReturnDate == null && rental.DueDate < DateTime.Now)
            {
                overdueRentals.Add(rental);
            }
        }

        return overdueRentals;
    }
}