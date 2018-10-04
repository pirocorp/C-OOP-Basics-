namespace MultimediaStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Validators;

    public class Rent : IRent
    {
        private IItem item;
        private  DateTime returnDate;
        private  DateTime rentDate;
        private  DateTime deadline;

        public IItem Item
        {
            get => this.item;
            private set
            {
                Validator.ValidateObjectExist(nameof(this.Item), value);
                this.item = value;
            }
        }

        public DateTime ReturnDate
        {
            get => this.returnDate;
            private set => this.returnDate = value;
        }

        public DateTime RentDate
        {
            get => this.rentDate;
            private set => this.rentDate = value;
        }

        public DateTime Deadline
        {
            get => this.deadline;
            private set => this.deadline = value;
        }

        public RentState RentState => throw new NotImplementedException();

        public decimal RentFine => throw new NotImplementedException();

        public void ReturnItem()
        {
            throw new NotImplementedException();
        }
    }
}