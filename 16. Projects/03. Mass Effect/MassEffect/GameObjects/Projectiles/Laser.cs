namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            var remainder = this.Damage - ship.Shields;
            ship.Shields -= this.Damage;

            if (remainder > 0)
            {
                ship.Health -= remainder;
            }
        }
    }
}