public abstract class Unit
{
    private string id;

    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }

    public abstract string Check();
}