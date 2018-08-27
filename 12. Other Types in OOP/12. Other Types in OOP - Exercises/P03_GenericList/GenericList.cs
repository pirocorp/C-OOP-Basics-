namespace P03_GenericList
{
    using System;
    using System.Linq;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int DEFAULTH_CAPAITY = 8;
        private T[] elements;
        private int currentIndex;

        public GenericList(int initialCapacity = DEFAULTH_CAPAITY)
        {
            this.elements = new T[initialCapacity];
            this.currentIndex = 0;
        }

        public void Add(T element)
        {
            if (this.currentIndex >= this.elements.Length)
            {
                this.ResizeList();
            }

            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        public int IndexOf(T element)
        {
            var result = -1;

            for (var i = 0; i < this.currentIndex; i++)
            {
                var currentElement = this.elements[i];

                if (currentElement.Equals(element))
                {
                    result = i;
                    return result;
                }
            }

            return result;
        }

        public bool Contains(T element)
        {
            var result = this.IndexOf(element);
            return result > -1;
        }

        public void Remove(T element)
        {
            var index = this.IndexOf(element);

            if (index == -1)
            {
                throw new ArgumentException("Specified element was not found.");
            }

            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            this.CheckIndex(index);

            for (var i = index; i < this.currentIndex - 1; i++)
            {
                var nextElement = this.elements[i + 1];

                this.elements[i] = nextElement;
            }

            this.currentIndex--;
            this.elements[this.currentIndex] = default(T);
        }

        public void InsertAt(T element, int index)
        {
            this.CheckIndex(index);

            var previousElement = this.elements[index];
            this.elements[index] = element;

            if (this.currentIndex >= this.elements.Length)
            {
                this.ResizeList();
            }

            for (var i = index + 1; i <= this.currentIndex; i++)
            {
                var currentElement = this.elements[i];
                this.elements[i] = previousElement;
                previousElement = currentElement;
            }

            this.currentIndex++;
        }

        public T Max()
        {
            this.CheckIsEmpty();

            T maxElement = this.elements[0];

            for (var i = 1; i < this.currentIndex; i++)
            {
                if (maxElement.CompareTo(this.elements[i]) < 0)
                {
                    maxElement = this.elements[i];
                }
            }

            return maxElement;
        }

        public T Min()
        {
            this.CheckIsEmpty();

            T minElement = this.elements[0];

            for (var i = 1; i < this.currentIndex; i++)
            {
                if (minElement.CompareTo(this.elements[i]) > 0)
                {
                    minElement = this.elements[i];
                }
            }

            return minElement;
        }

        public T this[int i]
        {
            get
            {
                this.CheckIndex(i);

                return this.elements[i];
            }
            set
            {
                this.CheckIndex(i);

                this.elements[i] = value;
            }
        }

        public void Clear()
        {
            var length = this.elements.Length;
            this.elements = new T[length];
        }

        public override string ToString()
        {
            return $"{string.Join(", ", this.elements.Take(this.currentIndex))}";
        }

        private void ResizeList()
        {
            var newElements = new T[this.elements.Length * 2];

            for (var i = 0; i < this.elements.Length; i++)
            {
                var currentElement = this.elements[i];

                newElements[i] = currentElement;
            }

            this.elements = newElements;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.currentIndex)
            {
                throw new IndexOutOfRangeException("Index was outside the boundaries of the CustomList");
            }
        }

        private void CheckIsEmpty()
        {
            if (this.currentIndex == 0)
            {
                throw new ArgumentException("The list is empty");
            }
        }
    }
}