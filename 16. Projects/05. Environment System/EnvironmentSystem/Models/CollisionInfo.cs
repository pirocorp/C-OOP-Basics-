namespace EnvironmentSystem.Models
{
    using Interfaces;

    public class CollisionInfo
    {
        public CollisionInfo(ICollidable hitObject)
        {
            this.HitObject = hitObject;
        }

        public ICollidable HitObject { get; private set; }
    }
}