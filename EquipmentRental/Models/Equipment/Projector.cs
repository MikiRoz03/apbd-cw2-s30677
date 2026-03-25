namespace EquipmentRental.Models.Equipment;

public class Projector : Equipment
{
    public int BrightnessLumens { get; set; }
    public string Resolution { get; set; }

    public Projector(string name, int brightnessLumens, string resolution) : base(name)
    {
        BrightnessLumens = brightnessLumens;
        Resolution = resolution;
    }
}