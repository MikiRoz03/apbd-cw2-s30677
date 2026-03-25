using EquipmentRental.Enums;

namespace EquipmentRental.Models.Equipment;

public abstract class Equipment
{
    private static int nextId = 1;

    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }

    public Equipment(string name)
    {
        Id = nextId;
        nextId++;

        Name = name;
        Status = EquipmentStatus.Available;
    }
}