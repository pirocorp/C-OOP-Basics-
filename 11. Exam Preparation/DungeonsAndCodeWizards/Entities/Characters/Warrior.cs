namespace DungeonsAndCodeWizards.Entities.Characters
{
    using Bags;
    using Enums;
    using Interfaces;
    using System;
    using Utilities;

    public class Warrior : Character, IAttackable
    {
        private const double DEFAULT_BASE_HEALTH = 100;
        private const double DEFAULT_BASE_ARMOR = 50;
        private const double DEFAULT_ABILITY_POINTS = 40;

        public Warrior(string name, Faction faction)
            : base(name, DEFAULT_BASE_HEALTH, DEFAULT_BASE_ARMOR, DEFAULT_ABILITY_POINTS, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            if (character == this)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAttackTarget);
            }

            if (character.Faction == this.Faction)
            {
                var fraction = this.Faction.ToString();
                throw new ArgumentException(string.Format(ExceptionMessages.FriendlyFire, fraction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}