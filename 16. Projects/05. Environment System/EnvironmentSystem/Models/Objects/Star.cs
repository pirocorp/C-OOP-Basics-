namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using DataStructures;

    public class Star : EnvironmentObject
    {
        private const char STAR_CHARACTER = 'O';
        private const int STAR_IMAGE_REFRESHER = 10;

        private static readonly Random RandomGenerator = new Random();
        private static readonly char[] StarImageProfiles = {'O', '@', '0'};
        private int updateCount = 0;

        public Star(int x, int y) 
            : base(x, y, 1, 1)
        {
            this.ImageProfile = new char[,] {{ GetRandomChar() } };
        }

        public Star(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            if (this.updateCount == STAR_IMAGE_REFRESHER)
            {
                this.ImageProfile = new char[,] {{ GetRandomChar() } };
                this.updateCount = 0;
            }

            this.updateCount++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject.CollisionGroup;

            if (hitObject == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }

        private static char GetRandomChar()
        {
            var index = RandomGenerator.Next(0, StarImageProfiles.Length);
            return StarImageProfiles[index];
        }
    }
}