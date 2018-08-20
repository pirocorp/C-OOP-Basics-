namespace DungeonsAndCodeWizards.Factories
{
    using Entities;
    using Entities.Bags;
    using System;
    using Utilities;

    public class BagFactory
    {
        public Bag CreateBag(string typeOfBag)
        {
            Bag newBag = null;

            switch (typeOfBag)
            {
                case "Backpack":
                    newBag = new Backpack();
                    break;

                case "Satchel":
                    newBag = new Satchel();
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBagType, typeOfBag));
            }

            return newBag;
        }
    }
}