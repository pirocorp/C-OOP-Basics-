namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int DEFAULTH_WEIGHT = 5;
        private const int HIT_POINTS_RESTORED = 20;

        public HealthPotion()
            : base(DEFAULTH_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HIT_POINTS_RESTORED;
        }
    }
}