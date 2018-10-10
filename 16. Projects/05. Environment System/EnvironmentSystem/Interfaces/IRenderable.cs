namespace EnvironmentSystem.Interfaces
{
    using Models.DataStructures;

    public interface IRenderable
    {
        Rectangle Bounds { get; }

        char[,] ImageProfile { get; }
    }
}
