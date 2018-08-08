namespace P06_BitArray
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    
    public class BitArray
    {
        private const int MaxBitsCount = 100000;
        private const int MinBitsCount = 1;

        private byte[] bitArray;

        public BitArray(int size)
        {
            if (size >= MinBitsCount && size <= MaxBitsCount)
            {
                this.bitArray = new byte[size];
            }
            else
            {
                throw new ArgumentException($"Size of BitArray must be between 1 and 100000"); 
            }
        }

        public int this[int index]
        {
            get
            {
                if (0 <= index && index < this.bitArray.Length)
                {
                    return this.bitArray[index];
                }

                throw new IndexOutOfRangeException($"Index {index} is invalid!");
            }
            set
            {
                if (index < 0 || index >= this.bitArray.Length)
                {
                    throw new IndexOutOfRangeException($"Index {index} is invalid!");
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException($"Value {value} is invalid!");
                }

                this.bitArray[index] = (byte)value;
            }
        }

        private BigInteger ConvertToDecimal()
        {
            var result = new BigInteger();

            for (var index = 0; index < this.bitArray.Length; index++)
            {
                if (this.bitArray[index] == 1)
                {
                    result += BigInteger.Pow(2, index);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.ConvertToDecimal()}";
        }
    }
}