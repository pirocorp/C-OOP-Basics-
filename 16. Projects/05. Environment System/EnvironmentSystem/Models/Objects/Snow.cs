namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataStructures;

    public class Snow : EnvironmentObject
    {
        private const char SNOW_IMAGE_CHARACTER = '.';
        
        public Snow(int x, int y) 
            : base(x, y, 1, 1)
        {
            this.ImageProfile = new char[,] { { SNOW_IMAGE_CHARACTER } };
            this.CollisionGroup = CollisionGroup.Snowflake;
        }

        public Snow(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}