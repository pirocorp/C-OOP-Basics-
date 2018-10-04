namespace MultimediaStore.Models
{
    using System;
    using Interfaces;
    using Validators;

    public class Rent : IRent
    {
        private const int DEFAULT_RENT_PERIOD_IN_DAYS = 30;

        private IItem item;
        private  DateTime returnDate;
        private  DateTime rentDate;
        private  DateTime deadline;

        public Rent(IItem item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
        }

        public Rent(IItem item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(DEFAULT_RENT_PERIOD_IN_DAYS))
        {
        }

        public Rent(IItem item)
            : this(item, DateTime.Now, DateTime.Now.AddDays(DEFAULT_RENT_PERIOD_IN_DAYS))
        {
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

        public RentState RentState
        {
            get
            {
                var now = DateTime.Now;

                if (this.IsSetDate(this.ReturnDate))
                {
                    return RentState.Returned;
                }
                else if (now > this.Deadline)
                {
                    return RentState.Overdue;
                }
                else
                {
                    return RentState.Pending;
                }
            }
        }

        public decimal RentFine
        {
            get
            {
                var date = this.IsSetDate(this.ReturnDate) ? this.ReturnDate : DateTime.Now;
                var fine = (date - this.Deadline).Days * this.Item.Price * 0.01m;

                return Math.Max(fine, 0);
            }
        }

        public void ReturnItem()
        {
            this.returnDate = DateTime.Now;
        }

        private bool IsSetDate(DateTime dateTime)
        {
            return dateTime.Year > 1;
        }

        public override string ToString()
        {
            return $"{this.item} Rented At: {this.rentDate} Status: {this.RentState}";
        }
    }
}