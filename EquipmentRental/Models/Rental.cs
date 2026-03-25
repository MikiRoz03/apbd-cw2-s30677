using EquipmentItem = EquipmentRental.Models.Equipment.Equipment;
using EquipmentRental.Models.Users;

namespace EquipmentRental.Models;

public class Rental
{
    public User User { get; set; }
    public EquipmentItem Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public Rental(User user, EquipmentItem equipment, DateTime rentDate, DateTime dueDate)
    {
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        DueDate = dueDate;
        ReturnDate = null;
        Penalty = 0;
    }
}


