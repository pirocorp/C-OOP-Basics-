namespace DungeonsAndCodeWizards.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsFull);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsEmpty);
            }

            var item = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFound, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}