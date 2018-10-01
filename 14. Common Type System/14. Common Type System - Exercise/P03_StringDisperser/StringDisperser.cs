namespace P03_StringDisperser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        private List<char> characters;

        public StringDisperser(params string[] inputStrings)
        {
            this.characters = new List<char>();

            foreach (var str in inputStrings)
            {
                this.characters.AddRange(str.ToCharArray());
            }
        }

        public IReadOnlyCollection<char> Characters => this.characters;

        public int CompareTo(StringDisperser other)
        {
            var stringComparator = string.CompareOrdinal(this.ToString(), other.ToString());
            return stringComparator;
        }

        public override bool Equals(object obj)
        {
            var other = obj as StringDisperser;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (string.Equals(this.ToString(), other.ToString()))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return new string(this.characters.ToArray());
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < this.Characters.Count; i++)
            {
                yield return this.characters[i];
            }
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public StringDisperser Clone()
        {
            var clone = new StringDisperser(this.ToString());
            return clone;
        }

        public static bool operator ==(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            if (ReferenceEquals(firstDisperser, null) || ReferenceEquals(secondDisperser, null))
            {
                return false;
            }

            return firstDisperser.Equals(secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            if (ReferenceEquals(firstDisperser, null) || ReferenceEquals(secondDisperser, null))
            {
                return true;
            }

            return !firstDisperser.Equals(secondDisperser);
        }
    }
}