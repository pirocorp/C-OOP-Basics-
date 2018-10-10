namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataStructures;

    public class Tail : EnvironmentObject
    {
        private const char TAIL_CHARACTER = '*';

        private int lifetime;

        public Tail(int x, int y, int lifetime = 1) 
            : base(x, y, 1, 1)
        {
            this.lifetime = lifetime;
            this.ImageProfile = new char[,] {{ TAIL_CHARACTER }};
        }

        public Tail(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            this.lifetime--;

            if (this.lifetime <= 0)
            {
                this.Exists = false;
            }
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