public abstract class Pet
{
    private readonly string _chipId;

    public string Name { get; set; }
    public int Age { get; set; }
    public PetKind Kind { get; set; } = PetKind.Cat;


    public bool IsAdult => Age > 1;

    public Pet(string chipId, string name, int age)
    {
        _chipId = chipId;
        Name = name;
        Age = age;
    }

    public Pet(string name) : this("N/A", name, 0)
    {
    }


    public string GetChipId()
    {
        return _chipId;
    }

    public abstract void Play();
}
