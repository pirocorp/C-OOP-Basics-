namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

            if (hitObject == CollisionGroup.Ground)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}