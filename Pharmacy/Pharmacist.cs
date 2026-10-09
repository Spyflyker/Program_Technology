namespace Pharmacy;

internal class Pharmacist
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Shift { get; set; }
    public int Experience { get; set; }

    public bool IsExperienced => Experience > 3;

    public string GetInfo() => $"{FullName} ({Experience} лет опыта)";
}
