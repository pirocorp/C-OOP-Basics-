namespace StorageMaster.Factories
{
    using System;
    using Entities;
    using Entities.Storages;
    using Utilities;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage newStorage = null;

            switch (type)
            {
                case "AutomatedWarehouse":
                    newStorage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    newStorage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    newStorage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidStorageType);
            }

            return newStorage;
        }
    }
}