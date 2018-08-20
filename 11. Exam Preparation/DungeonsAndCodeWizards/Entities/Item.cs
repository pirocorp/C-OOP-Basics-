namespace DungeonsAndCodeWizards.Entities
{
    using System;
    using Utilities;

    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterIsDead);
            }
        }
    }
}