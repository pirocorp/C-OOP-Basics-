namespace DungeonsAndCodeWizards.Entities.Characters
{
    using Bags;
    using Enums;
    using Interfaces;
    using System;
    using Utilities;

    public class Cleric : Character, IHealable
    {
        private const double DEFAULT_BASE_HEALTH = 50;
        private const double DEFAULT_BASE_ARMOR = 25;
        private const double DEFAULT_ABILITY_POINTS = 40;

        public Cleric(string name, Faction faction)
            : base(name, DEFAULT_BASE_HEALTH, DEFAULT_BASE_ARMOR, DEFAULT_ABILITY_POINTS, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidHealTarget);
            }

            character.Health += this.AbilityPoints;
        }
    }
}