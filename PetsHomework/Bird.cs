public class Bird : Pet, ITrainable
{
    private readonly string _favoriteWord;

    public bool CanSpeak { get; set; }


    public bool IsTalkative => CanSpeak;

    public Bird(string chipId, string name, int age, bool canSpeak)
        : base(chipId, name, age)
    {
        CanSpeak = canSpeak;
        _favoriteWord = "hello";
    }

    public Bird(string name) : base(name)
    {
        _favoriteWord = "hello";
    }


    public override void Play()
    {
        Console.WriteLine($"{Name} sings a song.");
    }


    public void Train()
    {
        Console.WriteLine($"{Name} trained to say \"{_favoriteWord}\".");
    }

    public override string ToString()
    {
        return $"[Bird] {Name}, age={Age}, kind: {Kind}, can speak: {CanSpeak}";
    }
}
