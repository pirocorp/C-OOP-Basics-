namespace DungeonsAndCodeWizards.Factories
{
    using Entities;
    using Entities.Items;
    using System;
    using Utilities;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Item newItem = null;

            switch (itemName)
            {
                case "ArmorRepairKit":
                    newItem = new ArmorRepairKit();
                    break;

                case "HealthPotion":
                    newItem = new HealthPotion();
                    break;

                case "PoisonPotion":
                    newItem = new PoisonPotion();
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            return newItem;
        }
    }
}