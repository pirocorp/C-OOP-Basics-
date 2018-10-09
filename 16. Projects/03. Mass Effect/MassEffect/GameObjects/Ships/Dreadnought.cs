namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Dreadnought : Starship
    {
        //health 200, shields 300, damage 150 and fuel 70
        private const int HEALTH = 200;
        private const int SHIELDS = 300;
        private const int DAMADGE = 150;
        private const int FUEL = 700;

        public Dreadnought(string name, StarSystem location) 
            : base(name, HEALTH, SHIELDS, DAMADGE, FUEL, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var damage = this.Damage + this.Shields / 2;
            return new Laser(damage);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;

            base.RespondToAttack(projectile);

            this.Shields -= 50;
        }
    }
}