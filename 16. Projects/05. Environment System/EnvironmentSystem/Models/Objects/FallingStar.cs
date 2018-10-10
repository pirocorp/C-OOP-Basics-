namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class FallingStar : MovingObject
    {
        private const char FALLING_STAR_IMAGE_CHARACTER = 'O';

        public FallingStar(int x, int y, Point direction) 
            : base(x, y, 1, 1, direction)
        {
            this.ImageProfile = new char[,] {{ FALLING_STAR_IMAGE_CHARACTER } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject.CollisionGroup;

            if (hitObject == CollisionGroup.Ground || hitObject == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            var producedObjects = new List<EnvironmentObject>
            {
                new Tail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - this.Direction.Y),
                new Tail(this.Bounds.TopLeft.X - 2 * this.Direction.X, this.Bounds.TopLeft.Y - 2 * this.Direction.Y),
                new Tail(this.Bounds.TopLeft.X - 3 * this.Direction.X, this.Bounds.TopLeft.Y - 3 * this.Direction.Y)
            };


            return producedObjects;
        }
    }
}