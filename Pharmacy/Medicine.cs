namespace Pharmacy;

internal class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int PharmacistId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal TotalValue => Price * Quantity;

    public bool IsLowStock(int threshold) => Quantity < threshold;

    public string GetInfo() => $"{Name} ({Price} руб., {Quantity} уп.)";
}
