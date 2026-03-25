using EquipmentRental.Models;
using EquipmentRental.Models.Users;
using EquipmentItem = EquipmentRental.Models.Equipment.Equipment;

namespace EquipmentRental.Data;

public class AppData
{
    public List<User> Users { get; set; }
    public List<EquipmentItem> EquipmentList { get; set; }
    public List<Rental> Rentals { get; set; }

    public AppData()
    {
        Users = new List<User>();
        EquipmentList = new List<EquipmentItem>();
        Rentals = new List<Rental>();
    }
}