namespace Pharmacy;

internal class InMemoryRepository
{
    private List<Category> _categories = new List<Category>
    {
        new Category { Id = 1, Name = "Обезболивающие",       Description = "от боли" },
        new Category { Id = 2, Name = "Антибиотики",          Description = "от инфекций" },
        new Category { Id = 3, Name = "Витамины",             Description = "для профилактики" },
        new Category { Id = 4, Name = "Сердечно-сосудистые",  Description = "для сердца и сосудов" },
        new Category { Id = 5, Name = "Противовирусные",      Description = "от вирусов" }
    };

    private List<Pharmacist> _pharmacists = new List<Pharmacist>
    {
        new Pharmacist { Id = 1, FullName = "Иванова А.А.",   Shift = "Утро",  Experience = 5 },
        new Pharmacist { Id = 2, FullName = "Петров И.И.",    Shift = "Вечер", Experience = 2 },
        new Pharmacist { Id = 3, FullName = "Сидорова М.В.",  Shift = "Утро",  Experience = 8 },
        new Pharmacist { Id = 4, FullName = "Кузнецов Д.С.",  Shift = "Ночь",  Experience = 1 },
        new Pharmacist { Id = 5, FullName = "Смирнова О.П.",  Shift = "Вечер", Experience = 4 }
    };

    private List<Medicine> _medicines = new List<Medicine>
    {
        new Medicine { Id = 1, Name = "Аспирин",       CategoryId = 1, PharmacistId = 1, Price = 50m,  Quantity = 100 },
        new Medicine { Id = 2, Name = "Анальгин",      CategoryId = 1, PharmacistId = 1, Price = 30m,  Quantity = 15  },
        new Medicine { Id = 3, Name = "Амоксициллин",  CategoryId = 2, PharmacistId = 2, Price = 150m, Quantity = 40  },
        new Medicine { Id = 4, Name = "Витамин C",     CategoryId = 3, PharmacistId = 3, Price = 90m,  Quantity = 200 },
        new Medicine { Id = 5, Name = "Кардиомагнил",  CategoryId = 4, PharmacistId = 5, Price = 220m, Quantity = 10  },
        new Medicine { Id = 6, Name = "Арбидол",       CategoryId = 5, PharmacistId = 4, Price = 350m, Quantity = 5   }
    };

    public List<Category> GetCategories() => _categories;

    public List<Pharmacist> GetPharmacists() => _pharmacists;

    public List<Medicine> GetMedicines() => _medicines;
}
