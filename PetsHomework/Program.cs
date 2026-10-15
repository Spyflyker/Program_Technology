List<Pet> pets = new List<Pet>
{
    new Cat("CH-001", "Barsik", 3, true),
    new Dog("CH-002", "Rex", 2, "Labrador"),
    new Bird("CH-003", "Kesha", 1, true)
};

foreach (Pet pet in pets)
{
    Console.WriteLine(pet);
    Console.WriteLine($"  adult: {pet.IsAdult}");
    pet.Play();

    if (pet is ITrainable trainable)
    {
        trainable.Train();
    }
    else
    {
        Console.WriteLine($"{pet.Name} cannot be trained.");
    }

    Console.WriteLine(new string('-', 40));
}
