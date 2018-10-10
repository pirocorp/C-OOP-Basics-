namespace EnvironmentSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.Objects;

    public class ExtendedEngine : Engine
    {
        public ExtendedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer) 
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(this.Insert), "Object cannot be null.");
            }

            base.Insert(obj);
        }
    }
}