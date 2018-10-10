namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class UnstableStar : FallingStar
    {
        private int lifetime;

        public UnstableStar(int x, int y, Point direction, int lifetime = 8) 
            : base(x, y, direction)
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            this.lifetime--;

            if (this.lifetime <= 0)
            {
                this.Exists = false;
            }

            base.Update();
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists)
            {
                return base.ProduceObjects();
            }
            else
            {
                var explosions = new List<EnvironmentObject>();

                for (var y = this.Bounds.TopLeft.Y - 2; y <= this.Bounds.TopLeft.Y + 2; y++)
                {
                    for (var x = this.Bounds.TopLeft.X - 2; x <= this.Bounds.TopLeft.X + 2; x++)
                    {
                        if (x != this.Bounds.TopLeft.X || y != this.Bounds.TopLeft.Y)
                        {
                            var currentExplosion = new Explosion(x, y);
                            explosions.Add(currentExplosion);
                        }
                    }
                }

                return explosions;
            }
        }
    }
}