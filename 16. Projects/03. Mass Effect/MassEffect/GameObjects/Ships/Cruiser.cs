namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Cruiser : Starship
    {
        private const int HEALTH = 100;
        private const int SHIELDS = 100;
        private const int DAMADGE = 50;
        private const int FUEL = 300;

        public Cruiser(string name, StarSystem location) 
            : base(name, HEALTH, SHIELDS, DAMADGE, FUEL, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}