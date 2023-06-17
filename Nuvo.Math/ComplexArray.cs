using Nuvo.Math.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.Math
{
    namespace Nuvo.Math
    {
        public class ComplexArray<D> where D : IRealNumber<D>
        {
            private Complex<D>[] array;

            public ComplexArray(int length)
            {
                array = new Complex<D>[length];
            }

            public Complex<D> this[int index]
            {
                get { return array[index]; }
                set { array[index] = value; }
            }

            public int Length
            {
                get { return array.Length; }
            }

            public void Print()
            {
                foreach (var complex in array)
                {
                    Console.WriteLine(complex);
                }
            }

            // Add more methods and operations as needed

            // Example: Method to calculate the sum of all complex numbers in the array
            public Complex<D> CalculateSum()
            {
                Complex<D> sum = default(Complex<D>);
                foreach (var complex in array)
                {
                    sum += complex;
                }
                return sum;
            }
        }
    }
}
