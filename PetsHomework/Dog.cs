public class Dog : Pet, ITrainable
{
    private readonly string _favoriteCommand;

    public string Breed { get; set; }


    public bool IsLarge => Breed == "Labrador" || Breed == "Husky" || Breed == "German Shepherd";

    public Dog(string chipId, string name, int age, string breed)
        : base(chipId, name, age)
    {
        Breed = breed;
        _favoriteCommand = "sit";
    }

    public Dog(string name) : base(name)
    {
        Breed = "Unknown";
        _favoriteCommand = "sit";
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} plays fetch.");
    }


    public void Train()
    {
        Console.WriteLine($"{Name} trained to {_favoriteCommand}.");
    }

    public override string ToString()
    {
        return $"[Dog] {Name}, age={Age}, kind: {Kind}, breed: {Breed}";
    }
}
