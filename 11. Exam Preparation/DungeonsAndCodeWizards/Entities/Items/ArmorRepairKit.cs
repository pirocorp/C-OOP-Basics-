namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
        private const int DEFAULTH_WEIGHT = 5;

        public ArmorRepairKit()
            : base(DEFAULTH_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}