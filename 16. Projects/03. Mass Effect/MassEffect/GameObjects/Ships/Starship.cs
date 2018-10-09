namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using Enhancements;
    using Interfaces;
    using Locations;

    public abstract class Starship : IStarship
    {
        private readonly IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public IEnumerable<Enhancement> Enhancements => this.enhancements;

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException(nameof(enhancement), "Enhancement cannot be null.");
            }

            this.enhancements.Add(enhancement);
            this.ApplyEnhancementEffects(enhancement);
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        public override string ToString()
        {
            var shipAsString = string.Empty;
            shipAsString += $"--{this.Name} - {this.GetType().Name}" + Environment.NewLine;

            if (this.Health <= 0)
            {
                shipAsString += "(Destroyed)";
            }
            else
            {
                var enhancementsAsString = this.enhancements.Count > 0 ? string.Join(", ", this.Enhancements) : "N/A";

                shipAsString += $"-Location: {this.Location.Name}" + Environment.NewLine +
                                $"-Health: {this.Health}" + Environment.NewLine +
                                $"-Shields: {this.Shields}" + Environment.NewLine +
                                $"-Damage: {this.Damage}" + Environment.NewLine +
                                $"-Fuel: {this.Fuel:F1}" + Environment.NewLine +
                                $"-Enhancements: {enhancementsAsString}";
            }

            return shipAsString;
        }

        private void ApplyEnhancementEffects(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Damage += enhancement.DamageBonus;
        }
    }
}