namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int DEFAULTH_WEIGHT = 5;
        private const int DAMADGE_DELTH = 20;

        public PoisonPotion()
            : base(DEFAULTH_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= DAMADGE_DELTH;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}