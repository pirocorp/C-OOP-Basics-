public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract int GetAffinity { get; }

    public override string ToString()
    {
        return $"Monument: {this.Name}";
    }
}