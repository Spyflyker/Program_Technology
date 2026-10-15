public class Cat : Pet
{
    private readonly string _favoriteToy;

    public bool IsIndoor { get; set; }

    public bool IsQuiet => IsIndoor;

    public Cat(string chipId, string name, int age, bool isIndoor)
        : base(chipId, name, age)
    {
        IsIndoor = isIndoor;
        _favoriteToy = "ball";
    }

    public Cat(string name) : base(name)
    {
        _favoriteToy = "ball";
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} plays with a {_favoriteToy}.");
    }

    public override string ToString()
    {
        return $"[Cat] {Name}, age={Age}, kind: {Kind}, indoor: {IsIndoor}";
    }
}
