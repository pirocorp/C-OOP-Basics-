namespace DungeonsAndCodeWizards.Utilities
{
    public static class ExceptionMessages
    {
        public const string InvalidName = "Name cannot be null or whitespace!";

        public const string CharacterIsDead = "Must be alive to perform this action!";

        public const string BagIsFull = "Bag is full!";

        public const string BagIsEmpty = "Bag is empty!";

        public const string ItemNotFound = "No item with name {0} in bag!";

        public const string InvalidAttackTarget = "Cannot attack self!";

        public const string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";

        public const string InvalidHealTarget = "Cannot heal enemy character!";

        public const string InvalidFaction = "Invalid faction \"{0}\"!";

        public const string InvalidCharacterType = "Invalid character type \"{0}\"!";

        public const string InvalidItem = "Invalid item \"{0}\"!";

        public const string CharacterNotFound = "Character {0} not found!";

        public const string PoolIsEmpty = "No items left in pool!";

        public const string InvalidBagType = "Invalid bag type \"{0}\"!";
    }
}