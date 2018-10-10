namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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