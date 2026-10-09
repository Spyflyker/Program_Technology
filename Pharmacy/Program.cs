namespace Pharmacy;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Выберите источник данных:");
        Console.WriteLine("1 - InMemoryRepository");
        Console.WriteLine("2 - CsvRepository");
        Console.Write("Ваш выбор: ");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Неверный выбор");
            return;
        }

        List<Category> categories;
        List<Pharmacist> pharmacists;
        List<Medicine> medicines;

        switch (choice)
        {
            case 1:
                var inMemoryRepo = new InMemoryRepository();
                categories = inMemoryRepo.GetCategories();
                pharmacists = inMemoryRepo.GetPharmacists();
                medicines = inMemoryRepo.GetMedicines();
                break;
            case 2:
                var csvRepo = new CsvRepository("data");
                categories = csvRepo.GetCategories();
                pharmacists = csvRepo.GetPharmacists();
                medicines = csvRepo.GetMedicines();
                break;
            default:
                Console.WriteLine("Неверный выбор");
                return;
        }

        Console.WriteLine();
        Console.WriteLine("1. FindPharmacist(\"Аспирин\"):");
        var pharmacist = FindPharmacist(medicines, pharmacists, "Аспирин");
        Console.WriteLine(pharmacist?.GetInfo() ?? "—");

        Console.WriteLine();
        Console.WriteLine("2. FindCategory(\"Аспирин\"):");
        var category = FindCategory(medicines, categories, "Аспирин");
        Console.WriteLine(category?.Info ?? "—");

        Console.WriteLine();
        Console.WriteLine("3. GetTotalQuantity:");
        Console.WriteLine($"{GetTotalQuantity(medicines)} упаковок");

        Console.WriteLine();
        Console.WriteLine("4. GetLowStockMedicines(20):");
        var lowStock = GetLowStockMedicines(medicines, 20);
        if (lowStock.Count == 0)
        {
            Console.WriteLine("—");
        }
        else
        {
            foreach (var medicine in lowStock)
            {
                Console.WriteLine($"{medicine.Name} ({medicine.Quantity})");
            }
        }

        Console.WriteLine();
        Console.WriteLine("5. PrintAllMedicines:");
        PrintAllMedicines(medicines, pharmacists, categories);

        Console.WriteLine();
        var notFound = FindPharmacist(medicines, pharmacists, "Неизвестное лекарство");
        Console.WriteLine($"Не найдено: FindPharmacist(\"Неизвестное лекарство\") -> {(notFound == null ? "null" : "найдено")}");
    }

    // Вспомогательные методы

    static Medicine FindMedicineByName(List<Medicine> medicines, string name)
    {
        foreach (var medicine in medicines)
        {
            if (medicine.Name == name)
                return medicine;
        }
        return null;
    }

    static Pharmacist FindPharmacistById(List<Pharmacist> pharmacists, int id)
    {
        foreach (var pharmacist in pharmacists)
        {
            if (pharmacist.Id == id)
                return pharmacist;
        }
        return null;
    }

    static Category FindCategoryById(List<Category> categories, int id)
    {
        foreach (var category in categories)
        {
            if (category.Id == id)
                return category;
        }
        return null;
    }

    static Pharmacist FindPharmacist(List<Medicine> medicines, List<Pharmacist> pharmacists, string medicineName)
    {
        var medicine = FindMedicineByName(medicines, medicineName);
        return medicine == null ? null : FindPharmacistById(pharmacists, medicine.PharmacistId);
    }

    static Category FindCategory(List<Medicine> medicines, List<Category> categories, string medicineName)
    {
        var medicine = FindMedicineByName(medicines, medicineName);
        return medicine == null ? null : FindCategoryById(categories, medicine.CategoryId);
    }

    static int GetTotalQuantity(List<Medicine> medicines)
    {
        int total = 0;
        foreach (var medicine in medicines)
        {
            total += medicine.Quantity;
        }
        return total;
    }

    static List<Medicine> GetLowStockMedicines(List<Medicine> medicines, int threshold)
    {
        var result = new List<Medicine>();
        foreach (var medicine in medicines)
        {
            if (medicine.IsLowStock(threshold))
                result.Add(medicine);
        }
        return result;
    }

    static void PrintAllMedicines(List<Medicine> medicines, List<Pharmacist> pharmacists, List<Category> categories)
    {
        foreach (var medicine in medicines)
        {
            var pharmacist = FindPharmacistById(pharmacists, medicine.PharmacistId);
            var category = FindCategoryById(categories, medicine.CategoryId);

            string pharmacistName = pharmacist?.FullName ?? "—";
            string categoryName = category?.Name ?? "—";

            Console.WriteLine($"\"{medicine.GetInfo()}\" — фармацевт {pharmacistName}, категория \"{categoryName}\"");
        }
    }
}
