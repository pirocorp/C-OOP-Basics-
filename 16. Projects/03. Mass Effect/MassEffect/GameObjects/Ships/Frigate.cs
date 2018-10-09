namespace MassEffect.GameObjects.Ships
{
    using System;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        //health 60, shields 50, damage 30 and fuel 220

        private const int HEALTH = 60;
        private const int SHIELDS = 50;
        private const int DAMADGE = 30;
        private const int FUEL = 220;

        private int projectilesFired = 0;

        public Frigate(string name, StarSystem location) 
            : base(name, HEALTH, SHIELDS, DAMADGE, FUEL, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            var frigateAsString = base.ToString() + Environment.NewLine;
            frigateAsString += $"-Projectiles fired: {this.projectilesFired}";
            return frigateAsString;
        }
    }
}