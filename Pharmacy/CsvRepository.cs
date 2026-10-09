namespace Pharmacy;

internal class CsvRepository
{
    private string _basePath;

    public CsvRepository(string basePath)
    {
        _basePath = basePath;
    }

    public List<Category> GetCategories()
    {
        var result = new List<Category>();
        string path = Path.Combine(_basePath, "categories.csv ");
        string[] lines = File.ReadAllLines(path);

        if (lines.Length < 2)
            return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 3)
                continue;

            var category = new Category
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Description = parts[2]
            };
            result.Add(category);
        }

        return result;
    }

    public List<Pharmacist> GetPharmacists()
    {
        var result = new List<Pharmacist>();
        string path = Path.Combine(_basePath, "pharmacists.csv");
        string[] lines = File.ReadAllLines(path);

        if (lines.Length < 2)
            return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 4)
                continue;

            var pharmacist = new Pharmacist
            {
                Id = int.Parse(parts[0]),
                FullName = parts[1],
                Shift = parts[2],
                Experience = int.Parse(parts[3])
            };
            result.Add(pharmacist);
        }

        return result;
    }

    public List<Medicine> GetMedicines()
    {
        var result = new List<Medicine>();
        string path = Path.Combine(_basePath, "medicines.csv");
        string[] lines = File.ReadAllLines(path);

        if (lines.Length < 2)
            return result;

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] parts = lines[i].Split(',');
            if (parts.Length < 6)
                continue;

            var medicine = new Medicine
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                CategoryId = int.Parse(parts[2]),
                PharmacistId = int.Parse(parts[3]),
                Price = decimal.Parse(parts[4]),
                Quantity = int.Parse(parts[5])
            };
            result.Add(medicine);
        }

        return result;
    }
}
