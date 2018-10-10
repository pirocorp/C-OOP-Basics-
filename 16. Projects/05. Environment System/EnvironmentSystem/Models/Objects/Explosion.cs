namespace EnvironmentSystem.Models.Objects
{
    using DataStructures;

    public class Explosion : Tail
    {
        public Explosion(int x, int y, int lifetime = 2) 
            : base(x, y, lifetime)
        {
            this.CollisionGroup = CollisionGroup.Explosion;
        }

        public Explosion(Rectangle bounds) 
            : base(bounds)
        {
        }
    }
}