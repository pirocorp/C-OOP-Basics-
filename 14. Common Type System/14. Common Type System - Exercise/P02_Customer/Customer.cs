namespace P02_Customer
{
    using System;
    using System.Collections.Generic;

    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType customerType;

        public Customer(string firstName, string middleName, string lastName, string id, string permanentAddress, string mobilePhone, string email, CustomerType customerType)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.id = id;
            this.permanentAddress = permanentAddress;
            this.mobilePhone = mobilePhone;
            this.email = email;
            this.customerType = customerType;
            this.payments = new List<Payment>();
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                Validator.EmptyString(nameof(this.FirstName), value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get => this.middleName;
            private set
            {
                Validator.EmptyString(nameof(this.MiddleName), value);
                this.middleName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                Validator.EmptyString(nameof(this.LastName), value);
                this.lastName = value;
            }
        }

        public string ID
        {
            get => this.id;
            private set
            {
                Validator.EmptyString(nameof(this.ID), value);
                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get => this.permanentAddress;
            private set
            {
                Validator.EmptyString(nameof(this.PermanentAddress), value);
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get => this.mobilePhone;
            private set
            {
                Validator.EmptyString(nameof(this.MobilePhone), value);
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get => this.email;
            private set
            {
                Validator.EmptyString(nameof(this.Email), value);
                this.email = value;
            }
        }

        public IReadOnlyCollection<Payment> Payments => this.payments;

        public CustomerType CustomerType
        {
            get => this.customerType;
            private set => this.customerType = value;
        }

        public void addPayment(Payment payment)
        {
            this.payments.Add(payment);
        }

        public int CompareTo(Customer other)
        {
            var thisFullName = $"{this.FirstName} {this.MiddleName} {this.LastName}";
            var otherFullName = $"{other.FirstName} {other.MiddleName} {other.LastName}";

            var fullNameComparator = string.Compare(thisFullName, otherFullName, StringComparison.Ordinal);
            var idComparator = string.CompareOrdinal(this.ID, other.ID);

            if (fullNameComparator != 0)
            {
                return fullNameComparator;
            }

            return idComparator;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Customer;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.ID == other.ID)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            if (ReferenceEquals(firstCustomer, null) || ReferenceEquals(secondCustomer, null))
            {
                return false;
            }

            return firstCustomer.Equals(secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            if (ReferenceEquals(firstCustomer, null) || ReferenceEquals(secondCustomer, null))
            {
                return true;
            }

            return !(firstCustomer == secondCustomer);
        }

        public override string ToString()
        {
            var payments = $"{string.Join(Environment.NewLine, this.Payments)}";
            payments = string.IsNullOrWhiteSpace(payments) ? string.Empty : payments + Environment.NewLine;

            return $"Name: {this.FirstName} {this.MiddleName} {this.LastName}, ID: {this.ID}" + Environment.NewLine +
                   $"Customer Type: {this.CustomerType}, Adress: {this.PermanentAddress}" + Environment.NewLine + 
                   $"Phone: {this.MobilePhone}, Email: {this.Email}" + Environment.NewLine +
                   $"Payments:" + Environment.NewLine + payments;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Customer Clone()
        {
            var clone = new Customer(this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress, this.MobilePhone, this.Email, this.CustomerType);

            foreach (var payment in this.payments)
            {
                clone.addPayment(payment.Clone());
            }

            return clone;
        }
    }
}