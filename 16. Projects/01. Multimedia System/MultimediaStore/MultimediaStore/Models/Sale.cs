namespace MultimediaStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Items;
    using Validators;

    public class Sale : ISale
    {
        private IItem item;
        private readonly DateTime saleDate;

        public Sale(IItem item)
            : this(item, DateTime.Now)
        {
            
        }

        public Sale(IItem item, DateTime saleDate)
        {
            this.item = item;
            this.saleDate = saleDate;
        }

        public IItem Item
        {
            get => this.item;
            private set
            {
                Validator.ValidateObjectExist(nameof(this.Item), value);
                this.item = value;
            }
        }

        public DateTime SaleDate => this.saleDate;
    }
}