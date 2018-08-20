namespace DungeonsAndCodeWizards.Entities
{
    using Enums;
    using System;
    using Utilities;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateName(value);
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health //Current Health from 0 to BaseHealth
        {
            get => this.health;
            set => this.health = SetValueInRangeFromZeroTo(this.BaseHealth, value);
        }

        public double BaseArmor { get; private set; }

        public double Armor // Current armor from 0 to BaseArmor
        {
            get => this.armor;
            set => this.armor = SetValueInRangeFromZeroTo(this.BaseArmor, value);
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public double RestHealMultiplier { get; protected set; }

        private static double SetValueInRangeFromZeroTo(double baseArmor, double value)
        {
            var result = value;

            if (value < 0)
            {
                result = 0;
            }

            if (value > baseArmor)
            {
                result = baseArmor;
            }

            return result;
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            if (this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health -= hitPoints;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!character.IsAlive || !this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            character.UseItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!character.IsAlive || !this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            var liveStatus = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {liveStatus}";
        }
    }
}