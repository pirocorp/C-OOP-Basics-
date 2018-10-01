namespace P01_Country
{
    using System;
    using System.Collections.Generic;

    public class Country : IComparable<Country>, ICloneable
    {
        private string name;
        private ulong population;
        private double area;
        private HashSet<string> cities;

        public Country(string name, ulong population, double area, params string[] inputCities)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.cities = new HashSet<string>(inputCities);
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Country name cannot be empty!");
                }

                this.name = value;
            }
        }

        public ulong Population
        {
            get => this.population;
            private set => this.population = value;
        }

        public double Area
        {
            get => this.area;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Country area cannot be negative number!");
                }

                this.area = value;
            }
        }

        public IReadOnlyCollection<string> Cities => this.cities;

        public void AddCity(string city)
        {
            this.cities.Add(city);
        }

        public int CompareTo(Country other)
        {
            var areaComparator = SignOfNumber(this.Area - other.Area);
            var populationComparator = SignOfNumber(this.Population - other.Population);
            var nameComparator = this.Name.CompareTo(other.Name);

            if (areaComparator != 0)
            {
                return -1 * areaComparator;
            }

            if (populationComparator != 0)
            {
                return -1 * populationComparator;
            }

            return nameComparator;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Country Clone()
        {
            var clone = new Country(this.Name, this.Population, this.Area);

            foreach (var city in this.Cities)
            {
                clone.cities.Add(city);
            }

            return clone;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Country;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (string.Equals(this.Name.ToLower(), other.Name.ToLower()))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Country firstCountry, Country secondCountry)
        {
            if (ReferenceEquals(firstCountry, null) || ReferenceEquals(secondCountry, null))
            {
                return false;
            }

            return firstCountry.Equals(secondCountry);
        }

        public static bool operator !=(Country firstCountry, Country secondCountry)
        {
            if (ReferenceEquals(firstCountry, null) || ReferenceEquals(secondCountry, null))
            {
                return true;
            }

            return !firstCountry.Equals(secondCountry);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Population: {this.Population}, Area: {this.Area}, Cities: [{string.Join(", ", this.Cities)}]";
        }

        private static int SignOfNumber (double number)
        {
            if (number > 0)
            {
                return 1;
            }

            if (number < 0)
            {
                return -1;
            }

            return 0;
        }

        private static int SignOfNumber(ulong number)
        {
            if (number > 0)
            {
                return 1;
            }

            if (number < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}